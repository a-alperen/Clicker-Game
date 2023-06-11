using BreakInfinity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpgradesManager : MonoBehaviour
{
    
    public static UpgradesManager Instance { get; private set; }

    public NewUpgradeHandler[] newUpgradeHandlers;

    [Header("Requirement Panel Stuff")]
    [Space(3)]
    public TextMeshProUGUI upgradeNameText;
    public GameObject upgradeNamePanel;
    public GameObject[] upgradeCostTexts;
    public Image[] upgradeCostImages;
    public Sprite[] upgradeCostSprites;

    private string[] sectionNames;
    private void Awake()
    {
        Instance = this;
    }
    private void Update()
    {
        //UpgradeUnlockSystem(Controller.Instance.data.amounts[1], upgradeHandlers[0].UpgradesUnlock,0);
        //UpgradeUnlockSystem(Controller.Instance.data.amounts[1], upgradeHandlers[1].UpgradesUnlock, 1);
    }
    //public void UpgradeUnlockSystem(BigDouble currency, BigDouble[] unlock, int index)
    //{
    //    for (var i = 0; i < upgradeHandlers[index].Upgrades.Count; i++)
    //    {
    //        if (!upgradeHandlers[index].Upgrades[i].gameObject.activeSelf) upgradeHandlers[index].Upgrades[i].gameObject.SetActive(currency >= unlock[i]);

    //    }
    //}
    //public void UpgradeLockSystem(int index)
    //{
    //    for (var i = 0; i < upgradeHandlers[index].Upgrades.Count; i++)
    //    {
    //        if (upgradeHandlers[index].Upgrades[i].gameObject.activeSelf) upgradeHandlers[index].Upgrades[i].gameObject.SetActive(false);

    //    }
    //}
    public void StartUpgradeManager()
    {
        Methods.CheckList(Controller.Instance.data.Levels[0], 8);
        Methods.CheckList(Controller.Instance.data.Levels[1], 10);
        Methods.CheckList(Controller.Instance.data.Levels[2], 10);
        Methods.CheckList(Controller.Instance.data.Levels[3], 9);

        //Names of upgrades
        newUpgradeHandlers[0].UpgradesNames = new string[] { "Toplayıcı", "Avcı", "Çiftçi", "Topluluk", "Değirmen", "Traktör", "Biçerdöver", "Fabrika" };
        newUpgradeHandlers[1].UpgradesNames = new string[] { "Sopalı Adam", "Okçu Adam", "Süvari", "Piyade", "Top", "Tank", "Gemi", "Uçak", "Roket", "Uzay Gemisi" };
        newUpgradeHandlers[2].UpgradesNames = new string[] { "Orman", "Tarla", "Mezra", "Şehir", "Eyalet", "Ülke", "Kıta", "Dünya", "Güneş Sistemi", "Galaksi" };
        newUpgradeHandlers[3].UpgradesNames = new string[] { "Odun", "Taş", "Bakır", "Demir", "Kurşun", "Kömür", "Çelik", "Titanyum", "Elmas" };

        // 0- Yiyecek 1- Askeri 2- Toprak 3- Materyal 4- İnsan sayısı 5- Önceki Geliştirme 
        newUpgradeHandlers[0].UpgradesCost = new List<List<BigDouble>> {
            new List<BigDouble> { 25    , 0, 10   , 0    , 1   , 0    }, //Toplayıcı 
            new List<BigDouble> { 10e3  , 0, 1e3  , 1e3  , 10  , 100  }, // Avcı
            new List<BigDouble> { 1e6   , 0, 1e4  , 1e3  , 100 , 1e3  }, // Çiftçi
            new List<BigDouble> { 1e9   , 0, 1e7  , 1e6  , 1e3 , 1e4  }, // Topluluk
            new List<BigDouble> { 1e15  , 0, 1e12 , 25e10, 1e5 , 1e4  }, // Değirmen
            new List<BigDouble> { 5e22  , 0, 1e19 , 5e18 , 1e7 , 1e5  }, // Traktör
            new List<BigDouble> { 1e30  , 0, 25e25, 5e21 , 1e10, 25e4 }, // Biçerdöver
            new List<BigDouble> { 5e40  , 0, 75e36, 25e35, 1e15, 1e6  }  // Fabrika
        };
        newUpgradeHandlers[1].UpgradesCost = new List<List<BigDouble>> {
            new List<BigDouble> { 50    , 100  , 0, 25   , 1   , 0    },
            new List<BigDouble> { 1e3   , 25e3 , 0, 1e3  , 10  , 10   },
            new List<BigDouble> { 25e4  , 1e6  , 0, 1e5  , 100 , 5e1  },
            new List<BigDouble> { 1e7   , 25e9 , 0, 25e6 , 1e3 , 1e2  }, 
            new List<BigDouble> { 5e10  , 1e14 , 0, 25e11, 1e4 , 1e3  },
            new List<BigDouble> { 25e15 , 25e19, 0, 1e17 , 1e5 , 25e2 }, 
            new List<BigDouble> { 75e21 , 1e25 , 0, 5e22 , 1e6 , 1e4  }, 
            new List<BigDouble> { 5e26  , 75e30, 0, 25e26, 1e7 , 25e3 }, 
            new List<BigDouble> { 1e32  , 25e35, 0, 1e33 , 1e8 , 1e5  },
            new List<BigDouble> { 25e37 , 1e41 , 0, 5e38 , 1e9 , 1e6  }
        };
        newUpgradeHandlers[2].UpgradesCost = new List<List<BigDouble>> {
            new List<BigDouble> { 50   , 0    , 100  , 10   , 1  , 0   },
            new List<BigDouble> { 1e3  , 250  , 1e4  , 750  , 1e1, 25  },
            new List<BigDouble> { 1e5  , 1e5  , 25e5 , 1e4  , 1e2, 5e1 },
            new List<BigDouble> { 25e4 , 25e5 , 1e7  , 1e6  , 1e3, 1e2 },
            new List<BigDouble> { 75e7 , 5e11 , 5e12 , 25e10, 1e4, 1e3 },
            new List<BigDouble> { 1e15 , 1e16 , 1e18 , 5e16 , 1e5, 1e4 },
            new List<BigDouble> { 5e21 , 75e22, 75e25, 1e21 , 1e6, 1e5 },
            new List<BigDouble> { 25e25, 25e26, 1e29 , 75e25, 1e7, 1e6 },
            new List<BigDouble> { 1e31 , 1e32 , 5e35 , 25e31, 1e8, 1e7 },
            new List<BigDouble> { 75e36, 5e41 , 25e42, 1e38 , 1e9, 1e8 }
        };
        newUpgradeHandlers[3].UpgradesCost = new List<List<BigDouble>> {
            new List<BigDouble> { 10   , 0, 10   , 25   , 1  , 0   },
            new List<BigDouble> { 25e4 , 0, 5e5  , 1e6  , 1e1, 1e1 },
            new List<BigDouble> { 5e7  , 0, 1e8  , 75e10, 1e2, 1e2 },
            new List<BigDouble> { 75e12, 0, 75e12, 1e15 , 1e3, 1e3 },
            new List<BigDouble> { 1e16 , 0, 25e16, 25e19, 1e4, 1e4 },
            new List<BigDouble> { 25e20, 0, 5e21 , 5e24 , 1e5, 1e5 },
            new List<BigDouble> { 5e26 , 0, 1e27 , 75e29, 1e6, 1e6 },
            new List<BigDouble> { 75e31, 0, 75e32, 1e35 , 1e7, 1e7 },
            new List<BigDouble> { 1e38 , 0, 25e38, 25e41, 1e8, 1e8 }
        };
        newUpgradeHandlers[0].UpgradesProductionSecond = new List<float> { 1f, 2f, 5f, 10f, 15f, 30f, 60f, 120f };
        newUpgradeHandlers[1].UpgradesProductionSecond = new List<float> { 1f, 2f, 5f, 10f, 15f, 30f, 60f, 120f, 150f, 180f };
        newUpgradeHandlers[2].UpgradesProductionSecond = new List<float> { 1f, 2f, 5f, 10f, 15f, 30f, 60f, 120f, 150f, 180f };
        newUpgradeHandlers[3].UpgradesProductionSecond = new List<float> { 1f, 2f, 5f, 10f, 15f, 30f, 60f, 120f, 150f };

        sectionNames = new string[] { "Yiyecek", "Askeri", "Toprak", "Materyal" };

        newUpgradeHandlers[0].UpgradesBasePower = new BigDouble[] { 10, 5, 10, 25, 50, 100, 250, 1000 };
        newUpgradeHandlers[1].UpgradesBasePower = new BigDouble[] { 10, 3, 5, 10, 25, 50, 100, 250, 1000, 2500 };
        newUpgradeHandlers[2].UpgradesBasePower = new BigDouble[] { 10, 2, 5, 10, 25, 100, 250, 500, 1000, 2500 };
        newUpgradeHandlers[3].UpgradesBasePower = new BigDouble[] { 10, 3, 10, 25, 50, 100, 250, 500, 1000 };

        CreateUpgrades(Controller.Instance.data.Levels[0], 0);
        CreateUpgrades(Controller.Instance.data.Levels[1], 1);
        CreateUpgrades(Controller.Instance.data.Levels[2], 2);
        CreateUpgrades(Controller.Instance.data.Levels[3], 3);

        void CreateUpgrades<T>(List<T> level, int index)
        {
            for (int i = 0; i < level.Count; i++)
            {
                Upgrades upgrade = Instantiate(newUpgradeHandlers[index].UpgradePrefab, newUpgradeHandlers[index].ContentPanel);
                upgrade.upgradeId = i;
                newUpgradeHandlers[index].Upgrades.Add(upgrade);
            }
            newUpgradeHandlers[index].UpgradesScroll.normalizedPosition = Vector3.zero;
        }

        UpdateUpgradeUI("Food");
        UpdateUpgradeUI("Military");
        UpdateUpgradeUI("Land");
        UpdateUpgradeUI("Material");

        
    }

    public List<BigDouble> UpgradeCost(string type, int upgradeId) => type switch
    {
        "Food" => newUpgradeHandlers[0].UpgradesCost[upgradeId],
        "Military" => newUpgradeHandlers[1].UpgradesCost[upgradeId],
        "Land" => newUpgradeHandlers[2].UpgradesCost[upgradeId],
        "Material" => newUpgradeHandlers[3].UpgradesCost[upgradeId],
        _ => new BigDouble[6].ToList(),
    };

    public void UpdateUpgradeUI( string type, int upgradeId = -1 )
    {
        switch (type)
        {
            case "Food":
                UpdateAllUI(newUpgradeHandlers[0].Upgrades, Controller.Instance.data.Levels[0], newUpgradeHandlers[0].UpgradesNames,0);
                break;
            case "Military":
                UpdateAllUI(newUpgradeHandlers[1].Upgrades, Controller.Instance.data.Levels[1], newUpgradeHandlers[1].UpgradesNames, 1);
                break;
            case "Land":
                UpdateAllUI(newUpgradeHandlers[2].Upgrades, Controller.Instance.data.Levels[2], newUpgradeHandlers[2].UpgradesNames, 2);
                break;
            case "Material":
                UpdateAllUI(newUpgradeHandlers[3].Upgrades, Controller.Instance.data.Levels[3], newUpgradeHandlers[3].UpgradesNames, 3);
                break;
            default:
                break;
        }

        void UpdateAllUI(List<Upgrades> upgrades, List<BigDouble> upgradeLevels, string[] upgradeNames,int index)
        {
            if (upgradeId == -1)
                for (int i = 0; i < newUpgradeHandlers[index].Upgrades.Count; i++)
                    UpdateUI(i);
            else UpdateUI(upgradeId);

            void UpdateUI(int id)
            {
                upgrades[id].levelText.text = $"{upgradeLevels[id].Notate(3,1)}";
                upgrades[id].nameText.text = upgradeNames[id];
                upgrades[id].productionText.text = $"Üretim: {newUpgradeHandlers[index].UpgradesBasePower[id]} {(id - 1 < 0 ? sectionNames[index] : upgradeNames[id-1])}";
                upgrades[id].progressText.text = $"{newUpgradeHandlers[index].UpgradesProductionSecond[id] - newUpgradeHandlers[index].Upgrades[id].slider.value:F1}s";
            }

        }
    }

    public void BuyUpgrade(string type, int upgradeId)
    {
        switch (type)
        {
            case "Food":
                Buy(Controller.Instance.data.Levels[0], 0);
                break;
            case "Military":
                Buy(Controller.Instance.data.Levels[1], 1);
                break;
            case "Land":
                Buy(Controller.Instance.data.Levels[2], 2);
                break;
            case "Material":
                Buy(Controller.Instance.data.Levels[3], 3);
                break;
            default:
                break;
        }
        // Geliştirme satın alma işlemi
        void Buy(List<BigDouble> upgrades,int index)
        {
            var data = Controller.Instance.data;
            var upgradeCost = UpgradeCost(type, upgradeId);
            if (CanAfford(UpgradeCost(type,upgradeId), data.sectionAmounts, upgrades))
            {
                upgrades[upgradeId] += 1;
                data.sectionAmounts[0] -= upgradeCost[0];
                data.sectionAmounts[1] -= upgradeCost[1];
                data.sectionAmounts[2] -= upgradeCost[2];
                data.sectionAmounts[3] -= upgradeCost[3];
                data.humanAmount -= upgradeCost[4];
                data.Levels[index][upgradeId - 1 < 0 ? 0 : upgradeId - 1] -= upgradeCost[5];
            }
            UpdateUpgradeUI(type);
        }
        // Mevcut kaynakların geliştirme için yeterli olup olmadığını kontrol eder.
        bool CanAfford(List<BigDouble> upgradeCost, BigDouble[] amounts, List<BigDouble> upgrades) 
        {
            bool isBuyable = false;
            for (int i = 0; i < amounts.Length; i++)
            {
                if (amounts[i] >= upgradeCost[i]) isBuyable = true;
                else
                {
                    isBuyable = false;
                    break;
                }
            }
            if (Controller.Instance.data.humanAmount >= upgradeCost[4] && upgrades[upgradeId - 1 < 0 ? 0 : upgradeId - 1] >= upgradeCost[5] && isBuyable) return true;
            else return false;

        }
    }

    /// <summary>
    /// Requirement Panelde geliştirme maliyetini gösterir.
    /// </summary>
    /// <param name="type">Maliyetin tipi</param>
    /// <param name="upgradeId"></param>
    public void CostInfo( string type, int upgradeId)
    {
        switch (type)
        {
            case "Food":
                Cost(newUpgradeHandlers[0].UpgradesCost[upgradeId], 0);
                break;
            case "Military":
                Cost(newUpgradeHandlers[1].UpgradesCost[upgradeId], 1);
                break;
            case "Land":
                Cost(newUpgradeHandlers[2].UpgradesCost[upgradeId], 2);
                break;
            case "Material":
                Cost(newUpgradeHandlers[3].UpgradesCost[upgradeId], 3);
                break;
            default:
                break;
        }

        void Cost(List<BigDouble> upgradesCost, int index)
        {
            upgradeNameText.text = $"{newUpgradeHandlers[index].UpgradesNames[upgradeId]}";
            upgradeNamePanel.SetActive(true);
            for (int i =0; i< upgradeCostTexts.Length;i++) upgradeCostTexts[i].SetActive(false);
            for (int i = 0; i < upgradeCostSprites.Length; i++) upgradeCostImages[i].sprite = upgradeCostSprites[i];
            
            for(int i = 0;i < upgradesCost.Count;i++)
            {
                if (upgradesCost[i] != 0)
                {
                    upgradeCostTexts[i].SetActive(true);
                    upgradeCostTexts[i].GetComponent<TextMeshProUGUI>().text = $"{upgradesCost[i].Notate()}";
                    
                }
            }
            for (int j = 0; j < Controller.Instance.data.sectionAmounts.Length; j++)
            {
                if (Controller.Instance.data.sectionAmounts[j] >= upgradesCost[j]) upgradeCostTexts[j].GetComponent<TextMeshProUGUI>().color = Color.green;
                else upgradeCostTexts[j].GetComponent<TextMeshProUGUI>().color = Color.red;
            }
            if(Controller.Instance.data.humanAmount >= upgradesCost[4]) upgradeCostTexts[4].GetComponent<TextMeshProUGUI>().color = Color.green;
            else upgradeCostTexts[4].GetComponent<TextMeshProUGUI>().color = Color.red;
            if (Controller.Instance.data.Levels[index][upgradeId - 1 < 0 ? 0 : upgradeId-1] >= upgradesCost[5]) upgradeCostTexts[5].GetComponent<TextMeshProUGUI>().color = Color.green;
            else upgradeCostTexts[5].GetComponent<TextMeshProUGUI>().color = Color.red;
        }
    }
}
//Methods.CheckList( Controller.Instance.data.ClickUpgradeLevels, 12 );
//Methods.CheckList(Controller.Instance.data.FirstAgeProductionUpgradeLevels, 8);
////Methods.CheckList(Controller.Instance.data.ClickUpgradeLevels, 12);
////Methods.CheckList(Controller.Instance.data.ClickUpgradeLevels, 12);
////Methods.CheckList(Controller.Instance.data.ClickUpgradeLevels, 12);


