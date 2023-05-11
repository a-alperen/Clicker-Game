using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TabGroup : MonoBehaviour
{
    public List<TabButton> tabButtons;
    public Sprite tabIdle;
    public Sprite tabHover;
    public Sprite tabActive;
    public TabButton selectedTab;
    public List<GameObject> objectsToSwap;
    public List<Sprite> ageSprites;
    public List<Image> ageImages;
    public GameObject lockPanel;
    public Image lockPanelImage;
    public TextMeshProUGUI requirementText;
    private void Start()
    {

    }
    private void Update()
    {
        //Unlock();
    }
    public void Subscribe(TabButton button)
    {
        tabButtons ??= new List<TabButton>();

        tabButtons.Add(button);
    }

    public void OnTabEnter(TabButton button)
    {
        ResetTabs();
        button.background.sprite = tabHover;
    }

    public void OnTabExit(TabButton button)
    {
        ResetTabs();
    }

    public void OnTabSelected(TabButton button)
    {
        if(selectedTab != null) selectedTab.Deselect();

        selectedTab = button;

        selectedTab.Select();

        ResetTabs();
        button.background.sprite = tabActive;
        int index = button.transform.GetSiblingIndex();
        Unlock(button);

        for (int i = 0;i < objectsToSwap.Count; i++)
        {
            lockPanel.SetActive(!Controller.Instance.data.lockAges[index]);
            
            if (i == index && Controller.Instance.data.lockAges[i])
            {
                objectsToSwap[i].SetActive(true);
                
            }
            else
            {
                objectsToSwap[i].SetActive(false);
                
            }

        }
    }

    public void ResetTabs()
    {
        foreach(TabButton button in tabButtons)
        {
            if (selectedTab != null && selectedTab == button) continue;
            button.background.sprite = tabIdle;
        }
    }

    void Unlock(TabButton button)
    {

        int index = button.transform.GetSiblingIndex();
        var data = Controller.Instance.data;
        for (int i = 0; i < data.lockAges.Length; i++)
        {
            lockPanelImage.sprite = ageSprites[index == 0 ? 0: index-1];
            requirementText.text = Controller.Instance.data.lockRequires[index].Notate();
            if (data.lockAges[i])
            {
                ageImages[i].sprite = ageSprites[i];
                
            }
        }
    }
}
