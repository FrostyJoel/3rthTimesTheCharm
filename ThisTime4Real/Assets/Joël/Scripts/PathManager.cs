using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathManager : MonoBehaviour
{
    public List<GridTile> gridList = new List<GridTile>();
    public GridTile[,] grid;
    public GridTile gridTile, startingPos, endingPos;
    GameObject[] pathsOnField;
    PoisonManager man;
    PathFinder path;

    public int x_Length, z_Length;

    public void Awake()
    {
        man = GameObject.FindGameObjectWithTag("Manager").GetComponent<PoisonManager>();
        pathsOnField = GameObject.FindGameObjectsWithTag("Path");
        path = new PathFinder();
        CreateGrid();
    }
    public void CreateGrid()
    {
        grid = new GridTile[x_Length, z_Length];
        for (int i = 0; i<x_Length; i++)
        {
            for (int j = 0; j<z_Length; j++)
            {
                gridTile.x_pos = i;
                gridTile.z_pos = j;
                grid[i, j] = Instantiate(gridTile, new Vector3(i, 1.5f, j), gridTile.transform.rotation);
                gridList.Add(gridTile);
            }
        }
        path.StartSearch(startingPos, endingPos);
    }
    private void Update()
    {
        foreach (GameObject enemy in man.enemies)
        {
            if(enemy.GetComponent<EnemyMovement>().walkingPath.Count == 0)
            {
                enemy.GetComponent<EnemyMovement>().walkingPath = path.path;
            }
        }
    }
    public void EnemySearch()
    {
        
    }
}