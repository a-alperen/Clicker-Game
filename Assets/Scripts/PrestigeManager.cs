using TMPro;
using UnityEngine;
using BreakInfinity;
using System.Linq;

public class PrestigeManager : MonoBehaviour
{
    public static PrestigeManager Instance { get; private set; }

    public TextMeshProUGUI prestigeGainText;
    public TextMeshProUGUI prestigeCurrencyText;

    public GameObject prestigeConfirmationPanel;
    private void Awake()
    {
        Instance = this;
    }
    private void Update()
    {
        prestigeGainText.text = $"Prestij:\n+{PrestigeGains().Notate()} Elmas";
        prestigeCurrencyText.text = $"{Controller.Instance.data.amounts[0].Notate()} Elmas";
    }
    public BigDouble PrestigeGains()
    {
        return BigDouble.Sqrt(Controller.Instance.data.amounts[1] / (BigDouble)1000);
    }
    public BigDouble PrestigeEffect()
    {
        return Controller.Instance.data.amounts[0] / 100 + 1;
    }
    public void TogglePrestigeConfirm()
    {
        prestigeConfirmationPanel.SetActive(!prestigeConfirmationPanel.activeSelf);
    }
    public void Prestige()
    {
        var data = Controller.Instance.data;
        data.amounts[0] += PrestigeGains();

        data.amounts[1] = 0;
        data.amounts[2] = 0;
        data.amounts[3] = 0;
        data.amounts[4] = 0;

        data.ClickUpgradeLevels = new int[12].ToList();
        data.FirstAgeProductionUpgradeLevels = new int[8].ToList();
        data.lockPanels = new bool[] { true, true, false, false, false, false };

        UpgradesManager.Instance.UpdateUpgradeUI("Click");
        UpgradesManager.Instance.UpdateUpgradeUI("FirstAge");
        UpgradesManager.Instance.UpgradeLockSystem(0);
        UpgradesManager.Instance.UpgradeLockSystem(1);

        //UpgradesManager.Instance.UpdateUpgradeUI("SecondAge");
        //UpgradesManager.Instance.UpdateUpgradeUI("ThirdAge");
        //UpgradesManager.Instance.UpdateUpgradeUI("FourthAge");

        TogglePrestigeConfirm();
    }
}
