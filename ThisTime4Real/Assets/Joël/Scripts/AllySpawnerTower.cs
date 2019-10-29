using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllySpawnerTower : Tower
{
    public GameObject ally;
    public bool spawned;
    public bool pathNearby;
    public List<GameObject> paths = new List<GameObject>();

    public void Start()
    {
        CheckPath();
    }

    public void CheckPath()
    {
        Collider[] pathCubes = Physics.OverlapSphere(transform.position, rad);
        for (int i = 0; i < pathCubes.Length; i++)
        {
            if(pathCubes[i].tag == "Path")
            {
                paths.Add(pathCubes[i].gameObject);
            }
        }
    }

    public void Update()
    {
        if (!spawned)
        {
            Timer();
            if (paths.Count > 0 && cooldown <= 0)
            {
                SpawnAlly();
                cooldown = maxCooldown;
            }
        }
    }

    public void SpawnAlly()
    {
        //Todo Change als ik een model heb
        GameObject randomPath = paths[Random.Range(0, paths.Count)];
        Vector3 spawnPos = new Vector3(randomPath.transform.position.x, randomPath.transform.position.y + 1f, randomPath.transform.position.z);
        GameObject towerSpawn = Instantiate(ally,spawnPos,Quaternion.identity);
        towerSpawn.GetComponentInChildren<AllyAttack>().mainTower = gameObject;
        spawned = true;
    }
}
