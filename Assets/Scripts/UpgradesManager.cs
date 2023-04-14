using BreakInfinity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradesManager : MonoBehaviour
{
    
    public static UpgradesManager Instance { get; private set; }

    public Upgrades clickUpgrade;

    public BigDouble clickUpgradeBaseCost;
    public BigDouble clickUpgradeCostMultiplier;

    private void Awake()
    {
        Instance = this;
    }

    public void StartUpgradeManager()
    {
        
        clickUpgradeBaseCost = 10;
        clickUpgradeCostMultiplier = 1.5;

        UpdateUpgradeUI();
    }


    public BigDouble Cost() => clickUpgradeBaseCost * BigDouble.Pow(clickUpgradeCostMultiplier, Controller.Instance.data.ClickUpgradeLevel);

    public void UpdateUpgradeUI()
    {
        clickUpgrade.levelText.text = "Seviye:" + Controller.Instance.data.ClickUpgradeLevel.ToString();
        clickUpgrade.costText.text = "Maliyet:" + Cost().ToString("F2");
    }

    public void BuyUpgrade()
    {
        if(Controller.Instance.data.Food >= Cost())
        {
            Controller.Instance.data.Food -= Cost();
            Controller.Instance.data.ClickUpgradeLevel += 1;
        }
        UpdateUpgradeUI();
    }
}
