using System.Collections;
using System.Collections.Generic;
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
        prestigeCurrencyText.text = $"{Controller.Instance.data.Diamond.Notate()} Elmas";
    }
    public BigDouble PrestigeGains()
    {
        return BigDouble.Sqrt(Controller.Instance.data.Food / (BigDouble)1000);
    }
    public BigDouble PrestigeEffect()
    {
        return Controller.Instance.data.Diamond / 100 + 1;
    }
    public void TogglePrestigeConfirm()
    {
        prestigeConfirmationPanel.SetActive(!prestigeConfirmationPanel.activeSelf);
    }
    public void Prestige()
    {
        Controller.Instance.data.Diamond += PrestigeGains();

        Controller.Instance.data.Food = 0;

        Controller.Instance.data.ClickUpgradeLevels = new int[12].ToList();
        Controller.Instance.data.FirstAgeProductionUpgradeLevels = new int[8].ToList();

        UpgradesManager.Instance.UpdateUpgradeUI("Click");
        UpgradesManager.Instance.UpdateUpgradeUI("FirstAge");
        //UpgradesManager.Instance.UpdateUpgradeUI("SecondAge");
        //UpgradesManager.Instance.UpdateUpgradeUI("ThirdAge");
        //UpgradesManager.Instance.UpdateUpgradeUI("FourthAge");

        

        TogglePrestigeConfirm();
    }
}
