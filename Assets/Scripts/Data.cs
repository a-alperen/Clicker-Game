using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BreakInfinity;

public class Data
{
    private BigDouble food;
    private BigDouble herb;

    private BigDouble clickUpgradeLevel;

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

    public Data()
    {
        food = 0;
        herb = 0;

        clickUpgradeLevel = 0;
    }
}
