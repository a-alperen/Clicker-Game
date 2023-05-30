using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using BreakInfinity;
using System;

[Serializable]
public class Data
{
    
    public BigDouble[] sectionAmounts;
    public BigDouble humanAmount;
    public bool[] lockPanels;
    public BigDouble[] lockRequires;

    public List<BigDouble> FoodLevels;
    public List<BigDouble> MilitaryLevels;
    public List<BigDouble> LandLevels;
    public List <BigDouble> MaterialLevels;


    public int notation;
    
    public Data()
    {
        sectionAmounts = new BigDouble[] { 0,0,0,0 }; // 0-Food 1-Military 2-Land 3-Material
        humanAmount = 0;
        FoodLevels = new BigDouble[8].ToList();
        MilitaryLevels = new BigDouble[10].ToList();
        LandLevels = new BigDouble[10].ToList();
        MaterialLevels = new BigDouble[9].ToList();

        lockPanels = new bool[] { true, true, false, false, false, false };
        lockRequires = new BigDouble[] { 0, 0, 0, 0 };

        notation = 0;
    }

}
