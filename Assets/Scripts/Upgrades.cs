using UnityEngine;
using TMPro;

public class Upgrades : MonoBehaviour
{
    public int upgradeId;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI levelText;
    public TextMeshProUGUI productionText;

    public void ShowFoodCostAmount() => UpgradesManager.Instance.CostInfo("Food", upgradeId);
    public void ShowMilitaryCostAmount() => UpgradesManager.Instance.CostInfo("Military", upgradeId);
    public void ShowLandCostAmount() => UpgradesManager.Instance.CostInfo("Land", upgradeId);
    public void ShowMaterialCostAmount() => UpgradesManager.Instance.CostInfo("Material", upgradeId);


    public void BuyFoodUpgrade()
    {
        UpgradesManager.Instance.CostInfo("Food", upgradeId);
        UpgradesManager.Instance.BuyUpgrade("Food", upgradeId);
    }

    public void BuyMilitaryUpgrade()
    {
        UpgradesManager.Instance.CostInfo("Military", upgradeId);
        UpgradesManager.Instance.BuyUpgrade("Military", upgradeId);
    }

    public void BuyLandUpgrade()
    {
        UpgradesManager.Instance.CostInfo("Land", upgradeId);
        UpgradesManager.Instance.BuyUpgrade("Land", upgradeId);
    }

    public void BuyMaterialUpgrade()
    {
        UpgradesManager.Instance.CostInfo("Material", upgradeId);
        UpgradesManager.Instance.BuyUpgrade("Material", upgradeId);
    }
}
