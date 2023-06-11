using System.Linq;
using System.Collections.Generic;
using BreakInfinity;
using System;

[Serializable]
public class Data
{
    
    public BigDouble[] sectionAmounts;
    public BigDouble humanAmount;
    public BigDouble gold;
    public DateTime lastOnlineTime;
    public List<List<BigDouble>> Levels;
    public List<List<bool>> isAchieve;
    public int[] productionMultiplier;
    public int notation;
    public int notationBuyMultiplier;
    public Data()
    {
        sectionAmounts = new BigDouble[] { 0, 0, 0, 0 }; // 0-Food 1-Military 2-Land 3-Material
        humanAmount = 0;
        gold = 0;
        lastOnlineTime = DateTime.Now;
        productionMultiplier = new int[] { 1, 1, 1, 1 };
        Levels = new List<List<BigDouble>>()
        {
            new BigDouble[8].ToList(),
            new BigDouble[10].ToList(),
            new BigDouble[10].ToList(),
            new BigDouble[9].ToList()
        };
        isAchieve = new List<List<bool>>()
        {
            new bool[5].ToList(),
            new bool[5].ToList(),
            new bool[5].ToList(),
            new bool[5].ToList()
        };
        notation = 0;
        notationBuyMultiplier = 0;
    }

}
