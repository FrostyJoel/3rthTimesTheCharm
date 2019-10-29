using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightPath : MonoBehaviour
{
    public GameObject highlight;
    public List<GameObject> allHighlights = new List<GameObject>();
    public List<GameObject> path = new List<GameObject>();
    public List<GameObject> donePath = new List<GameObject>();
    
    public void SelectedPaths(float radi,bool active)
    {
        if (active)
        {
            Collider[] pathCubes = Physics.OverlapSphere(transform.position, radi);
            for (int i = 0; i < pathCubes.Length; i++)
            {
                if (pathCubes[i].tag == "Path")
                {
                    if (!path.Contains(pathCubes[i].gameObject))
                    {
                        path.Add(pathCubes[i].gameObject);
                        break;
                    }
                }
            }
            foreach (GameObject p in path)
            {
                if (!donePath.Contains(p))
                {
                    Vector3 highlightPos = new Vector3(p.transform.position.x,p.transform.position.y + 1f,p.transform.position.z);
                    GameObject light = Instantiate(highlight, highlightPos, Quaternion.identity);
                    light.GetComponent<Highlight>().towerPos = gameObject;
                    light.GetComponent<Highlight>().rad = radi;
                    light.GetComponent<Highlight>().path = p;
                    light.GetComponent<Highlight>().hP = this;
                    allHighlights.Add(light);
                    donePath.Add(p);
                }
            }
        }
        if(!active)
        {
            foreach (GameObject high in allHighlights)
            {
                Destroy(high);
            }
            donePath.Clear();
        }
    }
}
