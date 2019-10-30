using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform spawnLocation;
    public bool startSpawning;
    int wave;
    public float time;
    public float roundtime;
    public float spawnTime;

    public UIManager ui;
    public PathManager gm;

    [SerializeField] public List<Waves> waves;

    private void Awake()
    {
        ui = GameObject.FindGameObjectWithTag("UI").GetComponent<UIManager>();
        gm = GameObject.FindGameObjectWithTag("PathManager").GetComponent<PathManager>();
    }
    // Start is called before the first frame update
    void Start()
    {
        ui.UpdateWave(wave);
        spawnLocation = gm.startingPos.transform;
    }

    public void StartWave()
    {
        StartCoroutine(StartSpawn());
    }

    IEnumerator StartSpawn()
    {
        while (wave < waves.Count)
        {
            if(UIManager.gameSpeed > 0)
            {
                int backUpWave = wave;
                wave++;
                time = roundtime;
                ui.UpdateWave(backUpWave);
                for (int j = 0; j < waves[backUpWave].spawns.Count; j++)
                {
                    StartCoroutine(Spawn(waves[backUpWave].spawns[j].entity, waves[backUpWave].spawns[j].amount));
                    yield return new WaitForSeconds(waves[backUpWave].spawns[j].amount * spawnTime);
                }
            }
        }
    }

    IEnumerator Spawn(GameObject enemy, int maxAmount)
    { 
        bool spawning = true;
        int amount = 0;
        while (spawning)
        {
            if (UIManager.gameSpeed > 0)
            {
                amount++;
                Instantiate(enemy, spawnLocation.position, enemy.transform.rotation);
                if (amount >= maxAmount)
                {
                    spawning = false;
                    yield break;
                }
                yield return new WaitForSeconds(spawnTime);
            }
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        if(UIManager.gameSpeed > 0 && time > 0)
        {
            time -= Time.deltaTime * UIManager.gameSpeed;
            if (startSpawning || time <= 0)
            {
                StartWave();
            }
            if (startSpawning)
            {
                startSpawning = false;
            }
        }
        ui.totalTimeLeft = Mathf.RoundToInt(time);
    }

    [System.Serializable]
    public struct Waves
    {
        [SerializeField]public List<SpawnData> spawns;
    }
    [System.Serializable]
    public struct SpawnData
    {
        [SerializeField] public int amount;
        [SerializeField] public GameObject entity;
    }
}
