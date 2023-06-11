using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using BreakInfinity;
using UnityEngine.UI;
using UnityEditor;
using System;
using System.Reflection;

public class Controller : MonoBehaviour
{

    public static Controller Instance { get; private set; }

    private const string dataFileName = "PlayerData";
    private TimeSpan offlineTime;
    private int offlineSeconds;
    private BigDouble[] offlineProduction = new BigDouble[] { 0, 0, 0, 0 };
    private BigDouble offlineHumanProduction = 0;
    public Data data;
    [Header("Value Texts")]
    [SerializeField] private TextMeshProUGUI[] sectionText;
    [SerializeField] private TextMeshProUGUI[] offlinePanelTexts;
    [Header("Other Things")]
    [SerializeField] private TextMeshProUGUI humanText;
    [SerializeField] private Slider humanSlider;
    [SerializeField] private GameObject offlineIncomePanel;
    //public AudioSource clickSound;

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

        UpgradesManager.Instance.StartUpgradeManager();
        Settings.Instance.StartSettings();
        AchievementManager.Instance.StartAchievementManager();
        offlineIncomePanel.SetActive(true);
        OfflineEarning();

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
        offlineHumanProduction = 1 * offlineSeconds;
        data.humanAmount += offlineHumanProduction;

        offlinePanelTexts[0].text = $"{offlineProduction[0].Notate(3, offlineProduction[0] >= 1e3 ? 2 : 0)}";
        offlinePanelTexts[1].text = $"{offlineProduction[1].Notate(3, offlineProduction[1] >= 1e3 ? 2 : 0)}";
        offlinePanelTexts[2].text = $"{offlineProduction[2].Notate(3, offlineProduction[2] >= 1e3 ? 2 : 0)}";
        offlinePanelTexts[3].text = $"{offlineProduction[3].Notate(3, offlineProduction[3] >= 1e3 ? 2 : 0)}";
        offlinePanelTexts[4].text = $"{offlineHumanProduction.Notate(3, offlineHumanProduction >= 1e3 ? 2 : 0)}";
        
    }
    public void AddOfflineIncome(GameObject panel)
    {
        for (int i = 0; i < 4; i++)
        {
            data.sectionAmounts[i] += offlineProduction[i];
        }
        panel.SetActive(false);
    }
    public void Production()
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
                        if (i == 0) data.sectionAmounts[index] += data.Levels[index][i] * upgradeHandler[index].UpgradesBasePower[i] * data.productionMultiplier[index];
                        else data.Levels[index][i - 1] += data.Levels[index][i] * upgradeHandler[index].UpgradesBasePower[i];
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
    public void ProduceHuman()
    {
        humanSlider.value += 1 * Time.deltaTime;
        if(humanSlider.value >= 1)
        {
            humanSlider.value = 0;
            data.humanAmount += 1;
        }    
    }
    public void Click(string amountName)
    {
        switch (amountName)
        {
            case "Food":
                data.sectionAmounts[0] += 1;
                break;
            case "Military":
                data.sectionAmounts[1] += 1;
                break;
            case "Land":
                data.sectionAmounts[2] += 1;
                break;
            case "Material":
                data.sectionAmounts[3] += 1;
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
        humanText.text = $"{data.humanAmount.Notate(3,data.humanAmount >= 1e3 ? 2:0)}";
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