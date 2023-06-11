using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BreakInfinity;

public class AchievementManager : MonoBehaviour
{
    public static AchievementManager Instance { get; private set; }
    public AchievementHandler[] achievementHandler;

    private void Awake()
    {
        Instance = this;
    }

    public void StartAchievementManager()
    {
        //Başarım başlıkları
        achievementHandler[0].AchievementNames = new string[] { "Üretim 1", "Üretim 2", "Üretim 3", "Üretim 4", "Üretim 5" };
        achievementHandler[1].AchievementNames = new string[] { "Üretim 1", "Üretim 2", "Üretim 3", "Üretim 4", "Üretim 5" };
        achievementHandler[2].AchievementNames = new string[] { "Üretim 1", "Üretim 2", "Üretim 3", "Üretim 4", "Üretim 5" };
        achievementHandler[3].AchievementNames = new string[] { "Üretim 1", "Üretim 2", "Üretim 3", "Üretim 4", "Üretim 5" };
        // Başarım ödülleri
        achievementHandler[0].RewardDescription = new string[] { "2x Yiyecek Üretimi", "3x Yiyecek Üretimi", "4x Yiyecek Üretimi", "5x Yiyecek Üretimi", "10x Yiyecek Üretimi" };
        achievementHandler[1].RewardDescription = new string[] { "2x Askeri Üretimi", "3x Askeri Üretimi", "4x Askeri Üretimi", "5x Askeri Üretimi", "10x Askeri Üretimi" };
        achievementHandler[2].RewardDescription = new string[] { "2x Toprak Üretimi", "3x Toprak Üretimi", "4x Toprak Üretimi", "5x Toprak Üretimi", "10x Toprak Üretimi" };
        achievementHandler[3].RewardDescription = new string[] { "2x Materyal Üretimi", "3x Materyal Üretimi", "4x Materyal Üretimi", "5x Materyal Üretimi", "10x Materyal Üretimi" };
        // Başarım gereksinimleri
        achievementHandler[0].RequireAmount = new BigDouble[] { 1e10, 1e15, 1e20, 1e30, 1e40 };
        achievementHandler[1].RequireAmount = new BigDouble[] { 1e10, 1e15, 1e20, 1e30, 1e40 };
        achievementHandler[2].RequireAmount = new BigDouble[] { 1e10, 1e15, 1e20, 1e30, 1e40 };
        achievementHandler[3].RequireAmount = new BigDouble[] { 1e10, 1e15, 1e20, 1e30, 1e40 };

        CreateUpgrades(Controller.Instance.data.isAchieve[0], 0);
        CreateUpgrades(Controller.Instance.data.isAchieve[1], 1);
        CreateUpgrades(Controller.Instance.data.isAchieve[2], 2);
        CreateUpgrades(Controller.Instance.data.isAchieve[3], 3);

        void CreateUpgrades<T>(List<T> isAchieve, int index)
        {
            for (int i = 0; i < isAchieve.Count; i++)
            {
                Achievement achievement = Instantiate(achievementHandler[index].AchievementPrefab, achievementHandler[index].ContentPanel);
                achievement.AchievementId = i;
                achievementHandler[index].Achievements.Add(achievement);
            }
            achievementHandler[index].AchievementScroll.normalizedPosition = Vector3.zero;
        }

        UpdateUpgradeUI("Food");
        UpdateUpgradeUI("Military");
        UpdateUpgradeUI("Land");
        UpdateUpgradeUI("Material");
    }
    public void UpdateUpgradeUI(string type, int acheivementId = -1)
    {
        switch (type)
        {
            case "Food":
                UpdateAllUI(achievementHandler[0].Achievements, achievementHandler[0].AchievementNames, 0);
                break;
            case "Military":
                UpdateAllUI(achievementHandler[1].Achievements, achievementHandler[1].AchievementNames, 1);
                break;
            case "Land":
                UpdateAllUI(achievementHandler[2].Achievements, achievementHandler[2].AchievementNames, 2);
                break;
            case "Material":
                UpdateAllUI(achievementHandler[3].Achievements, achievementHandler[3].AchievementNames, 3);
                break;
            default:
                break;
        }

        void UpdateAllUI(List<Achievement> achievements, string[] upgradeNames, int index)
        {
            if (acheivementId == -1)
                for (int i = 0; i < achievementHandler[index].Achievements.Count; i++)
                    UpdateUI(i);
            else UpdateUI(acheivementId);

            void UpdateUI(int id)
            {
                achievements[id].NameText.text = upgradeNames[id];
                achievements[id].DescriptionText.text = achievementHandler[index].RewardDescription[id];
                achievements[id].slider.value = (float)(Controller.Instance.data.sectionAmounts[index] / achievementHandler[index].RequireAmount[id]);
                achievements[id].CurrentProgressText.text = $"{Controller.Instance.data.sectionAmounts[index].Notate(3,1)}/{achievementHandler[index].RequireAmount[id].Notate(3,0)}";
                if (Controller.Instance.data.sectionAmounts[index] >= achievementHandler[index].RequireAmount[id]) achievements[id].CollectButton.interactable = true;
                else achievements[id].CollectButton.interactable = false;
            }

        }
    }
    
}
