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
    [SerializeField] private Button CollectButton;
    [SerializeField] private TextMeshProUGUI CollectButtonText;

    public void CollectReward()
    {
        CollectButton.interactable = false;
        CollectButtonText.text = "TOPLANDI";
    }
}
