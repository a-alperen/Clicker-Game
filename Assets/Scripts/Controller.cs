using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using BreakInfinity;

public class Controller : MonoBehaviour
{

    public static Controller Instance { get; private set; }

    private const string dataFileName = "PlayerData";

    public Data data;
    [Header("Value Texts")]
    [SerializeField] private TextMeshProUGUI[] sectionText;
    [SerializeField] private TextMeshProUGUI humanText;
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

        
    }

    public float SaveTime;

    // Update is called once per frame
    void Update()
    {
        UpdateText();
        ProduceHuman();
        Production();

        SaveTime += Time.deltaTime * (1 / Time.timeScale);

        if(SaveTime >= 15)
        {
            SaveSystem.SaveData(data, dataFileName);
            SaveTime = 0;
        }
        
    }

    //public BigDouble ClickPower()
    //{
    //    BigDouble total = 1;
    //    for (int i = 0; i < data.ClickUpgradeLevels.Count; i++)
    //        total += UpgradesManager.Instance.upgradeHandlers[0].UpgradesBasePower[i] * data.ClickUpgradeLevels[i];
        
    //    return total;
    //}
    //public BigDouble ProductionPerSecond()
    //{
    //    BigDouble total = 0;
    //    for (int i = 0; i < data.FirstAgeProductionUpgradeLevels.Count; i++)
    //        total += UpgradesManager.Instance.upgradeHandlers[1].UpgradesBasePower[i] * data.FirstAgeProductionUpgradeLevels[i];

    //    return total;
    //}
    public void Production()
    {
        Produce("Food",0);
        Produce("Military", 1);
        Produce("Land", 2);
        Produce("Material", 3);

        void Produce(string type, int index)
        {
            for (int i = 0; i < data.Levels[index].Count; i++)
            {
                if (i == 0) data.sectionAmounts[index] += data.Levels[index][i] * UpgradesManager.Instance.newUpgradeHandlers[index].UpgradesBasePower[i] * Time.deltaTime;
                else data.Levels[index][i - 1] += data.Levels[index][i] * UpgradesManager.Instance.newUpgradeHandlers[index].UpgradesBasePower[i] * Time.deltaTime;
            }
            UpgradesManager.Instance.UpdateUpgradeUI(type);
        }
    }
    public void ProduceHuman()
    {
        data.humanAmount += 1 * Time.deltaTime;
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
        humanText.text = $"{data.humanAmount.Notate(3,0)}";
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