using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AOIPoison : AOITower
{
    public float lengthOfPoison = 2f;    
    void Update()
    {
        Timer();
        if (targetList.Count > 0)
        {
            AOIPoison(lengthOfPoison, amountOfDamage);
        }
    }
}
