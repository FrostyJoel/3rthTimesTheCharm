using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeManager : MonoBehaviour
{
    public List<GameObject> ranges = new List<GameObject>();
    
    public void ResetRanges()
    {
        foreach (GameObject ran in ranges)
        {
            ran.SetActive(false);
        }
        ranges.Clear();
    }
}
