using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyBase : MonoBehaviour
{
    public float moveSpeed, maxMoveSpeed = 5f;
    public bool flying;
    public bool bomber;

    public float health, maxHealth = 5f;
    public float timeOfDeath;
    public bool alive = true;
    public int money = 5;

    public float damage = 2;
    public float baseDamage = 2;
    public float AttackTimer, maxAttackTimer = 5f;

    public bool tickDamage = false;
    public float amountOfPoisonDamage = 0;
    public float lengthOfPoision = 0f;
    float maxTick = 2f;
    float tick;

    public Animator anime;
    public Image healthImage;
    public Image childImage;
    PoisonManager p;

    void Awake()
    {
        health = maxHealth;
        moveSpeed = maxMoveSpeed;
        p = GameObject.FindGameObjectWithTag("Manager").GetComponent<PoisonManager>();
        p.enemies.Add(gameObject);
    }
    public IEnumerator Poisoning()
    {
        while (tickDamage)
        {
            tick -= maxTick * Time.deltaTime * UIManager.gameSpeed;
            if(tick < 0)
            {
                print("Poisoned");
                health -= amountOfPoisonDamage;
                tick = maxTick;
            }
            yield return new WaitForSeconds(3f);
        }
    }
    public virtual void Update()
    {
        healthImage.transform.LookAt(Camera.main.transform.position);
        childImage.fillAmount = health / maxHealth;
        Timer();
    }


    public void Timer()
    {
        if (AttackTimer > 0)
        {
            AttackTimer -= Time.deltaTime * UIManager.gameSpeed;
        }
    }

}
