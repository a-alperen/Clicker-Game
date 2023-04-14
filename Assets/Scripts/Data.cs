using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using BreakInfinity;

public class Data
{
    private BigDouble food;
    private BigDouble herb;

    private BigDouble clickUpgradeLevel;

    private List<BigDouble> upgradeLevels;

    public BigDouble Food
    {
        get { return food; }
        set { food = value; }
    }
    public BigDouble Herb
    {
        get { return herb; }
        set { herb = value; }
    }
    public BigDouble ClickUpgradeLevel
    {
        get { return clickUpgradeLevel; }
        set { clickUpgradeLevel = value; }
    }
    public List<BigDouble> UpgradeLevels
    {
        get { return upgradeLevels; }
        set { upgradeLevels = value; }
    }
    public Data()
    {
        food = 0;
        herb = 0;

        upgradeLevels = Methods.CreateList<BigDouble>(10);

    }

}
