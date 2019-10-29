using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    public List<Transform> extraEnemyPos = new List<Transform>();
    public GameObject spawn;
    public int amountOfEnemies;

    private void Awake()
    {
        if(extraEnemyPos.Count > 0)
        {
            amountOfEnemies = Random.Range(1, extraEnemyPos.Count + 1);
        }
    }
}
