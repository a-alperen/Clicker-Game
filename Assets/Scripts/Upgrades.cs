using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Upgrades : MonoBehaviour
{
    public int upgradeId;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI costText;
    public TextMeshProUGUI levelText;
    public TextMeshProUGUI productionText;


    public void BuyClickUpgrade() => UpgradesManager.Instance.BuyUpgrade("Click",upgradeId);
    public void BuyFirstAgeUpgrade() => UpgradesManager.Instance.BuyUpgrade("FirstAge", upgradeId);
    public void BuySecondAgeUpgrade() => UpgradesManager.Instance.BuyUpgrade("SecondAge", upgradeId);
    public void BuyThirdAgeUpgrade() => UpgradesManager.Instance.BuyUpgrade("ThirdAge", upgradeId);
    public void BuyFourthAgeUpgrade() => UpgradesManager.Instance.BuyUpgrade("FourthAge", upgradeId);

}
