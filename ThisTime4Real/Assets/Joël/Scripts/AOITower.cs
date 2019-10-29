using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AOITower : Tower
{
    public void AOIDamage(float amountofdamage)
    {
        if (cooldown <= 0)
        {
            foreach (GameObject enemies in targetList)
            {
                enemies.GetComponent<EnemyMovement>().health -= amountofdamage;
                cooldown = maxCooldown;
            }
        }
    }

    public void AOIPoison(float poisonTick, float amountofdamage)
    {
        if (cooldown <= 0)
        {
            foreach (GameObject enemies in targetList)
            {
                    if (enemies.GetComponent<EnemyMovement>().tickDamage == false)
                    {
                        enemies.GetComponent<EnemyMovement>().tickDamage = true;
                        enemies.GetComponent<EnemyMovement>().amountOfPoisonDamage += amountofdamage;
                        enemies.GetComponent<EnemyMovement>().lengthOfPoision += poisonTick;
                    }
                cooldown = maxCooldown;
            }
        }
    }
}