////Names of upgrades
//upgradeHandlers[0].UpgradesNames = new string[] { "Sopa", "Sapan", "Mızrak", "Ok ve Yay", "Balta", "Tuzaklar","Çapa Aleti", "Tırmık", "Saban ve Boyunduruk", "Orak", "Düven", "Evcilleştirme"};
//upgradeHandlers[1].UpgradesNames = new string[] { "Çapa Aleti" ,"Tırmık" ,"Saban ve Boyunduruk" ,"Orak" , "Düven" ,"Tırpan" ,"Yayık" , "Çıkrık"};
////upgradeHandlers[2].UpgradesNames = new string[] { };
////upgradeHandlers[3].UpgradesNames = new string[] { };
////upgradeHandlers[4].UpgradesNames = new string[] { };
////Base cost of upgrades
//upgradeHandlers[0].UpgradesBaseCost = new BigDouble[] { 10, 100, 500 ,2500, 10000, 25000,100000, 250000, 1000000, 5000000, 25000000, 50000000 };
//upgradeHandlers[1].UpgradesBaseCost = new BigDouble[] { 1000, 7500, 20000, 50000, 100000, 500000, 2500000, 10000000 };
////upgradeHandlers[2].UpgradesBaseCost = new BigDouble[] { };
////upgradeHandlers[3].UpgradesBaseCost = new BigDouble[] { };
////upgradeHandlers[4].UpgradesBaseCost = new BigDouble[] { };
//// Cost multiplier of Upgrades
//upgradeHandlers[0].UpgradesCostMultiplier = new BigDouble[] { 1.25, 1.27, 1.3, 1.32, 1.35, 1.37, 1.4, 1.42, 2.45, 2.47, 2.5, 2.52 };
//upgradeHandlers[1].UpgradesCostMultiplier = new BigDouble[] { 1.5, 1.52, 1.54, 1.56, 1.58, 1.6, 1.62, 1.64 };
////upgradeHandlers[2].UpgradesCostMultiplier = new BigDouble[] { };
////upgradeHandlers[3].UpgradesCostMultiplier = new BigDouble[] { };
////upgradeHandlers[4].UpgradesCostMultiplier = new BigDouble[] { };
//// Base power of Upgrades
//upgradeHandlers[0].UpgradesBasePower = new BigDouble[] 
//{ 
//    1 * PrestigeManager.Instance.PrestigeEffect(),
//    3 * PrestigeManager.Instance.PrestigeEffect(),
//    10 * PrestigeManager.Instance.PrestigeEffect(),
//    25 * PrestigeManager.Instance.PrestigeEffect(),
//    75 * PrestigeManager.Instance.PrestigeEffect(),
//    150 * PrestigeManager.Instance.PrestigeEffect(),
//    250 * PrestigeManager.Instance.PrestigeEffect(),
//    750 * PrestigeManager.Instance.PrestigeEffect(),
//    2000 * PrestigeManager.Instance.PrestigeEffect(),
//    5000 * PrestigeManager.Instance.PrestigeEffect(),
//    15000 * PrestigeManager.Instance.PrestigeEffect(),
//    25000 * PrestigeManager.Instance.PrestigeEffect()
//};
//upgradeHandlers[1].UpgradesBasePower = new BigDouble[] 
//{
//    10 * PrestigeManager.Instance.PrestigeEffect(),
//    25 * PrestigeManager.Instance.PrestigeEffect(),
//    100 * PrestigeManager.Instance.PrestigeEffect(),
//    500 * PrestigeManager.Instance.PrestigeEffect(),
//    1250 * PrestigeManager.Instance.PrestigeEffect(),
//    4000 * PrestigeManager.Instance.PrestigeEffect(),
//    10000 * PrestigeManager.Instance.PrestigeEffect(),
//    25000 * PrestigeManager.Instance.PrestigeEffect()
//};
////upgradeHandlers[2].UpgradesBasePower = new BigDouble[] { 0 };
////upgradeHandlers[3].UpgradesBasePower = new BigDouble[] { 0 };
////upgradeHandlers[4].UpgradesBasePower = new BigDouble[] { 0 };
//// Upgrades unlock amount
//upgradeHandlers[0].UpgradesUnlock = new BigDouble[] { 0, 50, 250, 1250, 5000, 12500, 50000, 125000, 500000, 2500000, 12500000, 25000000 };
//upgradeHandlers[1].UpgradesUnlock = new BigDouble[] { 0, 4000, 10000, 25000, 50000, 25000, 1250000, 5000000 };
////upgradeHandlers[2].UpgradesUnlock = new BigDouble[] { };
////upgradeHandlers[3].UpgradesUnlock = new BigDouble[] { };
////upgradeHandlers[4].UpgradesUnlock = new BigDouble[] { };

