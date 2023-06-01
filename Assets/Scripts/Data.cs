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

    public List<List<BigDouble>> Levels;
    
    public int notation;
    
    public Data()
    {
        sectionAmounts = new BigDouble[] { 0,0,0,0 }; // 0-Food 1-Military 2-Land 3-Material
        humanAmount = 0;
        Levels = new List<List<BigDouble>>()
        {
            new BigDouble[8].ToList(),
            new BigDouble[10].ToList(),
            new BigDouble[10].ToList(),
            new BigDouble[9].ToList()
        };

        notation = 0;
    }

}
