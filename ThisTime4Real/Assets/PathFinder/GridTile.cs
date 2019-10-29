using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridTile : MonoBehaviour
{
    public int x_pos, z_pos;
    public float tile_cost;
    public float distanceFromStart, distanceToEnd, totalDistance;
    public bool blockade;
    public bool abovePath;
    public PathManager mang;
    public GridTile previousTile;
    Ray r;
    RaycastHit hit;
    
    private void Awake()
    {
        mang = GameObject.FindGameObjectWithTag("PathManager").GetComponent<PathManager>();
        if (Physics.Raycast(transform.position, transform.forward,out hit, Mathf.Infinity))
        {
            if(hit.transform.gameObject.tag == "Path" || hit.transform.gameObject.tag == "Start" || hit.transform.gameObject.tag == "End")
            {
                if(hit.transform.gameObject.tag == "Start")
                {
                    mang.startingPos = this;
                }
                if (hit.transform.gameObject.tag == "End")
                {
                    mang.endingPos = this;
                }
                abovePath = true;
            }
            else
            {
                blockade = true;
            }
        }
    }

    public void CalcuteDistance(GridTile target,GridTile previous)
    {
        previousTile = previous;
        Vector3 thisTile = new Vector3(x_pos, 0, z_pos);
        distanceFromStart = Vector3.Distance(thisTile, new Vector3(previous.x_pos, 0f, previous.z_pos));
        distanceToEnd = Vector3.Distance(thisTile, new Vector3(target.x_pos, 0f, target.z_pos));
        totalDistance = distanceFromStart += distanceToEnd;
    }
}
