using UnityEngine;
using TMPro;

public class NodeUI : MonoBehaviour
{
    private Node target;
    public TextMeshProUGUI sellText;

    public GameObject UI;
    public void SetTarget(Node nodePassed)
    {
        target = nodePassed;
        transform.position = target.GetBuildPosistion();
        sellText.text = "$" +  target.turretBlueprint.GetSell();
        UI.SetActive(true);
    }
    public void hide()
    {
        UI.SetActive(false);
    }
    public void Sell()
    {
        target.SellTurret();
        BuildManager.instance.DeselectNode();
    }
}
