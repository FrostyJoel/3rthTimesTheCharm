using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Projectile : MonoBehaviour
{
    public float damage;
    public float rad;

    private void OnTriggerEnter(Collider other)
    {
        AoiBlast();
    }
    private void Update()
    {
        Rigidbody r = GetComponent<Rigidbody>();
        if(UIManager.gameSpeed <= 0)
        {
            r.useGravity = false;
            
        }
        else if (UIManager.gameSpeed >= 1)
        {
            r.useGravity = true;
            Destroy(gameObject, 3f);
        }
    }
    public void AoiBlast()
    {
        Vector3 spherepos = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z);
        Collider[] collisions = Physics.OverlapSphere(spherepos, rad);
        for (int i = 0; i < collisions.Length; i++)
        {
            if (collisions[i].tag == "Enemy")
            {
                collisions[i].GetComponent<EnemyMovement>().health -= damage;
                Destroy(gameObject);
            }
        }
    }
    private void OnDrawGizmosSelected()
    {
        Vector3 spherepos = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z);
        Gizmos.DrawWireSphere(spherepos, rad);
    }
}
