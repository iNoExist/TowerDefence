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

    private TurretBlueprint turretToBuild;
    public GameObject T1Prefab;
    public GameObject T2Prefab;
    public GameObject T3Prefab;
    public GameObject WT1Prefab;
    public GameObject WT2Prefab;
    public GameObject WT3Prefab;
    
    public bool CanBuild { get { return turretToBuild != null; } }

    public void BuildTurretOn(Node node)
    {
        if (PlayerStats.Money < turretToBuild.cost)
        {
            Debug.Log("Not enough money!");
            return;
        }
        PlayerStats.Money -= turretToBuild.cost;
        GameObject turret = (GameObject )Instantiate(turretToBuild.prefab, node.GetBuildPosistion(), Quaternion.identity);
        node.turret = turret;
        Debug.Log("Turret Built! Money Left: " + PlayerStats.Money);
    }

    public void SetTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;
    }

}
