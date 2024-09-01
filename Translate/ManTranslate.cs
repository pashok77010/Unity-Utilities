using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;

public class ManTranslate : MonoBehaviour
{
    public static ManTranslate i;
    public string languagePrefs = "Language";
    public SupportedLanguages currentLanguage = SupportedLanguages.English;
    [HideInInspector] public UnityEvent onChangeLanguage;

    void Awake()
    {
        i = this;
        Translation.Initialize();
        currentLanguage = GetPrefsLanguage();
        Save();
    }

    public string Translate(string word)
    {
        if (currentLanguage == SupportedLanguages.English) return word;

        // L.W(
        //     " | word = "+word + 
        //     " | currentLanguage = "+currentLanguage + 
        //     " | ContainsKey(currentLanguage) = "+translations.ContainsKey(currentLanguage) + 
        //     " | translations[currentLanguage].ContainsKey(word) = "+translations[currentLanguage].ContainsKey(word)
        // );

        if (Translation.languageDictionary.ContainsKey(currentLanguage) && Translation.languageDictionary[currentLanguage].ContainsKey(word))
        {
            return Translation.languageDictionary[currentLanguage][word];
        }

        L.E("НЕТ ПЕРЕВОДА: " + word); // НЕ КОММЕНТИРОВАТЬ ЭТО НУЖНО - ЭТО ОШИБКА ОТСУТСТВИЯ ПЕРЕВОДА
        return word;
    }

    SupportedLanguages GetPrefsLanguage()
    {
        if (PlayerPrefs.HasKey(languagePrefs))
        {
            string prefsLanguageString = PlayerPrefs.GetString(languagePrefs);
            if (Enum.TryParse(prefsLanguageString, out SupportedLanguages savedLanguage))
            {
                if (Translation.languageDictionary.ContainsKey(savedLanguage))
                {
                    return savedLanguage;
                }
            }
        }

        // Если префс не установлен или язык не поддерживается, возвращаем системный язык
        return GetSystemLanguage();
    }

    SupportedLanguages GetSystemLanguage()
    {
        L.W();
        if (Enum.TryParse(Application.systemLanguage.ToString(), out SupportedLanguages systemLanguage))
        {
            // L.W("Язык установлен из системного = "+ systemLanguage);
            return systemLanguage;
        }
        else
        {
            // L.W("Язык по умолчанию, т.к. системный язык не соответствует = "+ SupportedLanguages.English);
            return SupportedLanguages.English;
        }
    }

    public void NextLanguage()
    {
        int languagesCount = Enum.GetNames(typeof(SupportedLanguages)).Length;
        int currentLanguageIndex = (int)currentLanguage;
        int nextLanguageIndex = (currentLanguageIndex + 1) % languagesCount;
        SupportedLanguages nextLanguage = (SupportedLanguages)nextLanguageIndex;

        Debug.Log("Next Language: " + nextLanguage);
        SetLanguage(nextLanguage);
    }

    public void SetLanguage(SupportedLanguages language)
    {
        // L.W("language = "+language.ToString());
        currentLanguage = language;
        // L.W("1 currentLanguage = "+currentLanguage.ToString());
        Save();

        // TextTranslate[] textTranslates = FindObjectsOfType<TextTranslate>();
        // foreach (TextTranslate theTextTranslate in textTranslates)
        // {
        //     theTextTranslate.Action();
        // }

        onChangeLanguage.Invoke();
        // L.W("2 currentLanguage = "+currentLanguage.ToString());
    }

    void Save()
    {
        PlayerPrefs.SetString(languagePrefs, currentLanguage.ToString());
        PlayerPrefs.Save(); // Явное сохранение изменений
        Debug.Log("Saved Language: " + currentLanguage);
    }
}