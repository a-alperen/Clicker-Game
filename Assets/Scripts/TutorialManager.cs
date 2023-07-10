using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{
    [SerializeField] private GameObject[] tutorialPanels;
    [SerializeField] private TextMeshProUGUI descriptionText;
    [SerializeField] private GameObject tutorialPanel;
    [SerializeField] private TextMeshProUGUI buttonText;
    [SerializeField] private Sprite tutorialSprite;
    [SerializeField] private Sprite goldSectionSprite;
    private string[] tutorialPanelsDescription;
    int currentPanelIndex = 1;
    
    void Start()
    {
        tutorialPanelsDescription = new string[] {
            "SEKTÖRLERİN OLDUĞU KISIM BURADA GÖZÜKÜR. GELİŞTİRMELER VE ÜRETİM BURADA YAPILIR.",
            "BURADA BAŞLANGIÇTA KAYNAK ÜRETİMİ YAPACAĞIN BUTON VE HER SANİYE YAPTIĞIN ÜRETİMİN MİKTARI VAR.",
            "BURADA SENİN İÇİN SÜREKLİ KAYNAK ÜRETİMİ YAPMANI SAĞLAYACAK OLAN SEKTÖR GELİŞTİRMELERİ VAR.",
            "BURADA GELİŞTİRMELERİN MALİYETİ GÖSTERİLİR. SATIN ALMA MALİYETİNİ GÖRMEK İÇİN GELİŞTİRMENİN ÜZERİNE TIKLAMAN YETERLİ.",
            "ÜST KISIM İNSAN ÜRETİMİ, ALT KISIMDA ÜRETİMLE ELDE EDİLEN BAŞARIM,ÇOKLU ALIM BUTONU VE PRESTİJ BUTONU YER ALIR. PRESTİJ İLE HER SEFERİNDE GENEL ÜRETİM GÜCÜNDE ARTIŞ MEYDANA GELİR VE SÜREÇ SIFIRLANIR.",
            "BU KISIMDA OYUNDA SEKTÖRLER ARASI GEÇİŞ YAPARSIN.",
            "ALTIN SEKMESİNİN DİĞERLERİNDEN FARKI, BU KAYNAK PRESTİJ YAPILARAK ELDE EDİLİR VE BURADA YAPILAN ÜRETİM GELİŞTİRMELERİ KALICIDIR.",
            "BU KISIMDA İNSAN ÜRETİMİNİN GELİŞTİRMESİ YAPILMAKTADIR. HER PRESJTİJ SONRASI BURASI SIFIRLANIR.",
            "BU KISIMDA YİYECEK/ASKERİ/TOPRAK/MATERYAL SEKTÖRLERİNİN KALICI ÜRETİM GELİŞTİRMESİ YAPILMAKTADIR. PRESTİJ SONRASI BURASI SIFIRLANMAZ.",
            
        };
        tutorialPanels[0].SetActive(true);
        descriptionText.text = tutorialPanelsDescription[0];
        if (PlayerPrefs.GetInt("Tutorial") == 1) tutorialPanel.SetActive(false);
        else tutorialPanel.SetActive(true);
    }

    public void ShowPanel()
    {
        if(currentPanelIndex < tutorialPanels.Length)
        {
            tutorialPanels[currentPanelIndex - 1].SetActive(false);
            tutorialPanels[currentPanelIndex].SetActive(true);
            descriptionText.text = tutorialPanelsDescription[currentPanelIndex];
            if (currentPanelIndex == 7) tutorialPanel.GetComponent<Image>().sprite = goldSectionSprite;
            if (currentPanelIndex == tutorialPanels.Length - 1) buttonText.text = "TAMAMDIR";
            currentPanelIndex += 1;
        }
        else
        {
            tutorialPanel.SetActive(false);
            tutorialPanels[0].SetActive(true);
            tutorialPanel.GetComponent<Image>().sprite = tutorialSprite;
            for (int i = 1; i < tutorialPanels.Length; i++)
            {
                tutorialPanels[i].SetActive(false);
            }
            descriptionText.text = tutorialPanelsDescription[0];
            currentPanelIndex = 1;
            buttonText.text = "SONRAKİ";
            PlayerPrefs.SetInt("Tutorial", 1);
        }
        
    }
    public void ShowTutorial()
    {
        tutorialPanel.SetActive(true);
    }
}
