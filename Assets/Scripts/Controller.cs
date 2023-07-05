using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using BreakInfinity;
using UnityEngine.UI;
using UnityEditor;
using System;
using System.Reflection;
using Unity.VisualScripting;

public class Controller : MonoBehaviour
{

    public static Controller Instance { get; private set; }

    private const string dataFileName = "PlayerData";
    private TimeSpan offlineTime;
    private int offlineSeconds;
    private BigDouble[] offlineProduction;
    private BigDouble offlineHumanProduction = 0;
    public Data data;
    [Header("Value Texts")]
    [SerializeField] private TextMeshProUGUI[] sectionText;
    [SerializeField] private TextMeshProUGUI[] offlinePanelTexts;
    [SerializeField] private TextMeshProUGUI[] clickTexts;
    [SerializeField] private TextMeshProUGUI[] sectionProductionTexts;
    [Header("Other Things")]
    [SerializeField] private TextMeshProUGUI humanText;
    [SerializeField] private Slider humanSlider;
    [SerializeField] private GameObject offlineIncomePanel;

    private void Awake()
    {
        Instance = this;
        
    }

    // Start is called before the first frame update
    void Start()
    {
        data = SaveSystem.SaveExists(dataFileName)
               ? SaveSystem.LoadData<Data>(dataFileName)
               : new Data();

        offlineProduction = new BigDouble[] { 0, 0, 0, 0 };
        UpgradesManager.Instance.StartUpgradeManager();
        Settings.Instance.StartSettings();
        AchievementManager.Instance.StartAchievementManager();
        OfflineEarning();

        if (PlayerPrefs.GetInt("Income") == 0)
        {
            offlineIncomePanel.SetActive(false);
            PlayerPrefs.SetInt("Income", 1);
        }
        else offlineIncomePanel.SetActive(true);
    }

    public float SaveTime;

    // Update is called once per frame
    void Update()
    {
        
        UpdateText();
        ProduceHuman();
        Production();
        UpdateAchievements();

        SaveTime += Time.deltaTime * (1 / Time.timeScale);

        if(SaveTime >= 15)
        {
            SaveSystem.SaveData(data, dataFileName);
            SaveTime = 0;
        }
        data.lastOnlineTime = DateTime.Now;
    }

    private void OnApplicationPause(bool pause)
    {
        if (pause)
        {
            SaveSystem.SaveData(data, dataFileName);
        }
    }
    private void OnApplicationQuit()
    {
        SaveSystem.SaveData(data, dataFileName);
    }
    private void OfflineEarning()
    {
        offlineTime = DateTime.Now - data.lastOnlineTime;
        offlineSeconds = (int)offlineTime.TotalSeconds;
        var upgradeHandler = UpgradesManager.Instance.newUpgradeHandlers;
        
        for (int i = 0; i < offlineSeconds; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                for (int k = 0; k < data.Levels[j].Count; k++)
                {
                    if (k == 0) offlineProduction[j] += data.Levels[j][k] * upgradeHandler[j].UpgradesBasePower[k] * data.productionMultiplier[j];
                    else data.Levels[j][k - 1] += data.Levels[j][k] * upgradeHandler[j].UpgradesBasePower[k] / upgradeHandler[j].UpgradesProductionSecond[k];
                }
            }
        }
        offlineHumanProduction = data.humanPower * Produce() * offlineSeconds;
        
