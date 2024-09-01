using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Holder))]
public class Translate : MonoBehaviour
{
    public Holder holder;
    public Text textField;
    public bool anim;
    public string originalString;
    float animationDuration = 1.0f; // Длительность анимации в секундах

    private void OnValidate()
    {
        if (textField == null) textField = GetComponent<Text>();
        if (holder == null) holder = GetComponent<Holder>();
    }

    void Start()
    {
        // L.LW(name);
        originalString = textField.text;
        Action();
        ManTranslate.i.onChangeLanguage.AddListener(Action);
    }

    public void Action()
    {
        // L.LW(name);
        if(anim)
        {
            string newText = ManTranslate.i.Translate(originalString);
            if(holder.obj.activeInHierarchy) StartCoroutine(AnimateText(newText));
        }
        else
        {
            string newText = ManTranslate.i.Translate(originalString);
            textField.text = newText;
        }
    }

    private IEnumerator AnimateText(string newText)
    {
        float elapsedTime = 0f;
        string oldText = textField.text;

        // Этап удаления символов
        while (elapsedTime < animationDuration)
        {
            textField.text = oldText.Substring(0, Mathf.CeilToInt((1 - elapsedTime / animationDuration) * oldText.Length));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        textField.text = "";

        // Этап добавления нового текста
        elapsedTime = 0f;
        while (elapsedTime < animationDuration)
        {
            textField.text = newText.Substring(0, Mathf.CeilToInt(elapsedTime / animationDuration * newText.Length));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        textField.text = newText;
    }
}