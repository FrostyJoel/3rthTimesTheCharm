using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public GridTile[,] grid;
    public List<GridTile> gridList = new List<GridTile>();
    public GridTile gridTile;
    public int x_Length, z_Length;
    public GameObject tree, player, target;
    public int playerSpawnTile;
    public int targetSpawnTile;
    public bool playerSpawned;
    public bool targetSpawned;
    GameObject[] gridTiles;

    // Start is called before the first frame update
    void Start()
    {
        grid = new GridTile[x_Length, z_Length];
        for (int i = 0; i < x_Length; i++)
        {
            for (int j = 0; j < z_Length; j++)
            {
                gridTile.x_pos = i;
                gridTile.z_pos = j;
                grid[i, j] = Instantiate(gridTile, new Vector3(i, 0f, j), gridTile.transform.rotation);
                gridList.Add(gridTile);
            }
        }
        RandomSpawns();
    }
    public void RandomSpawns()
    {
        gridTiles = GameObject.FindGameObjectsWithTag("Tile");
        float minimumWallCost = 0.85f;
        float minimumGoalCost = 0.5f;
        foreach (GameObject tile in gridTiles)
        {
            GridTile g = tile.GetComponent<GridTile>();
            if (g.tile_cost > minimumWallCost)
            {
                Instantiate(tree, new Vector3(tile.transform.position.x, 0.5f, tile.transform.position.z), tree.transform.rotation);
            }
        }

        playerSpawnTile = Random.Range(0, gridTiles.Length);
        targetSpawnTile = Random.Range(0, gridTiles.Length);

        if(gridTiles[playerSpawnTile].GetComponent<GridTile>().tile_cost > minimumGoalCost && gridTiles[playerSpawnTile].GetComponent<GridTile>().tile_cost < minimumWallCost)
        {
            SpawnPlayer(gridTiles);
        }
        else
        {
            while (!playerSpawned)
            {
                if(gridTiles[playerSpawnTile].GetComponent<GridTile>().tile_cost > minimumGoalCost && gridTiles[playerSpawnTile].GetComponent<GridTile>().tile_cost < minimumWallCost)
                {
                    SpawnPlayer(gridTiles);
                }
                else
                {
                    playerSpawnTile = Random.Range(0, gridTiles.Length);
                }
            }
        }
        if(gridTiles[targetSpawnTile].GetComponent<GridTile>().tile_cost < minimumGoalCost)
        {
            SpawnTarget(gridTiles);
        }
        else
        {
            while (!targetSpawned)
            {
                if(gridTiles[targetSpawnTile].GetComponent<GridTile>().tile_cost < minimumGoalCost)
                {
                    SpawnTarget(gridTiles);
                }
                else
                {
                    targetSpawnTile = Random.Range(0, gridTiles.Length);
                }
            }
        }
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (playerSpawned && targetSpawned)
            {
                PathFinder path = new PathFinder();
                path.StartSearch(gridTiles[playerSpawnTile].GetComponent<GridTile>(), gridTiles[targetSpawnTile].GetComponent<GridTile>());
                player.GetComponent<PathfinderInteraction>().walkingPath = path.path;
            }
        }
    }

    public void SpawnPlayer(GameObject[] gridTiles)
    {
        player = Instantiate(player, new Vector3(gridTiles[playerSpawnTile].transform.position.x, 0.75f, gridTiles[playerSpawnTile].transform.position.z),player.transform.rotation);
        playerSpawned = true;
    }
    public void SpawnTarget(GameObject[] gridTiles)
    {
        Instantiate(target, new Vector3(gridTiles[targetSpawnTile].transform.position.x, 0.5f, gridTiles[targetSpawnTile].transform.position.z), target.transform.rotation);
        targetSpawned = true;
    }
}
