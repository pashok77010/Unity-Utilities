using UnityEngine;
using UnityEngine.UI;

public class AppVersion : MonoBehaviour
{
    public Text text;
    
    void Start()
    {
        text.text = Application.version;
    }
}
