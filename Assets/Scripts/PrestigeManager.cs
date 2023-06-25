using TMPro;
using UnityEngine;
using BreakInfinity;
using UnityEngine.UI;

public class PrestigeManager : MonoBehaviour
{
    public static PrestigeManager Instance { get; private set; }
    
    [SerializeField] private GameObject prestigeConfirmationPanel;
    [SerializeField] private TextMeshProUGUI gainsText;

    [Header("Human Upgrade UI Elements")]
    [SerializeField] private TextMeshProUGUI[] humanUpgradeProgressTexts;
    [SerializeField] private Slider[] humanUpgradeProgressSlider;
    [SerializeField] private Button[] humanUpgradeButton;
    private void Awake()
    {
        Instance = this;
    }
    private void Update()
    {
        UpdateUI();
    }
    private BigDouble PrestigeGains()
    {
        BigDouble gold = 0;
        for(int i = 0; i < Controller.Instance.data.sectionAmounts.Length; i++)
        {
            gold += BigDouble.Sqrt(Controller.Instance.data.sectionAmounts[i] / (BigDouble)1000);
        }
        return gold;
    }
    public BigDouble PrestigeEffect()
    {
        return BigDouble.Sqrt(PrestigeGains() / (BigDouble)10000) + 1;
    }
    public void TogglePrestigeConfirm()
    {
        gainsText.text = $"Altın: {PrestigeGains().Notate()}\nTıklama başına üretim: x{PrestigeEffect().Notate()}";
        prestigeConfirmationPanel.SetActive(!prestigeConfirmationPanel.activeSelf);
    }
    public void Prestige()
    {
        var data = Controller.Instance.data;
        TogglePrestigeConfirm();

        data.gold = PrestigeGains();
        for (int i = 0; i < data.clickPower.Length; i++)
        {
            data.clickPower[i] *= PrestigeEffect();
        }
        for (int i = 0; i < data.sectionAmounts.Length; i++)
        {
            data.sectionAmounts[i] = 0;
            for (int j = 0; j < data.Levels[i].Count; j++)
            {
                data.Levels[i][j] = 0;
            }
        }
        for (int i = 0; i < data.humanUpgradeLevels.Count; i++)
        {
            data.humanUpgradeLevels[i] = 0;
            data.humanUpgradeRequires[i] = 1000;
        }
        data.humanAmount = 0;
    }
    public void BuyHumanUpgrade(int id)
    {
        var data = Controller.Instance.data;
        if (data.sectionAmounts[id] >= data.humanUpgradeRequires[id])
        {
            data.sectionAmounts[id] -= data.humanUpgradeRequires[id];
            data.humanUpgradeLevels[id] += 1;
            data.humanUpgradeRequires[id] *= 10;
            humanUpgradeProgressSlider[id].value = 0;
            humanUpgradeButton[id].interactable = false;
        }
    }
    private void UpdateUI()
    {
        var data = Controller.Instance.data;
        for (int i = 0; i < humanUpgradeProgressTexts.Length; i++)
        {
            humanUpgradeProgressTexts[i].text = $"{(data.sectionAmounts[i] >= data.humanUpgradeRequires[i] ? data.humanUpgradeRequires[i]: data.sectionAmounts[i]).Notate(3,1)} / {data.humanUpgradeRequires[i].Notate(3,0)}";
            humanUpgradeProgressSlider[i].value = (float)(data.sectionAmounts[i] / data.humanUpgradeRequires[i]);
            if(humanUpgradeProgressSlider[i].value == 1) humanUpgradeButton[i].interactable = true;
            else humanUpgradeButton[i].interactable = false;
        }
    }
}
