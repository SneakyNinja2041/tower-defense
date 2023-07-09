using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class TurretBlueprint
{
    public GameObject prefab;
    public int cost;
    public int damage;
    public int atkSpeed;

    public GameObject upgradedPrefab;
    public int upgradeCost;
    public int upgradedDamage;
    public int upgradedAtkSpeed;

    public GameObject finalPrefab;
    public int finalCost;
    public int finalDamage;
    public int finalAtkSpeed;

    public int GetSellAmount ()
    {
        return cost / 2; 
    }

}
