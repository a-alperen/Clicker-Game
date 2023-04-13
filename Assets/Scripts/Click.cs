using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using BreakInfinity;

public class Click : MonoBehaviour
{

    private Vector2 position;
    private float width;
    private float height;

    public Data data;
    public UpgradesManager upgradesManager;

    [SerializeField] private TextMeshProUGUI clickText;


    // Start is called before the first frame update
    void Start()
    {
        data = new Data();
        upgradesManager.StartUpgradeManager();
    }

    // Update is called once per frame
    void Update()
    {

        clickText.text = data.Food.ToString("F2");

#if UNITY_EDITOR
        ComputerClick();
#else
        PhoneClick();
#endif
    }

    private void PhoneClick()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began && !EventSystem.current.IsPointerOverGameObject())
            {
                data.Food += ClickPower();
                clickText.text = data.Food.ToString("F2");
            }
        }
    }

    private void ComputerClick()
    {
        
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            data.Food += ClickPower();
            clickText.text = data.Food.ToString("F2");
        }
    }

    public BigDouble ClickPower() => 1 + data.ClickUpgradeLevel;
}
