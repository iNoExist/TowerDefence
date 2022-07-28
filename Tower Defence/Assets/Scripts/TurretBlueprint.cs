using UnityEngine;
using System.Collections;
using System;

[System.Serializable]
public class TurretBlueprint
{
    public GameObject prefab;
    public int cost;

    public int GetSell()
    {
        return ((int)(cost * 0.9));
    }
}
