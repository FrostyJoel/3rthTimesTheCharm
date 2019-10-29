using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckRanges : MonoBehaviour
{
    public RangeManager rangeMan;
    private void Awake()
    {
        rangeMan = GameObject.FindGameObjectWithTag("RangeManager").GetComponent<RangeManager>();
    }
}
