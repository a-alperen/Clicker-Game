﻿using BreakInfinity;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradesManager : MonoBehaviour
{
    
    public static UpgradesManager Instance { get; private set; }

    public UpgradeHandler[] upgradeHandlers;


    private void Awake()
    {
        Instance = this;
    }
    private void Update()
    {
        UpgradeUnlockSystem(Controller.Instance.data.amounts[1], upgradeHandlers[0].UpgradesUnlock,0);
        UpgradeUnlockSystem(Controller.Instance.data.amounts[1], upgradeHandlers[1].UpgradesUnlock, 1);
    }
    public void UpgradeUnlockSystem(BigDouble currency, BigDouble[] unlock, int index)
    {
        for (var i = 0; i < upgradeHandlers[index].Upgrades.Count; i++)
        {
            if (!upgradeHandlers[index].Upgrades[i].gameObject.activeSelf) upgradeHandlers[index].Upgrades[i].gameObject.SetActive(currency >= unlock[i]);

        }
    }
    public void UpgradeLockSystem(int index)
    {
        for (var i = 0; i < upgradeHandlers[index].Upgrades.Count; i++)
        {
            if (upgradeHandlers[index].Upgrades[i].gameObject.activeSelf) upgradeHandlers[index].Upgrades[i].gameObject.SetActive(false);

        }
    }
    public void StartUpgradeManager()
    {
        Methods.CheckList( Controller.Instance.data.ClickUpgradeLevels, 12 );
        Methods.CheckList(Controller.Instance.data.FirstAgeProductionUpgradeLevels, 8);
        //Methods.CheckList(Controller.Instance.data.ClickUpgradeLevels, 12);
        //Methods.CheckList(Controller.Instance.data.ClickUpgradeLevels, 12);
        //Methods.CheckList(Controller.Instance.data.ClickUpgradeLevels, 12);

        
        //Names of upgrades
        upgradeHandlers[0].UpgradesNames = new string[] { "Sopa", "Sapan", "Mızrak", "Ok ve Yay", "Balta", "Tuzaklar","Çapa Aleti", "Tırmık", "Saban ve Boyunduruk", "Orak", "Düven", "Evcilleştirme"};
        upgradeHandlers[1].UpgradesNames = new string[] { "Çapa Aleti" ,"Tırmık" ,"Saban ve Boyunduruk" ,"Orak" , "Düven" ,"Tırpan" ,"Yayık" , "Çıkrık"};
        //upgradeHandlers[2].UpgradesNames = new string[] { };
        //upgradeHandlers[3].UpgradesNames = new string[] { };
        //upgradeHandlers[4].UpgradesNames = new string[] { };
        //Base cost of upgrades
        upgradeHandlers[0].UpgradesBaseCost = new BigDouble[] { 10, 100, 500 ,2500, 10000, 25000,100000, 250000, 1000000, 5000000, 25000000, 50000000 };
        upgradeHandlers[1].UpgradesBaseCost = new BigDouble[] { 1000, 7500, 20000, 50000, 100000, 500000, 2500000, 10000000 };
        //upgradeHandlers[2].UpgradesBaseCost = new BigDouble[] { };
        //upgradeHandlers[3].UpgradesBaseCost = new BigDouble[] { };
        //upgradeHandlers[4].UpgradesBaseCost = new BigDouble[] { };
        // Cost multiplier of Upgrades
        upgradeHandlers[0].UpgradesCostMultiplier = new BigDouble[] { 1.25, 1.27, 1.3, 1.32, 1.35, 1.37, 1.4, 1.42, 2.45, 2.47, 2.5, 2.52 };
        upgradeHandlers[1].UpgradesCostMultiplier = new BigDouble[] { 1.5, 1.52, 1.54, 1.56, 1.58, 1.6, 1.62, 1.64 };
        //upgradeHandlers[2].UpgradesCostMultiplier = new BigDouble[] { };
        //upgradeHandlers[3].UpgradesCostMultiplier = new BigDouble[] { };
        //upgradeHandlers[4].UpgradesCostMultiplier = new BigDouble[] { };
        // Base power of Upgrades
        upgradeHandlers[0].UpgradesBasePower = new BigDouble[] 
        { 
            1 * PrestigeManager.Instance.PrestigeEffect(),
            3 * PrestigeManager.Instance.PrestigeEffect(),
            10 * PrestigeManager.Instance.PrestigeEffect(),
            25 * PrestigeManager.Instance.PrestigeEffect(),
            75 * PrestigeManager.Instance.PrestigeEffect(),
            150 * PrestigeManager.Instance.PrestigeEffect(),
            250 * PrestigeManager.Instance.PrestigeEffect(),
            750 * PrestigeManager.Instance.PrestigeEffect(),
            2000 * PrestigeManager.Instance.PrestigeEffect(),
            5000 * PrestigeManager.Instance.PrestigeEffect(),
            15000 * PrestigeManager.Instance.PrestigeEffect(),
            25000 * PrestigeManager.Instance.PrestigeEffect()
        };
        upgradeHandlers[1].UpgradesBasePower = new BigDouble[] 
        {
            10 * PrestigeManager.Instance.PrestigeEffect(),
            25 * PrestigeManager.Instance.PrestigeEffect(),
            100 * PrestigeManager.Instance.PrestigeEffect(),
            500 * PrestigeManager.Instance.PrestigeEffect(),
            1250 * PrestigeManager.Instance.PrestigeEffect(),
            4000 * PrestigeManager.Instance.PrestigeEffect(),
            10000 * PrestigeManager.Instance.PrestigeEffect(),
            25000 * PrestigeManager.Instance.PrestigeEffect()
        };
        //upgradeHandlers[2].UpgradesBasePower = new BigDouble[] { 0 };
        //upgradeHandlers[3].UpgradesBasePower = new BigDouble[] { 0 };
        //upgradeHandlers[4].UpgradesBasePower = new BigDouble[] { 0 };
        // Upgrades unlock amount
        upgradeHandlers[0].UpgradesUnlock = new BigDouble[] { 0, 50, 250, 1250, 5000, 12500, 50000, 125000, 500000, 2500000, 12500000, 25000000 };
        upgradeHandlers[1].UpgradesUnlock = new BigDouble[] { 0, 4000, 10000, 25000, 50000, 25000, 1250000, 5000000 };
        //upgradeHandlers[2].UpgradesUnlock = new BigDouble[] { };
        //upgradeHandlers[3].UpgradesUnlock = new BigDouble[] { };
        //upgradeHandlers[4].UpgradesUnlock = new BigDouble[] { };

        CreateUpgrades(Controller.Instance.data.ClickUpgradeLevels, 0);
        CreateUpgrades(Controller.Instance.data.FirstAgeProductionUpgradeLevels, 1);
        //CreateUpgrades(Controller.Instance.data.SecondAgeProductionUpgradeLevels, 2);
        //CreateUpgrades(Controller.Instance.data.ThirdAgeProductionUpgradeLevels, 3);
        //CreateUpgrades(Controller.Instance.data.FourthAgeProductionUpgradeLevels, 4);


        void CreateUpgrades<T>(List<T> level, int index)
        {
            for (int i = 0; i < level.Count; i++)
            {
                Upgrades upgrade = Instantiate(upgradeHandlers[index].UpgradePrefab, upgradeHandlers[index].UpgradesPanel);
                upgrade.upgradeId = i;
                upgrade.gameObject.SetActive(false);
                upgradeHandlers[index].Upgrades.Add(upgrade);
            }
            upgradeHandlers[index].UpgradesScroll.normalizedPosition = Vector3.zero;
        }

        UpdateUpgradeUI("Click");
        UpdateUpgradeUI("FirstAge");
        //UpdateUpgradeUI("SecondAge");
        //UpdateUpgradeUI("ThirdAge");
        //UpdateUpgradeUI("FourthAge");
    }

    public BigDouble UpgradeCost(string type, int upgradeId)
    {
        return type switch
        {
            "Click" => Cost(0, Controller.Instance.data.ClickUpgradeLevels),
            "FirstAge" => Cost(1, Controller.Instance.data.FirstAgeProductionUpgradeLevels),
            _ => (BigDouble)0,
        };

        BigDouble Cost(int index, List<int> levels)
        {
            return upgradeHandlers[index].UpgradesBaseCost[upgradeId] 
                * BigDouble.Pow(upgradeHandlers[index].UpgradesCostMultiplier[upgradeId], (BigDouble)levels[upgradeId]);
        }
    }

    public void UpdateUpgradeUI( string type, int upgradeId = -1 )
    {
        switch (type)
        {
            case "Click":
                UpdateAllUI(upgradeHandlers[0].Upgrades, Controller.Instance.data.ClickUpgradeLevels, upgradeHandlers[0].UpgradesNames,0);
                break;
            case "FirstAge":
                UpdateAllUI(upgradeHandlers[1].Upgrades, Controller.Instance.data.FirstAgeProductionUpgradeLevels, upgradeHandlers[1].UpgradesNames, 1);
                break;
            case "SecondAge":
                break;
            case "ThirdAge":
                break;
            case "FourthAge":
                break;
            default:
                break;
        }

        
        void UpdateAllUI<T>(List<Upgrades> upgrades, List<T> upgradeLevels, string[] upgradeNames,int index)
        {
            if (upgradeId == -1)
                for (int i = 0; i < upgradeHandlers[index].Upgrades.Count; i++)
                    UpdateUI(i);
            else UpdateUI(upgradeId);

            void UpdateUI(int id)
            {
                upgrades[id].levelText.text = "seviye: " + upgradeLevels[id].ToString();
                upgrades[id].costText.text = $"{UpgradeCost(type, id).Notate()} \nyiyecek";
                upgrades[id].nameText.text = upgradeNames[id];
                upgrades[id].productionText.text = $"tıklama başına \n+{upgradeHandlers[index].UpgradesBasePower[id].Notate()} yiyecek";
            }

        }
    }

    public void BuyUpgrade(string type, int upgradeId)
    {
        switch (type)
        {
            case "Click":
                Buy(Controller.Instance.data.ClickUpgradeLevels);
                break;
            case "FirstAge":
                Buy(Controller.Instance.data.FirstAgeProductionUpgradeLevels);
                break;
            case "SecondAge":
                Buy(Controller.Instance.data.SecondAgeProductionUpgradeLevels);
                break;
            case "ThirdAge":
                Buy(Controller.Instance.data.ThirdAgeProductionUpgradeLevels);
                break;
            case "FourthAge":
                Buy(Controller.Instance.data.FourthAgeProductionUpgradeLevels);
                break;
            default:
                break;
        }
        void Buy(List<int> upgrades)
        {
            if (Controller.Instance.data.amounts[1] >= UpgradeCost(type, upgradeId))
            {
                Controller.Instance.data.amounts[1] -= UpgradeCost(type, upgradeId);
                upgrades[upgradeId] += 1;
            }
            UpdateUpgradeUI(type, upgradeId);
        }
    }
}