        offlinePanelTexts[0].text = $"{offlineProduction[0].Notate()}";
        offlinePanelTexts[1].text = $"{offlineProduction[1].Notate()}";
        offlinePanelTexts[2].text = $"{offlineProduction[2].Notate()}";
        offlinePanelTexts[3].text = $"{offlineProduction[3].Notate()}";
        offlinePanelTexts[4].text = $"{offlineHumanProduction.Notate()}";
        
    }
    /// <summary>
    /// Çevrimdışı geliri dataya ekler.(Unity ara yüzünden çağrılıyor.)
    /// </summary>
    /// <param name="panel"></param>
    public void AddOfflineIncome(GameObject panel)
    {
        for (int i = 0; i < 4; i++)
        {
            data.sectionAmounts[i] += offlineProduction[i];
        }
        data.humanAmount += offlineHumanProduction;
        panel.SetActive(false);
    }
    private void Production()
    {
        var upgradeHandler = UpgradesManager.Instance.newUpgradeHandlers;
        
        Produce("Food", 0);
        Produce("Military", 1);
        Produce("Land", 2);
        Produce("Material", 3);

        void Produce(string type, int index)
        {
            for (int i = 0; i < data.Levels[index].Count; i++)
            {
                upgradeHandler[index].Upgrades[i].slider.maxValue = upgradeHandler[index].UpgradesProductionSecond[i];
                if (data.Levels[index][i] > 0)
                {
                    if (upgradeHandler[index].Upgrades[i].slider.value >= upgradeHandler[index].Upgrades[i].slider.maxValue)
                    {
                        if (i == 0) data.sectionAmounts[index] += data.Levels[index][i] * upgradeHandler[index].UpgradesBasePower[i] * data.productionMultiplier[index] * BigDouble.Pow(1.1, data.prestigeUpgradeLevels[index]);
                        else data.Levels[index][i - 1] += data.Levels[index][i] * upgradeHandler[index].UpgradesBasePower[i] * data.productionMultiplier[index] * BigDouble.Pow(1.1, data.prestigeUpgradeLevels[index]);
                        upgradeHandler[index].Upgrades[i].slider.value = 0;
                    }
                    else
                    {
                        upgradeHandler[index].Upgrades[i].slider.value += 1 * Time.deltaTime;

                    }
                }
                
            }
            UpgradesManager.Instance.UpdateUpgradeUI(type);
        }
    }
    private void ProduceHuman()
    {
        humanSlider.value += 1 * Time.deltaTime;
        if(humanSlider.value >= 1)
        {
            humanSlider.value = 0;
            data.humanAmount += data.humanPower * Produce();
        }
        
        
    }
    private BigDouble Produce()
    {
        BigDouble sum = 1;
        for (int i = 0; i < data.humanUpgradeLevels.Count; i++)
        {
            sum += data.humanUpgradeLevels[i] * 5;
        }
        return sum;
    }
    public void Click(string amountName)
    {
        switch (amountName)
        {
            case "Food":
                data.sectionAmounts[0] += data.clickPower[0] * data.productionMultiplier[0];
                break;
            case "Military":
                data.sectionAmounts[1] += data.clickPower[1] * data.productionMultiplier[1];
                break;
            case "Land":
                data.sectionAmounts[2] += data.clickPower[2] * data.productionMultiplier[2];
                break;
            case "Material":
                data.sectionAmounts[3] += data.clickPower[3] * data.productionMultiplier[3];
                break;
            default:
                break;
        }

    }

    private void UpdateText()
    {
        sectionText[0].text = $"Yiyecek\n{data.sectionAmounts[0].Notate()}";
        sectionText[1].text = $"Askeri\n{data.sectionAmounts[1].Notate()}";
        sectionText[2].text = $"Toprak\n{data.sectionAmounts[2].Notate()}";
        sectionText[3].text = $"Materyal\n{data.sectionAmounts[3].Notate()}";
        sectionText[4].text = $"Altın\n{data.gold.Notate()}";
        humanText.text = $"{data.humanAmount.Notate()}";
        for (int i = 0; i < data.clickPower.Length; i++)
        {
            clickTexts[i].text = $"+{(data.clickPower[i] * data.productionMultiplier[i]).Notate(3, 2)}";
        }
        for (int i = 0; i < UpgradesManager.Instance.newUpgradeHandlers.Length; i++)
        {
            sectionProductionTexts[i].text = $"Üretim: {(UpgradesManager.Instance.newUpgradeHandlers[i].UpgradesBasePower[0] * data.productionMultiplier[i] * data.Levels[i][0]).Notate(3,1)}/s";
        }
    }

    private void UpdateAchievements()
    {
        AchievementManager.Instance.UpdateUpgradeUI("Food");
        AchievementManager.Instance.UpdateUpgradeUI("Military");
        AchievementManager.Instance.UpdateUpgradeUI("Land");
        AchievementManager.Instance.UpdateUpgradeUI("Material");
    }
}
//private void PhoneClick()
//{
//    if (Input.touchCount > 0)
//    {
//        Touch touch = Input.GetTouch(0);

//        if (touch.phase == TouchPhase.Began && !EventSystem.current.IsPointerOverGameObject(0))
//        {
//            ShowClickText(false);
//            data.amounts[1] += ClickPower();
//            clickText.text = data.amounts[1].Notate();
//            clickSound.Play();
//        }
//    }
//}
//if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
//{
//    ShowClickText(true);

//    data.amounts[1] += ClickPower();
//    clickText.text = data.amounts[1].Notate();
//    clickSound.Play();
//}
//void ShowClickText(bool platform)
//{
//    Vector3 objPos = Camera.main.ScreenToWorldPoint(platform ? Input.mousePosition: Input.GetTouch(0).position);
//    GameObject go = Instantiate(clickTextPrefab, objPos, Quaternion.identity);
//    go.transform.SetParent(clickTextCanvas.transform, false);
//    go.transform.position = Input.mousePosition;
//}
//void UnlockAges()
//{
//    if (data.amounts[1] >= data.lockRequires[0])
//    {
//        data.lockPanels[2] = true;
//    }
//    if (data.amounts[1] >= data.lockRequires[1])
//    {
//        data.lockPanels[3] = true;
//    }
//    if (data.amounts[2] >= data.lockRequires[2])
//    {
//        data.lockPanels[4] = true;
//    }
//    if (data.amounts[3] >= data.lockRequires[3])
//    {
//        data.lockPanels[5] = true;
//    }
//    //lockRequires = new BigDouble[] { 1000,5000000,1000000000, 999999999999999 };
//    //amounts = new BigDouble[] { 0, 0, 0, 0, 0 }; // 0-diamond 1-Food 2-Gold 3-machine 4-chip

//}