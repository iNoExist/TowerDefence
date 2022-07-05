using UnityEngine.EventSystems;
using UnityEngine;

public class Node : MonoBehaviour
{
    public Color hoverColor;


    private GameObject turret;
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
        if (buildmanager.GetturretToBuild() == null)
        {
            return;
        }
        rend.material.color = hoverColor;
    }
    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }

    private void OnMouseDown()
    {
        if (buildmanager.GetturretToBuild() == null)
        {
            Debug.Log("NO TURRET SELECTED!");
            return;
        }
        if (turret != null)
        {
            Debug.Log("CANT PLACE! ALREADY TURRET!");
            return;
        }
        

        GameObject turretToBuild = BuildManager.instance.GetturretToBuild();
        turret = (GameObject)Instantiate(turretToBuild, transform.position, transform.rotation);
    }

}
