using UnityEngine;
using TMPro;
public class Settings : MonoBehaviour
{
    public static Settings Instance { get; private set; }

    public string[] notationNames;
    public string[] buyMultiplierNames;

    public TextMeshProUGUI[] settingText;
    private void Awake()
    {
        Instance = this;
    }
    public void StartSettings()
    {
        notationNames = new string[] { "Standart", "Scientific","Engineering", "Log" };
        buyMultiplierNames = new string[] { "x1","x10","x25","x100" };
        Methods.notation = Controller.Instance.data.notation;
        SyncSetting();
    }
    public void ChangeSetting(string settingName)
    {
        var data = Controller.Instance.data;
        switch (settingName)
        {
            case "Notation":
                data.notation++;
                if (data.notation > notationNames.Length - 1) data.notation = 0;
                Methods.notation = data.notation;
                break;
            case "Buy":
                data.notationBuyMultiplier++;
                if (data.notationBuyMultiplier >= buyMultiplierNames.Length) data.notationBuyMultiplier = 0;
                break;
            default:
                break;
        }

        SyncSetting(settingName);

        UpgradesManager.Instance.UpdateUpgradeUI("Food");
        UpgradesManager.Instance.UpdateUpgradeUI("Military");
        UpgradesManager.Instance.UpdateUpgradeUI("Land");
        UpgradesManager.Instance.UpdateUpgradeUI("Material");


    }
    public void SyncSetting(string settingName = "")
    {
        if(settingName == string.Empty)
        {
            settingText[0].text = $"Notation:\n{notationNames[Methods.notation]}";
            settingText[1].text = $"{buyMultiplierNames[Controller.Instance.data.notationBuyMultiplier]}";
            return;
        }

        switch (settingName)
        {
            case "Notation":
                settingText[0].text = $"Notation:\n{notationNames[Methods.notation]}";
                break;
            case "Buy":
                settingText[1].text = $"{buyMultiplierNames[Controller.Instance.data.notationBuyMultiplier]}";
                break;
            default:
                break;
        }
    }

}
