using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Upgrades : MonoBehaviour
{
    public int upgradeId;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI levelText;
    public TextMeshProUGUI productionText;
    public Slider slider;
    public TextMeshProUGUI progressText;
    public Image upgradeImage;

    public void ShowFoodCostAmount() => UpgradesManager.Instance.CostInfo("Food", upgradeId);
    public void ShowMilitaryCostAmount() => UpgradesManager.Instance.CostInfo("Military", upgradeId);
    public void ShowLandCostAmount() => UpgradesManager.Instance.CostInfo("Land", upgradeId);
    public void ShowMaterialCostAmount() => UpgradesManager.Instance.CostInfo("Material", upgradeId);


    public void BuyFoodUpgrade()
    {
        UpgradesManager.Instance.BuyUpgrade("Food", upgradeId);
        UpgradesManager.Instance.CostInfo("Food", upgradeId);
    }

    public void BuyMilitaryUpgrade()
    {
        UpgradesManager.Instance.BuyUpgrade("Military", upgradeId);
        UpgradesManager.Instance.CostInfo("Military", upgradeId);
    }

    public void BuyLandUpgrade()
    {
        UpgradesManager.Instance.BuyUpgrade("Land", upgradeId);
        UpgradesManager.Instance.CostInfo("Land", upgradeId);
    }

    public void BuyMaterialUpgrade()
    {
        UpgradesManager.Instance.BuyUpgrade("Material", upgradeId);
        UpgradesManager.Instance.CostInfo("Material", upgradeId);
    }
}
