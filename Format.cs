using System.Collections.Generic;

public static class Format
{
    public static string AbbreviateNumber(float number) // Аббревиатура Числа
    {
        if (number >= 1000000000000)
            return (number / 1000000000000f).ToString("0.#") + "T";
        else if (number >= 1000000000)
            return (number / 1000000000f).ToString("0.#") + "B";
        else if (number >= 1000000)
            return (number / 1000000f).ToString("0.#") + "M";
        else if (number >= 1000)
            return (number / 1000f).ToString("0.#") + "K";
        else
            return ((int)number).ToString();
    }

    public static int RandomListIndex<T>(List<T> list)
    {
        return UnityEngine.Random.Range(0, list.Count - 1);
    }
}
