using System.Collections;
using System.Collections.Generic;
using TMPro;
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
        InvokeRepeating("UpdateMoney", 0f, 0.5f);
    }

    private TurretBlueprint turretToBuild;
    [Header("Text")]
    public TextMeshPro MoneyText;
    [Header("BuildEffect")]
    public GameObject BuildEffect;
    [Header("Towers")]
    public GameObject T1Prefab;
    public GameObject T2Prefab;
    public GameObject T3Prefab;
    public GameObject WT1Prefab;
    public GameObject WT2Prefab;
    public GameObject WT3Prefab;
    
    public bool CanBuild { get { return turretToBuild != null; } }
    public bool HasMoney { get { return PlayerStats.Money >= turretToBuild.cost; } }

    public void UpdateMoney()
    {
        MoneyText.text = ("$" + PlayerStats.Money);
    }
    public void BuildTurretOn(Node node)
    {
        if (PlayerStats.Money < turretToBuild.cost)
        {
            Debug.Log("Not enough money!");
            return;
        }
        PlayerStats.Money -= turretToBuild.cost;
        GameObject turret = (GameObject )Instantiate(turretToBuild.prefab, node.GetBuildPosistion(), Quaternion.identity);
        GameObject BuildEff = (GameObject)Instantiate(BuildEffect, node.GetBuildPosistion(), Quaternion.identity);
        node.turret = turret;
        Debug.Log("Turret Built! Money Left: " + PlayerStats.Money);
    }

    public void SetTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;
    }

}
