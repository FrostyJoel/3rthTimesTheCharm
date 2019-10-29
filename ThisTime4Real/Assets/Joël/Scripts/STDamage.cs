using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class STDamage : SingleFireTower
{
    override public void Update()
    {
        base.Update();
        Timer();
        if (targetList.Count > 0)
        {
            SingleFire(amountOfDamage);
        }
    }
}
