
using UnityEngine;

public class Shop : MonoBehaviour
{
    public TurretBlueprint T1BP;
    public TurretBlueprint T2BP;
    public TurretBlueprint T3BP;
    public TurretBlueprint WT1BP;
    public TurretBlueprint WT2BP;
    public TurretBlueprint WT3BP;
    BuildManager buildmanager;

    void Start()
    {
        buildmanager = BuildManager.instance;
    }
    public void BuyT1()
    {
        buildmanager.SetTurretToBuild(T1BP);
    }
    public void BuyT2()
    {
        buildmanager.SetTurretToBuild(T2BP);
    }
    public void BuyT3()
    {
        buildmanager.SetTurretToBuild(T3BP);
    }
    public void BuyWT1()
    {
        buildmanager.SetTurretToBuild(WT1BP);
    }
    public void BuyWT2()
    {
        buildmanager.SetTurretToBuild(WT2BP);
    }
    public void BuyWT3()
    {
        buildmanager.SetTurretToBuild(WT3BP);
    }
}
