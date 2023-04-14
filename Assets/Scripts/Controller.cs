﻿using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using BreakInfinity;

public class Controller : MonoBehaviour
{

    public static Controller Instance { get; private set; }

    public Data data;
    
    [SerializeField] private TextMeshProUGUI clickText;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        data = new Data();
        UpgradesManager.Instance.StartUpgradeManager();
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
            
            if (touch.phase == TouchPhase.Began && !EventSystem.current.IsPointerOverGameObject(0))
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