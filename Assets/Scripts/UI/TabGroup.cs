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
        
        if (selectedTab != null) selectedTab.Deselect();

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

}