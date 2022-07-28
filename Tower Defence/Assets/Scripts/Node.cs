using UnityEngine.EventSystems;
using UnityEngine;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    public Color NoMoneyColor;
    public Vector3 positionOffset;
    [Header("Optional")] 
    private Renderer rend;
    private Color startColor;
    [HideInInspector]
    public GameObject turret;
    [HideInInspector]
    public TurretBlueprint turretBlueprint;

    BuildManager buildmanager;

    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        buildmanager = BuildManager.instance;
    }

    private void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        if (!buildmanager.CanBuild)
        {
            return;
        }
        if (buildmanager.HasMoney)
        {
            rend.material.color = hoverColor;
        }
        else
        {
            rend.material.color = NoMoneyColor;
        }
    }
    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }

    public Vector3 GetBuildPosistion()
    {
        return (transform.position + positionOffset);
    }
    public void BuildTurret(TurretBlueprint blueprint)
    {
        if (PlayerStats.Money < blueprint.cost)
        {
            Debug.Log("Not enough money!");
            return;
        }
        PlayerStats.Money -= blueprint.cost;
        GameObject _turret = (GameObject)Instantiate(blueprint.prefab, GetBuildPosistion(), Quaternion.identity);
        GameObject BuildEff = (GameObject)Instantiate(buildmanager.BuildEffect, GetBuildPosistion(), Quaternion.identity);
        Destroy(BuildEff, 3f);
        turret = _turret;
        turretBlueprint = blueprint;
        Debug.Log("Turret Built!");
    }

    public void SellTurret()
    {
        PlayerStats.Money += turretBlueprint.GetSell();
        Destroy(turret);
        turretBlueprint = null;
    }

    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        if (turret != null)
        {
            buildmanager.SelectNode(this);
            return;
        }
        if (!buildmanager.CanBuild)
        {
            Debug.Log("NO TURRET SELECTED!");
            return;
        }


        BuildTurret(buildmanager.GetTurretToBuild());
    }

}
