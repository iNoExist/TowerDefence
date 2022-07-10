using UnityEngine.EventSystems;
using UnityEngine;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    public Vector3 positionOffset;

    [Header("Optional")]
    public GameObject turret;
    private Renderer rend;
    private Color startColor;

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
        rend.material.color = hoverColor;
    }
    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }

    public Vector3 GetBuildPosistion()
    {
        return (transform.position + positionOffset);
    }

    private void OnMouseDown()
    {
        if (!buildmanager.CanBuild)
        {
            Debug.Log("NO TURRET SELECTED!");
            return;
        }
        if (turret != null)
        {
            Debug.Log("CANT PLACE! ALREADY TURRET!");
            return;
        }

        buildmanager.BuildTurretOn(this);
    }

}
