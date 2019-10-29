using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Highlight : MonoBehaviour
{
    public float rad;
    public GameObject path;
    public GameObject towerPos;
    public HighlightPath hP;
    private void Update()
    {
        CheckIfOutOfRange();
    }
    public void CheckIfOutOfRange()
    {
        if (towerPos != null)
        {
            float dis = Vector3.Distance(gameObject.transform.position, towerPos.transform.position);
            if(dis > rad + 4f)
            {
                hP.allHighlights.Remove(gameObject);
                hP.path.Remove(path);
                hP.donePath.Remove(path);
                Destroy(gameObject);
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
