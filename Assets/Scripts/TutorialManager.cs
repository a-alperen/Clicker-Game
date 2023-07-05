using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{
    [SerializeField] private GameObject[] tutorialPanels;
    [SerializeField] private GameObject[] arrows; 
    [SerializeField] private TextMeshProUGUI descriptionText;
    [SerializeField] private GameObject tutorialPanel;
    [SerializeField] private TextMeshProUGUI buttonText;
    private string[] tutorialPanelsDescription;
    int currentPanelIndex = 1;
    // Start is called before the first frame update
    void Start()
    {
        tutorialPanelsDescription = new string[] {
            "BU KISIMDA OYUNDA SEKTÖRLER ARASI GEÇİŞ YAPARSIN.",
            "SEKTÖRLERİN OLDUĞU KISIM BURADA GÖZÜKÜR. GELİŞTİRMELER VE ÜRETİM BURADA YAPILIR.",
            "BURADA GELİŞTİRMELERİN MALİYETİ GÖSTERİLİR.",
            "ÜST KISIM İNSAN ÜRETİMİ, ALT KISIMDA ÜRETİMLE ELDE EDİLEN BAŞARIM,ÇOKLU ALIM BUTONU VE PRESTİJ BUTONU YER ALIR. PRESTİJ İLE HER SEFERİNDE GENEL ÜRETİM GÜCÜNDE ARTIŞ MEYDANA GELİR VE SÜREÇ SIFIRLANIR.",
        };
        tutorialPanels[0].SetActive(true);
        arrows[0].SetActive(true);
        descriptionText.text = tutorialPanelsDescription[0];
        arrows[0].SetActive(true);
        if (PlayerPrefs.GetInt("Tutorial") == 1) tutorialPanel.SetActive(false);
        else tutorialPanel.SetActive(true);
    }

    public void ShowPanel()
    {
        if(currentPanelIndex < tutorialPanels.Length)
        {
            tutorialPanels[currentPanelIndex - 1].SetActive(false);
            tutorialPanels[currentPanelIndex].SetActive(true);
            arrows[currentPanelIndex - 1].SetActive(false);
            arrows[currentPanelIndex].SetActive(true);
            descriptionText.text = tutorialPanelsDescription[currentPanelIndex];

            if (currentPanelIndex == 3) buttonText.text = "TAMAMDIR";
        }
        else
        {
            tutorialPanel.SetActive(false);
            PlayerPrefs.SetInt("Tutorial", 1);
        }
        currentPanelIndex += 1;
    }
}
