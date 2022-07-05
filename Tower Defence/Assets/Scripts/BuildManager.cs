using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;
    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogError("MORE THAN 1 BUILDMANAGER SCRIPT!");
        }
        instance = this;    
    }

    private GameObject turretToBuild;
    public GameObject T1Prefab;
    public GameObject T2Prefab;
    public GameObject T3Prefab;
    public GameObject WT1Prefab;
    public GameObject WT2Prefab;
    public GameObject WT3Prefab;

    public GameObject GetturretToBuild()
    {
        
        return turretToBuild;
    }

    public void SetTurretToBuild(GameObject turret)
    {
        turretToBuild = turret;
    }

}
