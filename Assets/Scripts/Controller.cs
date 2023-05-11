using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using BreakInfinity;

public class Controller : MonoBehaviour
{

    public static Controller Instance { get; private set; }

    private const string dataFileName = "PlayerData";

    public Data data;

    [SerializeField] private TextMeshProUGUI clickText;
    [SerializeField] private TextMeshProUGUI productionText;
    public GameObject clickTextPrefab;
    public Canvas clickTextCanvas;

    public AudioSource clickSound;
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
#if UNITY_EDITOR
        ComputerClick();
#else
        PhoneClick();
        
#endif

        productionText.text = $"{ProductionPerSecond():F2}/s";
        clickText.text = $"{data.Food.Notate()} Yiyecek";
        data.Food += ProductionPerSecond() * Time.deltaTime;

        SaveTime += Time.deltaTime * (1 / Time.timeScale);

        if(SaveTime >= 15)
        {
            SaveSystem.SaveData(data, dataFileName);
            SaveTime = 0;
        }

        UnlockAges();
    }

    public BigDouble ClickPower()
    {
        BigDouble total = 1;
        for (int i = 0; i < data.ClickUpgradeLevels.Count; i++)
            total += UpgradesManager.Instance.upgradeHandlers[0].UpgradesBasePower[i] * data.ClickUpgradeLevels[i];
        
        return total * PrestigeManager.Instance.PrestigeEffect();
    }
    public BigDouble ProductionPerSecond()
    {
        BigDouble total = 0;
        for (int i = 0; i < data.FirstAgeProductionUpgradeLevels.Count; i++)
            total += UpgradesManager.Instance.upgradeHandlers[1].UpgradesBasePower[i] * data.FirstAgeProductionUpgradeLevels[i];

        return total * PrestigeManager.Instance.PrestigeEffect();
    }

    private void PhoneClick()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            
            if (touch.phase == TouchPhase.Began && !EventSystem.current.IsPointerOverGameObject(0))
            {
                ShowClickText(false);
                data.Food += ClickPower();
                clickText.text = data.Food.ToString("F2");
                clickSound.Play();
            }
        }
    }

    private void ComputerClick()
    {
        
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            ShowClickText(true);

            data.Food += ClickPower();
            clickText.text = data.Food.ToString("F2");
            clickSound.Play();
        }
    }

    void ShowClickText(bool platform)
    {
        Vector3 objPos = Camera.main.ScreenToWorldPoint(platform ? Input.mousePosition: Input.GetTouch(0).position);
        GameObject go = Instantiate(clickTextPrefab, objPos, Quaternion.identity);
        go.transform.SetParent(clickTextCanvas.transform, false);
        go.transform.position = Input.mousePosition;
    }

    void UnlockAges()
    {
        BigDouble[] amount = new BigDouble[] { data.Diamond, 0, data.Food, data.Gold, data.Machine, data.Chip };
        for (int i = 1; i < UpgradesManager.Instance.upgradeHandlers.Length; i++)
        {
            if (amount[i] >= data.lockRequires[i]) data.lockAges[i] = true;
        }
    }
}
