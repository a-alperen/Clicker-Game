using BreakInfinity;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Achievement : MonoBehaviour
{
    public int AchievementId;
    public TextMeshProUGUI NameText;
    public TextMeshProUGUI DescriptionText;
    public TextMeshProUGUI CurrentProgressText;
    public Slider slider;
    public Button CollectButton;
    public TextMeshProUGUI CollectButtonText;

    public void CollectFoodReward()
    {
        AchievementManager.Instance.CollectReward("Food", AchievementId);
        SoundManager.Instance.PlaySFX();
    }

    public void CollectMilitaryReward()
    {
        AchievementManager.Instance.CollectReward("Military", AchievementId);
        SoundManager.Instance.PlaySFX();
    }

    public void CollectLandReward()
    {
        AchievementManager.Instance.CollectReward("Land", AchievementId);
        SoundManager.Instance.PlaySFX();
    }

    public void CollectMaterialReward()
    {
        AchievementManager.Instance.CollectReward("Material", AchievementId);
        SoundManager.Instance.PlaySFX();
    }
}
