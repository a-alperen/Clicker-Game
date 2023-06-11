using BreakInfinity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchievementHandler : MonoBehaviour
{
    public List<Achievement> Achievements;
    public Achievement AchievementPrefab;
    public ScrollRect AchievementScroll;
    public Transform ContentPanel;

    public string[] AchievementNames;
    public string[] RewardDescription;
    public BigDouble[] RequireAmount;
    public int[] RewardAmount;

}
