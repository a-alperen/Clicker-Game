using System.Linq;
using System.Collections.Generic;
using BreakInfinity;
using System;

[Serializable]
public class Data
{
    
    public BigDouble[] sectionAmounts;
    public BigDouble humanAmount;
    public DateTime lastOnlineTime;
    public List<List<BigDouble>> Levels;
    public List<List<bool>> isAchieve;
    public int notation;
    
    public Data()
    {
        sectionAmounts = new BigDouble[] { 0,0,0,0 }; // 0-Food 1-Military 2-Land 3-Material
        humanAmount = 0;
        lastOnlineTime = DateTime.Now;

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
    }

}
