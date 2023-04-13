using BreakInfinity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradesManager : MonoBehaviour
{
    public Click click;

    public Upgrades clickUpgrade;

    public BigDouble clickUpgradeBaseCost;
    public BigDouble clickUpgradeCostMultiplier;

    public void StartUpgradeManager()
    {
        
        clickUpgradeBaseCost = 10;
        clickUpgradeCostMultiplier = 1.5;

        UpdateUpgradeUI();
    }


    public BigDouble Cost() => clickUpgradeBaseCost * BigDouble.Pow(clickUpgradeCostMultiplier, click.data.ClickUpgradeLevel);

    public void UpdateUpgradeUI()
    {
        clickUpgrade.levelText.text = "Seviye:" + click.data.ClickUpgradeLevel.ToString();
        clickUpgrade.costText.text = "Maliyet:" + Cost().ToString("F2");
    }

    public void BuyUpgrade()
    {
        if(click.data.Food >= Cost())
        {
            click.data.Food -= Cost();
            click.data.ClickUpgradeLevel += 1;
        }
        UpdateUpgradeUI();
    }
}
