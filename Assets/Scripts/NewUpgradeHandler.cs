using BreakInfinity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewUpgradeHandler : MonoBehaviour
{
    public List<Upgrades> Upgrades;
    public Upgrades UpgradePrefab;
    public ScrollRect UpgradesScroll;
    public Transform ContentPanel;

    public string[] UpgradesNames;
    public List<List<BigDouble>> UpgradesCost;
    public BigDouble[] UpgradesBasePower;
    public List<float> UpgradesProductionSecond;
}
