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
   
    public List<Upgrades> productionUpgrades;
    public Upgrades productionUpgradePrefab;
    public ScrollRect productionUpgradeScroll;
    public GameObject productionUpgradePanel;

    private string[] productionUpgradesNames;
    private BigDouble[] productionUpgradesBaseCost;
    public BigDouble[] productionUpgradesCostMultiplier;
    public BigDouble[] productionUpgradesBasePower;

    private void Awake()
    {
        Instance = this;
    }

    public void StartUpgradeManager()
    {
        Methods.CheckList( Controller.Instance.data.ClickUpgradeLevels, 12 );

        clickUpgradesNames = new[] 
        { 
            "Sopa", "Sapan", "Mızrak", "Ok ve Yay", "Balta", "Tuzaklar",
            "Çapa Aleti", "Tırmık", "Saban ve Boyunduruk", "Orak", "Düven", "Evcilleştirme"
        };
        clickUpgradesBaseCost = new BigDouble[] 
        {
            10, 100, 500 ,2500, 10000, 25000,
            100000, 250000, 1000000, 5000000, 25000000, 50000000
        };
        clickUpgradesCostMultiplier = new BigDouble[] 
        {   
            1.25, 1.35, 1.45, 1.55, 1.65, 1.75,
            1.85, 1.95, 2.05, 2.15, 2.25, 2.35 
        };
        clickUpgradesBasePower = new BigDouble[] 
        {   
            1, 3, 10, 25, 75, 150,
            250, 750, 2000, 5000, 15000, 25000 
        };

        productionUpgradesNames = new string[]
        {
            "Çapa Aleti" ,"Tırmık" ,"Saban ve Boyunduruk" ,
            "Orak" , "Düven" ,"Tırpan" ,"Yayık" , "Çıkrık" 
        };
        productionUpgradesBaseCost = new BigDouble[]
        {
            25, 100, 1000, 7500, 20000, 50000, 100000, 500000
        };
        productionUpgradesCostMultiplier = new BigDouble[]
        {
            1.5, 1.75, 2, 2.35, 2.75, 3.15, 3.55, 4
        };
        productionUpgradesBasePower = new BigDouble[]
        {
            1, 3, 15, 50, 150, 500, 1000, 2000
        };


        for (int i = 0; i < Controller.Instance.data.ClickUpgradeLevels.Count; i++)
        {
            Upgrades upgrade = Instantiate(clickUpgradePrefab, clickUpgradesPanel.transform);
            upgrade.upgradeId = i;
            clickUpgrades.Add(upgrade);
            
        }

        for (int i = 0; i < Controller.Instance.data.ProductionUpgradeLevels.Count; i++)
        {
            Upgrades upgrade = Instantiate(productionUpgradePrefab, productionUpgradePanel.transform);
            upgrade.upgradeId = i;
            productionUpgrades.Add(upgrade);
            
        }

        clickUpgradesScroll.normalizedPosition = new Vector2(0, 0);
        productionUpgradeScroll.normalizedPosition = new Vector2(0, 0);

        UpdateUpgradeUI("Click");
        UpdateUpgradeUI("Production");
    }

    public BigDouble UpgradeCost(string type, int upgradeId)
    {
        switch (type)
        {
            case "Click":
                return clickUpgradesBaseCost[upgradeId] * BigDouble.Pow(clickUpgradesCostMultiplier[upgradeId], Controller.Instance.data.ClickUpgradeLevels[upgradeId]);
            case "Production":
                return productionUpgradesBaseCost[upgradeId] * BigDouble.Pow(productionUpgradesCostMultiplier[upgradeId], Controller.Instance.data.ProductionUpgradeLevels[upgradeId]);
            default:
                break;
        }
        return 0;
    }

    public void UpdateUpgradeUI( string type, int upgradeId = -1 )
    {
        switch (type)
        {
            case "Click":
                if ( upgradeId == -1 ) for ( int i = 0; i < clickUpgrades.Count; i++ ) UpdateUI( clickUpgrades, Controller.Instance.data.ClickUpgradeLevels, clickUpgradesNames, i );
                else UpdateUI(clickUpgrades, Controller.Instance.data.ClickUpgradeLevels, clickUpgradesNames, upgradeId);
                break;
            case "Production":
                if (upgradeId == -1) for (int i = 0; i < productionUpgrades.Count; i++) UpdateUI ( productionUpgrades, Controller.Instance.data.ProductionUpgradeLevels, productionUpgradesNames, i );
                else UpdateUI(productionUpgrades, Controller.Instance.data.ProductionUpgradeLevels, productionUpgradesNames, upgradeId);
                break;

            default:
                break;
        }

        
        void UpdateUI(List<Upgrades> upgrades, List<int> upgradeLevels, string[] upgradeNames, int id)
        {
            upgrades[id].levelText.text = "seviye: " + upgradeLevels[id].ToString();
            upgrades[id].costText.text = $"{UpgradeCost(type, id):F2} \nyiyecek";
            upgrades[id].nameText.text = upgradeNames[id];
            upgrades[id].productionText.text = $"tıklama başına \n+{clickUpgradesBasePower[id]} yiyecek";
        }
    }

    public void BuyUpgrade(string type, int upgradeId)
    {
        switch (type)
        {
            case "Click":
                Buy(Controller.Instance.data.ClickUpgradeLevels);
                break;
            case "Production":
                Buy(Controller.Instance.data.ProductionUpgradeLevels);
                break;
            default:
                break;
        }
        void Buy(List<int> upgrades)
        {
            if (Controller.Instance.data.Food >= UpgradeCost(type, upgradeId))
            {
                Controller.Instance.data.Food -= UpgradeCost(type, upgradeId);
                upgrades[upgradeId] += 1;
            }
            UpdateUpgradeUI(type, upgradeId);
        }
    }
}
