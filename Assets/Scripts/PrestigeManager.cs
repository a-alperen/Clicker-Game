using TMPro;
using UnityEngine;
using BreakInfinity;
using System.Linq;

public class PrestigeManager : MonoBehaviour
{
    public static PrestigeManager Instance { get; private set; }
    
    [SerializeField] private GameObject prestigeConfirmationPanel;
    [SerializeField] private TextMeshProUGUI gainsText;
    private void Awake()
    {
        Instance = this;
    }
    private void Update()
    {
        
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
        data.humanAmount = 0;
    }
}
