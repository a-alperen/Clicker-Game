using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Panels")]
    public GameObject mainSettingsPanel;
    public GameObject soundPanel;
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
    }
    
    public void ResetData()
    {
        Controller.Instance.data = new Data(); 
    }
    public void ShowPanel(GameObject panel)
    {
        panel.SetActive(true);
    }
    public void HidePanel(GameObject panel)
    {
        panel.SetActive(false);
    }
    public void ShowSoundPanel()
    {
        soundPanel.SetActive(true);
        mainSettingsPanel.SetActive(false);
    }
    public void HideSoundPanel()
    {
        soundPanel.SetActive(false);
        mainSettingsPanel.SetActive(true);
    }
    public void QuitGame()
    {
        SaveSystem.SaveData(Controller.Instance.data, "PlayerData");
        Application.Quit();
    }
}
