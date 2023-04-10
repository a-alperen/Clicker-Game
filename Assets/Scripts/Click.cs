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

    private float count = 0;

    [SerializeField] private TextMeshProUGUI clickText;


    void Awake()
    {
        width = (float)Screen.width / 2.0f;
        height = (float)Screen.height / 2.0f;

        // Position used for the cube.
        position = new Vector3(0.0f, 0.0f, 0.0f);
    }


    // Start is called before the first frame update
    void Start()
    {
        
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

            if (touch.phase == TouchPhase.Began)
            {
                count += 1;
                clickText.text = count.ToString();
            }
        }
    }

    private void ComputerClick()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            count += 1;
            clickText.text = count.ToString();
        }
    }

    
}
