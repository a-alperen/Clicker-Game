using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{

    [SerializeField] private GameObject upgradesPanel;
    [SerializeField] private Button upgradesPanelButton;

    public Sprite buttonOpenImage;
    public Sprite buttonCloseImage;

    [SerializeField] private bool isShow;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowUpgradePanel()
    {
        if (!isShow)
        {
            isShow = true;
            upgradesPanel.GetComponent<Animator>().Play("UpgradesPanelOpen");
            upgradesPanelButton.GetComponent<Image>().sprite = buttonCloseImage;
        }
        else
        {
            isShow = false;
            upgradesPanel.GetComponent<Animator>().Play("UpgradesPanelClose");
            upgradesPanelButton.GetComponent<Image>().sprite =buttonOpenImage;
        }
    }
}
