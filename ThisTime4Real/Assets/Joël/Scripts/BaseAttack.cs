using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseAttack : AOITower
{
    // Update is called once per frame
    void Update()
    {
        Timer();
        AOIDamage(amountOfDamage);
        AttackTarget();
    }

    public void AttackTarget()
    {
        foreach (GameObject enemy in targetList)
        {
            if(enemy != null)
            {
                enemy.GetComponent<EnemyMovement>().tempWaypoint = GetComponentInParent<Transform>();
            }

        }
    }
}
