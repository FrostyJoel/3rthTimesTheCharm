using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleFireTower : Tower
{
    public Transform partToRotate;
    public Transform firePos;
    public GameObject bullet;
    public float bulletSpeed = 1000f;
    public float airAmount;

    public float aimAssist;
    public float turnSpeed;

    public void SingleFire(float amountDamage)
    {
        foreach (GameObject enemies in targetList)
        {
            if (cooldown <= 0)
            {
                GameObject bul = Instantiate(bullet, firePos.position, Quaternion.identity);
                bul.GetComponent<Rigidbody>().AddForce(firePos.forward * bulletSpeed);
                bul.GetComponent<Projectile>().damage = amountDamage;
                cooldown = maxCooldown;
            }
        }
    }
    public void SingelDestroy(float amountDamage)
    {
        foreach (GameObject enemies in targetList)
        {
            if(cooldown<= 0)
            {
                Vector3 rains = enemies.transform.position + (enemies.transform.forward * enemies.GetComponent<EnemyMovement>().moveSpeed * UIManager.gameSpeed) + new Vector3(transform.localPosition.x, airAmount, transform.localPosition.z);
                GameObject justice = Instantiate(bullet, rains, Quaternion.identity);
                justice.GetComponent<Rigidbody>().mass = bulletSpeed;
                justice.GetComponent<Projectile>().damage = amountDamage;
                cooldown = maxCooldown;
            }
        }
    }

    virtual public void Update()
    {
        for (int i = 0; i < targetList.Count;)
        {
            if (partToRotate != null)
            {
                Vector3 aimPoint = targetList[i].transform.position + (targetList[i].transform.forward * aimAssist * UIManager.gameSpeed);
                Vector3 dir = aimPoint - transform.position;
                Quaternion lookRotation = Quaternion.LookRotation(dir);
                Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * UIManager.gameSpeed * turnSpeed).eulerAngles;
                partToRotate.rotation = Quaternion.Euler(rotation.x, rotation.y, 0f);
            }
            break;
        }
    }
}
