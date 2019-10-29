using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder
{
    public List<GridTile> todo = new List<GridTile>();
    public List<GridTile> done = new List<GridTile>();
    public List<GridTile> path = new List<GridTile>();
    GridTile smallestDis;
    GridTile temp;

    public void StartSearch(GridTile startPos, GridTile endPos)
    {
        todo = new List<GridTile>();
        done = new List<GridTile>();
        todo.Add(startPos);
        smallestDis = startPos;
        smallestDis.CalcuteDistance(endPos, startPos);
        while (todo.Count > 0)
        {
            smallestDis = todo[0];
            for (int i = 0; i < todo.Count; i++)
            {
                if (smallestDis != null && todo[i].totalDistance <= smallestDis.totalDistance)
                {
                    if(temp != todo[i])
                    {
                        temp = todo[i];
                        smallestDis = temp;
                    }
                }
            }
            done.Add(smallestDis);
            done.Add(temp);
            todo.Remove(temp);

            if(smallestDis == endPos)
            {
                endPos.CalcuteDistance(endPos,smallestDis.previousTile);
                done.Reverse();
                foreach (GridTile tile in done)
                {
                    if (tile == smallestDis.previousTile && !path.Contains(tile))
                    {
                        path.Add(tile);
                        smallestDis = smallestDis.previousTile;
                    }
                }
                if(smallestDis == startPos)
                {
                    path.Reverse();
                    break;
                }
                
            }

            GridTile[,] grid = GameObject.FindGameObjectWithTag("PathManager").GetComponent<PathManager>().grid;
            List<GridTile> neighbour = new List<GridTile>();
            int k, j;
            j = smallestDis.x_pos;
            k = smallestDis.z_pos;

            //Left
            if (j - 1 >= 0 && j != 0)
            {
                if (!grid[j - 1, k].blockade)
                {
                    neighbour.Add(grid[j - 1, k]);
                }
            }
            //Right
            if (j + 1 < grid.GetLength(0) && j != grid.GetLength(0) - 1)
            {
                if (!grid[j + 1, k].blockade)
                {
                    neighbour.Add(grid[j + 1, k]);
                } 
            }
            //Below
            if (k - 1 >= 0 && k != 0)
            {
                if (!grid[j, k - 1].blockade)
                {
                    neighbour.Add(grid[j, k - 1]);
                }
            }
            //Above
            if (k + 1 < grid.GetLength(1) && k != grid.GetLength(1) - 1)
            {
                if (!grid[j, k + 1].blockade)
                { 
                    neighbour.Add(grid[j, k + 1]);
                }
            }
            foreach (GridTile neigbouringGrid in neighbour)
            {
                if(!done.Contains(neigbouringGrid) && !todo.Contains(neigbouringGrid))
                {
                    neigbouringGrid.CalcuteDistance(endPos, smallestDis);
                    todo.Add(neigbouringGrid);
                }
            }
        }
        if (todo.Count <= 0)
        {
            Debug.LogError("No Target");
        }
    }
}
