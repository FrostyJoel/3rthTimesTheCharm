using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerElement : MonoBehaviour
{
    public GameObject tower;
    public GameObject shop;
    public GameObject realTower;
    public Text TowerText;
    public int cost;

    private void Awake()
    {
        TowerText = GetComponentInChildren<Text>();
        TowerText.text = realTower.name + "\n" + "Cost: " + cost.ToString() + " " + "Drachma";
    }
    public void Buy()
    {
        shop.GetComponent<Shop>().SetTower(tower,realTower, cost);
    }
}
