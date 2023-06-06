using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TabGroup : MonoBehaviour
{
    public List<TabButton> tabButtons;
    public Sprite tabIdle;
    //public Sprite tabHover;
    public Sprite tabActive;
    public TabButton selectedTab;
    public List<GameObject> objectsToSwap;          // Panellerin tutuldugu degisken

    
    public void Subscribe(TabButton button)
    {
        tabButtons ??= new List<TabButton>();

        tabButtons.Add(button);
    }

    //public void OnTabEnter(TabButton button)
    //{
    //    ResetTabs();
    //    button.background.sprite = tabHover;
    //}

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

        for (int i = 0;i < objectsToSwap.Count; i++)
        {
            
            if (i == index)
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


    //void UnlockAges()
    //{
    //    var data = Controller.Instance.data;
    //    if (data.amounts[1] >= data.lockRequires[0])
    //    {
    //        data.lockPanels[2] = true;
    //    }
    //    if (data.amounts[1] >= data.lockRequires[1])
    //    {
    //        data.lockPanels[3] = true;
    //    }
    //    if (data.amounts[2] >= data.lockRequires[2])
    //    {
    //        data.lockPanels[4] = true;
    //    }
    //    if (data.amounts[3] >= data.lockRequires[3])
    //    {
    //        data.lockPanels[5] = true;
    //    }
    //    //lockRequires = new BigDouble[] { 1000,5000000,1000000000, 999999999999999 };
    //    //amounts = new BigDouble[] { 0, 0, 0, 0, 0 }; // 0-diamond 1-Food 2-Gold 3-machine 4-chip

    //}

}
//void PanelsSmallImage()
//{
//    var data = Controller.Instance.data;
//    for (int i = 2; i < data.lockPanels.Length; i++)
//    {
//        if (data.lockPanels[i]) ageImages[i - 2].sprite = ageSprites[i - 2];
//        else ageImages[i - 2].sprite = lockSprite;
//    }
//}
//void Unlock(TabButton button)
//{

//    int index = button.transform.GetSiblingIndex();
//    var data = Controller.Instance.data;
//    for (int i = 0; i < data.lockPanels.Length; i++)
//    {
//        lockPanelImage.sprite = ageSprites[index - 3 < 0 ? 0 : index - 3];
//        requirementText.text = Controller.Instance.data.lockRequires[index-2 < 0 ? 0 : index-2].Notate();

//    }
//}