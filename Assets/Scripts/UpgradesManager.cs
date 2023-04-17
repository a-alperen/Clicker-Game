using BreakInfinity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradesManager : MonoBehaviour
{
    
    public static UpgradesManager Instance { get; private set; }

    public List<Upgrades> clickUpgrades;

    public Upgrades clickUpgradePrefab;

    public ScrollRect clickUpgradesScroll;
    public GameObject clickUpgradesPanel;

    private string[] clickUpgradesNames;
    private BigDouble[] clickUpgradesBaseCost;
    public BigDouble[] clickUpgradesCostMultiplier;
    public BigDouble[] clickUpgradesBasePower;

    private void Awake()
    {
        Instance = this;
    }

    public void StartUpgradeManager()
    {
        Methods.CheckList( Controller.Instance.data.UpgradeLevels, 12 );

        clickUpgradesNames = new[] { "Sopa", "Sapan", "Mızrak", "Ok ve Yay", "Balta", "Tuzaklar",
                                     "Çapa Aleti", "Tırmık", "Saban ve Boyunduruk", "Orak", "Düven", "Tırpan"};
        clickUpgradesBaseCost = new BigDouble[] { 10, 100, 500 ,2500, 10000, 25000,
                                                  100000, 250000, 1000000, 5000000, 25000000, 50000000};
        clickUpgradesCostMultiplier = new BigDouble[] { 1.25, 1.35, 1.45, 1.55, 1.65, 1.75,
                                                        1.85, 1.95, 2.05, 2.15, 2.25, 2.35 };
        clickUpgradesBasePower = new BigDouble[] { 1, 3, 10, 25, 75, 150,
                                                   250, 750, 2000, 5000, 15000, 25000 };

        for (int i = 0; i < Controller.Instance.data.UpgradeLevels.Count; i++)
        {
            Upgrades upgrade = Instantiate(clickUpgradePrefab, clickUpgradesPanel.transform);
            upgrade.upgradeId = i;
            clickUpgrades.Add(upgrade);
            clickUpgradesScroll.normalizedPosition = new Vector2(0,0);
        }


        UpdateUpgradeUI();
    }

    public BigDouble ClickUpgradeCost(int upgradeId) => clickUpgradesBaseCost[upgradeId]
                                                       * BigDouble.Pow(clickUpgradesCostMultiplier[upgradeId], Controller.Instance.data.UpgradeLevels[upgradeId]);

    public void UpdateUpgradeUI(int upgradeId = -1)
    {
        if(upgradeId == -1) for (int i = 0; i < clickUpgrades.Count; i++) UpdateUI(i);
        else UpdateUI(upgradeId);
        
        void UpdateUI(int id)
        {
            clickUpgrades[id].levelText.text = "Seviye:" + Controller.Instance.data.UpgradeLevels[id].ToString();
            clickUpgrades[id].costText.text = $"Maliyet: {ClickUpgradeCost(id):F2} Food";
            clickUpgrades[id].nameText.text = clickUpgradesNames[id];
            clickUpgrades[id].productionText.text = $"Üretim: {clickUpgradesBasePower[id] * Controller.Instance.data.UpgradeLevels[id]} Food";
        }
    }

    public void BuyUpgrade(int upgradeId)
    {
        if(Controller.Instance.data.Food >= ClickUpgradeCost(upgradeId))
        {
            Controller.Instance.data.Food -= ClickUpgradeCost(upgradeId);
            Controller.Instance.data.UpgradeLevels[upgradeId] += 1;
        }
        UpdateUpgradeUI(upgradeId);
    }
}
