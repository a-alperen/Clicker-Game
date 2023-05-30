using TMPro;
using UnityEngine;
using BreakInfinity;
using System.Linq;

public class PrestigeManager : MonoBehaviour
{
    public static PrestigeManager Instance { get; private set; }
    
    public GameObject prestigeConfirmationPanel;
    private void Awake()
    {
        Instance = this;
    }
    private void Update()
    {
        
    }
    public BigDouble PrestigeGains()
    {
        return BigDouble.Sqrt(Controller.Instance.data.sectionAmounts[1] / (BigDouble)1000);
    }
    public BigDouble PrestigeEffect()
    {
        return Controller.Instance.data.sectionAmounts[0] / 100 + 1;
    }
    public void TogglePrestigeConfirm()
    {
        prestigeConfirmationPanel.SetActive(!prestigeConfirmationPanel.activeSelf);
    }
    public void Prestige()
    {
        var data = Controller.Instance.data;
        data.sectionAmounts[0] += PrestigeGains();

        data.sectionAmounts[1] = 0;
        data.sectionAmounts[2] = 0;
        data.sectionAmounts[3] = 0;
        data.sectionAmounts[4] = 0;

        data.lockPanels = new bool[] { true, true, false, false, false, false };

        TogglePrestigeConfirm();
    }
}
