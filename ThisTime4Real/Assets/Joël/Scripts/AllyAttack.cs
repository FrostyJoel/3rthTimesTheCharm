using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AllyAttack : Tower
{
    public float health;
    public float maxhealth;
    public float reached = 1f;

    public GameObject mainTower;

    public Image healthImage;
    public Image childImage;

    private void Start()
    {
        health = maxhealth;
    }
    public void Update()
    {
        healthImage.transform.LookAt(Camera.main.transform.position);
        childImage.fillAmount = health / maxhealth;
        Timer();
        if (targetList.Count > 0)
        {
            AttackTarget();
            Attack();
        }
        if (health <= 0)
        {
            SelfDestroy();
        }
        if(mainTower == null)
        {
            Destroy(gameObject);
        }
    }

    public void AttackTarget()
    {
        foreach (GameObject enemy in targetList)
        {
            if (!enemy.GetComponent<EnemyMovement>().flying)
            {
                enemy.GetComponent<EnemyMovement>().tempWaypoint = GetComponentInChildren<Transform>();
            }
        }
    }

    public void SelfDestroy()
    {
        mainTower.GetComponent<AllySpawnerTower>().spawned = false;
        Destroy(gameObject);
    }

    public void Attack()
    {
        if (cooldown <= 0)
        {
            foreach (GameObject enemies in targetList)
            {
                if (!enemies.GetComponent<EnemyMovement>().flying)
                {
                    float dis = Vector3.Distance(transform.position, enemies.transform.position);
                    if (dis <= rad)
                    {
                        enemies.GetComponent<EnemyMovement>().health -= amountOfDamage;
                        cooldown = maxCooldown;
                    }
                }
            }
        }
    }
}
