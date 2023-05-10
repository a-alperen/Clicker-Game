using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Panels")]
    public GameObject settingsPanel;
    public GameObject mainSettingsPanel;
    public GameObject soundPanel;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowSettingsPanel()
    {
        settingsPanel.SetActive(true);
    }
    public void HideSettingsPanel()
    {
        settingsPanel.SetActive(false);
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
        Application.Quit();
    }
}
