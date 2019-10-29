using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathfinderInteraction : MonoBehaviour
{
    public List<GridTile> walkingPath = new List<GridTile>();
    public int pathCount;
    public Transform currentPath;
    public float moveSpeed;
    public float reached = 1;
    // Update is called once per frame
    void Update()
    {
        if(walkingPath.Count > 0)
        {
            float dis = Vector3.Distance(transform.position, walkingPath[pathCount].transform.position);
            float step = moveSpeed * Time.deltaTime;
            currentPath = walkingPath[pathCount].transform;
            if(dis < reached)
            {
                if(pathCount < walkingPath.Count - 1)
                {
                    pathCount++;
                }
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, currentPath.position, step);
            }
        }
    }
}
