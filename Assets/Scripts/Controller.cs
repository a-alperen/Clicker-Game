using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using BreakInfinity;

public class Controller : MonoBehaviour
{

    public static Controller Instance { get; private set; }

    public Data data;
    
    [SerializeField] private TextMeshProUGUI clickText;
    [SerializeField] private TextMeshProUGUI productionText;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        data = new Data();
        UpgradesManager.Instance.StartUpgradeManager();
    }

    // Update is called once per frame
    void Update()
    {
        productionText.text = $"{ProductionPerSecond():F2}/s";
        clickText.text = $"{data.Food:F2} Yiyecek";
        data.Food += ProductionPerSecond() * Time.deltaTime;

#if UNITY_EDITOR
        ComputerClick();
#else
        PhoneClick();
        
#endif
    }

    public BigDouble ClickPower()
    {
        BigDouble total = 1;
        for (int i = 0; i < data.ClickUpgradeLevels.Count; i++)
            total += UpgradesManager.Instance.clickUpgradesBasePower[i] * data.ClickUpgradeLevels[i];
        
        return total;
    }
    public BigDouble ProductionPerSecond()
    {
        BigDouble total = 0;
        for (int i = 0; i < data.ProductionUpgradeLevels.Count; i++)
            total += UpgradesManager.Instance.productionUpgradesBasePower[i] * data.ProductionUpgradeLevels[i];

        return total;
    }

    private void PhoneClick()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            
            if (touch.phase == TouchPhase.Began && !EventSystem.current.IsPointerOverGameObject(0))
            {
                data.Food += ClickPower();
                clickText.text = data.Food.ToString("F2");
            }
        }
    }

    private void ComputerClick()
    {
        
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            data.Food += ClickPower();
            clickText.text = data.Food.ToString("F2");
            
        }
    }

}
