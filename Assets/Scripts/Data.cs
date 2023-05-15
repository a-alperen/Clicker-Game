using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using BreakInfinity;
using System;

[Serializable]
public class Data
{
    
    public BigDouble[] amounts;
    public bool[] lockPanels;
    public BigDouble[] lockRequires;

    public List<int> ClickUpgradeLevels;
    public List<int> FirstAgeProductionUpgradeLevels;
    public List<int> SecondAgeProductionUpgradeLevels;
    public List<int> ThirdAgeProductionUpgradeLevels;
    public List<int> FourthAgeProductionUpgradeLevels;

    public int notation;
    
    public Data()
    {
        amounts = new BigDouble[] { 0,0,0,0,0 }; // 0-diamond 1-Food 2-Gold 3-machine 4-chip
        
        lockPanels = new bool[] { true, true, false, false, false, false };
        lockRequires = new BigDouble[] { 1000,5000000,1000000000, 999999999999999 };
        ClickUpgradeLevels = new int[12].ToList();
        FirstAgeProductionUpgradeLevels = new int[8].ToList();

        notation = 0;
    }

}
