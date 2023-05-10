using UnityEngine;
using TMPro;
public class Settings : MonoBehaviour
{
    public static Settings Instance { get; private set; }

    public string[] notationNames;

    public TextMeshProUGUI[] settingText;
    private void Awake()
    {
        Instance = this;
    }
    public void StartSettings()
    {
        notationNames = new string[] { "Standart", "Scientific","Engineering", "Log" };
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

            default:
                break;
        }

        SyncSetting(settingName);

        UpgradesManager.Instance.UpdateUpgradeUI("Click");
        UpgradesManager.Instance.UpdateUpgradeUI("FirstAge");
        //UpgradesManager.Instance.UpdateUpgradeUI("SecondAge");
        //UpgradesManager.Instance.UpdateUpgradeUI("ThirdAge");
        //UpgradesManager.Instance.UpdateUpgradeUI("FourthAge");

    }
    public void SyncSetting(string settingName = "")
    {
        if(settingName == string.Empty)
        {
            settingText[0].text = $"Notation:\n{notationNames[Methods.notation]}";
            return;
        }

        switch (settingName)
        {
            case "Notation":
                settingText[0].text = $"Notation:\n{notationNames[Methods.notation]}";
                break;

            default:
                break;
        }
    }
}