//CreateUpgrades(Controller.Instance.data.ClickUpgradeLevels, 0);
//CreateUpgrades(Controller.Instance.data.FirstAgeProductionUpgradeLevels, 1);
////CreateUpgrades(Controller.Instance.data.SecondAgeProductionUpgradeLevels, 2);
////CreateUpgrades(Controller.Instance.data.ThirdAgeProductionUpgradeLevels, 3);
////CreateUpgrades(Controller.Instance.data.FourthAgeProductionUpgradeLevels, 4);


//void CreateUpgrades<T>(List<T> level, int index)
//{
//    for (int i = 0; i < level.Count; i++)
//    {
//        Upgrades upgrade = Instantiate(upgradeHandlers[index].UpgradePrefab, upgradeHandlers[index].UpgradesPanel);
//        upgrade.upgradeId = i;
//        upgrade.gameObject.SetActive(false);
//        upgradeHandlers[index].Upgrades.Add(upgrade);
//    }
//    upgradeHandlers[index].UpgradesScroll.normalizedPosition = Vector3.zero;
//}

//UpdateUpgradeUI("Click");
//UpdateUpgradeUI("FirstAge");
////UpdateUpgradeUI("SecondAge");
////UpdateUpgradeUI("ThirdAge");
////UpdateUpgradeUI("FourthAge");
/////upgrades[id].costText.text = $"{UpgradeCost(type, id).Notate()} \nyiyecek";
/////switch (type)
//{
//    case "Click":
//        UpdateAllUI(upgradeHandlers[0].Upgrades, Controller.Instance.data.ClickUpgradeLevels, upgradeHandlers[0].UpgradesNames,0);
//        break;
//    case "FirstAge":
//        UpdateAllUI(upgradeHandlers[1].Upgrades, Controller.Instance.data.FirstAgeProductionUpgradeLevels, upgradeHandlers[1].UpgradesNames, 1);
//        break;
//    case "SecondAge":
//        break;
//    case "ThirdAge":
//        break;
//    case "FourthAge":
//        break;
//    default:
//        break;
//}
//BigDouble Cost(int index, List<BigDouble> levels)
//{
//    return upgradeHandlers[index].UpgradesBaseCost[upgradeId]
//        * BigDouble.Pow(upgradeHandlers[index].UpgradesCostMultiplier[upgradeId], (BigDouble)levels[upgradeId]);
//}