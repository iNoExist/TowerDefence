
using UnityEngine;

public class Shop : MonoBehaviour
{
    BuildManager buildmanager;

    void Start()
    {
        buildmanager = BuildManager.instance;
    }
    public void BuyT1()
    {
        buildmanager.SetTurretToBuild(buildmanager.T1Prefab);
    }
    public void BuyT2()
    {
        buildmanager.SetTurretToBuild(buildmanager.T2Prefab);
    }
    public void BuyT3()
    {
        buildmanager.SetTurretToBuild(buildmanager.T3Prefab);
    }
    public void BuyWT1()
    {
        buildmanager.SetTurretToBuild(buildmanager.WT1Prefab);
    }
    public void BuyWT2()
    {
        buildmanager.SetTurretToBuild(buildmanager.WT2Prefab);
    }
    public void BuyWT3()
    {
        buildmanager.SetTurretToBuild(buildmanager.WT3Prefab);
    }
}
