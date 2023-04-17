using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using BreakInfinity;

public class Data
{
    private BigDouble food;
    private BigDouble gold;
    private BigDouble machine;
    private BigDouble chip;

    private List<int> upgradeLevels;

    public BigDouble Food
    {
        get { return food; }
        set { food = value; }
    }
    public BigDouble Gold
    {
        get { return  gold; }
        set { gold = value; }
    }
    public BigDouble Machine
    {
        get { return machine; }
        set { machine = value; }
    }
    public BigDouble Chip
    {
        get { return chip; }
        set { chip = value; }
    }

    public List<int> UpgradeLevels
    {
        get { return upgradeLevels; }
        set { upgradeLevels = value; }
    }
    public Data()
    {
        food = 0;
        gold = 0;
        machine = 0;
        chip = 0;

        upgradeLevels = new int[12].ToList();

    }

}
