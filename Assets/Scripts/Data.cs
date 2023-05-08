using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using BreakInfinity;
using System;

[Serializable]
public class Data
{
    private BigDouble food;
    private BigDouble gold;
    private BigDouble machine;
    private BigDouble chip;

    private List<int> clickUpgradeLevels;
    private List<int> firstAgeProductionUpgradeLevels;
    private List<int> secondAgeProductionUpgradeLevels;
    private List<int> thirdAgeProductionUpgradeLevels;
    private List<int> fourthAgeProductionUpgradeLevels;

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

    public List<int> ClickUpgradeLevels
    {
        get { return clickUpgradeLevels; }
        set { clickUpgradeLevels = value; }
    }
    public List<int> FirstAgeProductionUpgradeLevels
    {
        get { return firstAgeProductionUpgradeLevels; }
        set { firstAgeProductionUpgradeLevels = value; }
    }
    public List<int> SecondAgeProductionUpgradeLevels
    {
        get { return secondAgeProductionUpgradeLevels; }
        set { secondAgeProductionUpgradeLevels = value; }
    }
    public List<int> ThirdAgeProductionUpgradeLevels
    {
        get { return thirdAgeProductionUpgradeLevels; }
        set { thirdAgeProductionUpgradeLevels = value; }
    }
    public List<int> FourthAgeProductionUpgradeLevels
    {
        get { return fourthAgeProductionUpgradeLevels; }
        set { fourthAgeProductionUpgradeLevels = value; }
    }
    public Data()
    {
        food = 0;
        gold = 0;
        machine = 0;
        chip = 0;

        clickUpgradeLevels = new int[12].ToList();
        firstAgeProductionUpgradeLevels = new int[8].ToList();
    }

}
