using TMPro;
using UnityEngine;

public class ClickText : MonoBehaviour
{
    public TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject,1.1f);
        text.text = $"+{Controller.Instance.ClickPower().Notate()}";
    }

}
