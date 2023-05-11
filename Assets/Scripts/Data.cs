using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using BreakInfinity;
using System;

[Serializable]
public class Data
{
    public BigDouble Diamond;
    public BigDouble Food;
    public BigDouble Gold;
    public BigDouble Machine;
    public BigDouble Chip;
    public bool[] lockAges;
    public BigDouble[] lockRequires;

    public List<int> ClickUpgradeLevels;
    public List<int> FirstAgeProductionUpgradeLevels;
    public List<int> SecondAgeProductionUpgradeLevels;
    public List<int> ThirdAgeProductionUpgradeLevels;
    public List<int> FourthAgeProductionUpgradeLevels;

    public int notation;
    
    public Data()
    {
        Diamond = 0;
        Food = 0;
        Gold = 0;
        Machine = 0;
        Chip = 0;
        lockAges = new bool[] { true, false, false, false, false, false };
        lockRequires = new BigDouble[] { -1,0,1000,5000000,1000000000, 999999999999999};
        ClickUpgradeLevels = new int[12].ToList();
        FirstAgeProductionUpgradeLevels = new int[8].ToList();

        notation = 0;
    }

}
