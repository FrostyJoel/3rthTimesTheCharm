using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : EnemyBase
{
    public float reached = 1;
    public int pathCount;

    public List<GridTile> walkingPath = new List<GridTile>();

    public Transform currentPath;
    public Transform tempWaypoint;

    // Update is called once per frame
    public override void Update()
    {
        if (alive)
        {
            base.Update();
            CheckifBlocked();
            if (walkingPath.Count > 0)
            {
                float dis = Vector3.Distance(transform.position, walkingPath[pathCount].transform.position);
                float step = moveSpeed * Time.deltaTime * UIManager.gameSpeed;
                if (tempWaypoint != null)
                {
                    currentPath = tempWaypoint;
                }
                else
                {
                    currentPath = walkingPath[pathCount].transform;
                }
                Vector3 lookPos = currentPath.transform.position - transform.position;
                lookPos.y = 0;
                Quaternion rotation = Quaternion.LookRotation(lookPos);
                if (dis < reached)
                {
                    if (tempWaypoint != null)
                    {
                        ResetAnime();
                        anime.SetTrigger("isWalking");
                        transform.position = Vector3.MoveTowards(transform.position, currentPath.position, step);
                        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, step);
                    }
                    else if (pathCount < walkingPath.Count - 1)
                    {
                        pathCount++;
                    }
                }
                else
                {
                    ResetAnime();
                    anime.SetTrigger("isWalking");
                    transform.position = Vector3.MoveTowards(transform.position, currentPath.position, step);
                    transform.rotation = Quaternion.Slerp(transform.rotation, rotation, step);
                }
            }
        }
    }

    public void CheckifBlocked()
    {
        Vector3 spherepos = transform.localPosition;
        Collider[] collisions = Physics.OverlapSphere(spherepos, reached);
        for (int i = 0; i < collisions.Length; i++)
        {
            if (AttackTimer <= 0)
            {
                if (collisions[i].tag == "Ally")
                {
                    if (!flying)
                    {
                        Attack(collisions[i]);
                        break;
                    }
                }
                if (collisions[i].tag == "Base")
                {
                    Attack(collisions[i]);
                    break;
                }
            }
        }
    }

    public void Attack(Collider enemy)
    {
        ResetAnime();
        anime.SetTrigger("isAttacking");
        if (enemy.tag == "Ally")
        {
            enemy.GetComponent<AllyAttack>().health -= damage;
        }
        if (enemy.tag == "Base")
        {
            enemy.GetComponent<Base>().health -= damage;
            health = 0;
        }
        if (bomber)
        {
            health = 0;
        }
        AttackTimer = maxAttackTimer;
    }

    public void ResetAnime()
    {
        anime.ResetTrigger("isWalking");
        anime.ResetTrigger("isDying");
        anime.ResetTrigger("isAttacking");
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, reached);
    }
}
