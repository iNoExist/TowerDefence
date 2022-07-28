using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    private TurretBlueprint turretToBuild;
    private Node SelectedNode;
    [Header("UI")]
    public NodeUI nodeUI;
    [Header("BuildEffect")]
    public GameObject BuildEffect;
    [Header("Towers")]
    public GameObject T1Prefab;
    public GameObject T2Prefab;
    public GameObject T3Prefab;
    public GameObject WT1Prefab;
    public GameObject WT2Prefab;
    public GameObject WT3Prefab;
    public GameObject LT1Prefab;
    public GameObject LT2Prefab;
    public GameObject LT3Prefab;

    public static BuildManager instance;
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("MORE THAN 1 BUILDMANAGER SCRIPT!");
        }
        instance = this;
    }

    public bool CanBuild { get { return turretToBuild != null; } }
    public bool HasMoney { get { return PlayerStats.Money >= turretToBuild.cost; } }

    public void SetTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;
        DeselectNode();
    }
    public TurretBlueprint GetTurretToBuild()
    {
        return turretToBuild;
    }
        public void SelectNode(Node node)
    {
        if (SelectedNode == node)
        {
            DeselectNode();
            return;
        }
        SelectedNode = node;
        turretToBuild = null;
        nodeUI.SetTarget(node);
    }
    public void DeselectNode()
    {
        SelectedNode = null;
        nodeUI.hide();
    }
}

