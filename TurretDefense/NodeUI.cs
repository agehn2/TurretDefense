using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NodeUI : MonoBehaviour
{

    public GameObject ui;

    public Text upgradeCost;

    public Button upgradeButton;

    public Text sellAmount;

    private Node target;

    public void SetTarget(Node _Target)
    {
        target = _Target;

        transform.position = target.GetBuildPosition();

        if (!target.isUpgraded)
        {
            upgradeCost.text = "$" + target.turretBlueprint.upgradeCost;
            upgradeButton.interactable = true;
        }
        else
        {
            upgradeCost.text = "Done!!";
            upgradeButton.interactable = false;
        }

        sellAmount.text = "$" + target.turretBlueprint.GetSellAmount();

        ui.SetActive(true);
    }

    public void Hide()
    {
        ui.SetActive(false);
    }

    public void Upgrade()
    {
        target.UpgradeTurret();
        BuildManager.instance.DeselectNode();
        Debug.Log("Upgraded Turret!");
    }

    public void Sell()
    {
        target.SellTurret();
        BuildManager.instance.DeselectNode();
        target.isUpgraded = false;
        Debug.Log("Turret Sold!");
    }
}