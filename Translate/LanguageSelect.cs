using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
// using TMPro;

using System;

public class LanguageSelect : MonoBehaviour
{
    public Button button;

    void Start()
    {
        // L.W();
        button.onClick.AddListener(ChangeLanguage);
    }

    private void ChangeLanguage()
    {
        ManTranslate.i.NextLanguage();
    }
}
