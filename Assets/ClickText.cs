using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ClickText : MonoBehaviour
{
    public TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject,60f);
        text.text = Controller.Instance.ClickPower().Notate();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
