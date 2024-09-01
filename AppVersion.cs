using UnityEngine;
using UnityEngine.UI;

public class AppVersion : MonoBehaviour
{
    public Text text;

    void OnValidate()
    {
        if(text == null) text = GetComponent<Text>();
    }
    
    void Start()
    {
        text.text = Application.version;
    }
}
