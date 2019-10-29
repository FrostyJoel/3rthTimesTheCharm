using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetRange : MonoBehaviour
{
    public GameObject realTowerObject;
    public GameObject range;

    RangeManager rangeMan;
    HighlightPath h;
    Tower realTower;

    float tim;
    float maxTim = 1f;

    public void Awake()
    {
        rangeMan = GameObject.FindGameObjectWithTag("RangeManager").GetComponent<RangeManager>();
        if(gameObject.GetComponent<HighlightPath>() != null)
        {
            h = GetComponent<HighlightPath>();
        }
        tim = maxTim;
        realTower = realTowerObject.GetComponentInChildren<Tower>();
        if (range != null && realTower != null)
        {
            range.transform.localScale = new Vector3(realTower.rad * 2, range.transform.localScale.y, realTower.rad * 2);
            range.transform.position = transform.position;
        }
    }

    private void Update()
    {
        if(h != null)
        {
            if (range.activeSelf)
            {
                GetComponent<HighlightPath>().SelectedPaths(realTower.rad, true);
            }
            if (!range.activeSelf)
            {
                GetComponent<HighlightPath>().SelectedPaths(realTower.rad, false);
            }
        }
    }

    public void TurnOnRange()
    {
        if (!range.activeSelf)
        {
            rangeMan.ResetRanges();
            range.SetActive(true);
            rangeMan.ranges.Add(range);
            GameObject.FindGameObjectWithTag("UI").GetComponent<UIManager>().UpdateTower(GetComponent<Tower>().sellCost);
        }
        else 
        {
            range.SetActive(false);
            GameObject.FindGameObjectWithTag("UI").GetComponent<UIManager>().UpdateTower(0);
        }
    }
}
