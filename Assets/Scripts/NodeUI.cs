using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NodeUI : MonoBehaviour
{

    public GameObject ui;

    private Node target;

    //public TurretBlueprint turretBlueprint;

    public GameObject upgradeButtonUI;
    public GameObject finalButtonUI;

    public TextMeshProUGUI sellAmount;
    public TextMeshProUGUI upgradeCost;
    public TextMeshProUGUI finalCost;
    public Button upgradeButton;

    //public TextMeshProUGUI dmgText;
    //public TextMeshProUGUI speedText;

    public void SetTarget (Node _target)
    {
        this.target = _target;

        transform.position = target.GetBuildPosition();

        if (!target.isUpgraded)
        {
            upgradeCost.text = "$" + target.turretBlueprint.upgradeCost;
            //dmgText.text = "DMG: " + turretBlueprint.damage;
            //speedText.text = "ATK SPD: " + turretBlueprint.atkSpeed;
            upgradeButtonUI.SetActive(true);
            finalButtonUI.SetActive(false);
            upgradeButton.interactable = true;
        }

        if (!target.isFinal && target.isUpgraded)
        {
            finalCost.text = "$" + target.turretBlueprint.finalCost;
            //dmgText.text = "DMG: " + turretBlueprint.upgradedDamage;
            //speedText.text = "ATK SPD: " + turretBlueprint.upgradedAtkSpeed;
            upgradeButtonUI.SetActive(false);
            finalButtonUI.SetActive(true);
        }
        
        if (target.isFinal)
        {
            upgradeCost.text = "DONE!";
            //dmgText.text = "DMG: " + turretBlueprint.finalDamage;
            //speedText.text = "ATK SPD: " + turretBlueprint.finalAtkSpeed;
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
    }

    public void FinalUpgrade()
    {
        target.FinalTurret();
        BuildManager.instance.DeselectNode();
    }

    public void Sell()
    {
        target.SellTurret();
        BuildManager.instance.DeselectNode();
    }

}
