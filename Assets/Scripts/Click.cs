using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class Click : MonoBehaviour
{

    private Vector2 position;
    private float width;
    private float height;

    private Data data;

    [SerializeField] private TextMeshProUGUI clickText;


    // Start is called before the first frame update
    void Start()
    {
        data = new Data();
    }

    // Update is called once per frame
    void Update()
    {
        
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
                data.Food += 1;
                clickText.text = data.Food.ToString();
            }
        }
    }

    private void ComputerClick()
    {
        
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            data.Food += 1;
            clickText.text = data.Food.ToString();
        }
    }

    
}
