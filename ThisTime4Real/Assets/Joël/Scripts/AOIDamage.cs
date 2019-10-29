using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AOIDamage : AOITower
{
    public void Update()
    {
        Timer();
        if (targetList.Count > 0)
        {
            AOIDamage(amountOfDamage);
        }
    }
}
