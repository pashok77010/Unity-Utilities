using UnityEngine;

public static class Pref
{
    // HAS /////////////////////////////////////////////////////////////////////////////////////////////////////////
    public static void HasBool(string name, bool defaultValue)
    {
        bool has = PlayerPrefs.HasKey(name);

        if (has == false)
        {
            if (defaultValue)
            {
                PlayerPrefs.SetInt(name, 1);
            }
            else
            {
                PlayerPrefs.SetInt(name, 0);
            }
        }
    }

    public static bool HasInt(string name)
    {
        return PlayerPrefs.HasKey(name);
    }

    public static void HasSetDefaultInt(string name, int defaultValue = 0)
    {
        bool has = PlayerPrefs.HasKey(name);

        if (has == false)
        {
            PlayerPrefs.SetInt(name, defaultValue);
        }
    }

    public static void HasFloat(string name, float defaultValue = 0)
    {
        bool has = PlayerPrefs.HasKey(name);

        if (has == false)
        {
            PlayerPrefs.SetFloat(name, defaultValue);
        }
    }

    public static int Has_Int_ReturnInfinity(string name)
    {
        if (PlayerPrefs.HasKey(name))
        {
            return PlayerPrefs.GetInt(name);
        }
        else
        {
            L.W("float.MaxValue = " + int.MaxValue);
            return int.MaxValue;
        }
    }

    public static bool HasBool_GetBool_ReturnFalse(string name)
    {
        bool boolResult;

        if (PlayerPrefs.HasKey(name))
        {
            if (PlayerPrefs.GetInt(name) == 1)
            {
                boolResult = true;
            }
            else
            {
                boolResult = false;
            }
        }
        else
        {
            SetBool(name, false);
            boolResult = false;
        }
        return boolResult;
    }

    // GET /////////////////////////////////////////////////////////////////////////////////////////////////////////
    public static bool GetBool(string name)
    {
        bool boolResult;
        int resultInt = PlayerPrefs.GetInt(name);

        if (resultInt == 1)
        {
            boolResult = true;
        }
        else
        {
            boolResult = false;
        }
        L.O("name = " + name + " bool = " + boolResult);
        return boolResult;
    }

    public static string GetString(string name)
    {
        return PlayerPrefs.GetString(name);
    }

    public static int GetInt(string name)
    {
        return PlayerPrefs.GetInt(name);
    }

    public static int HasAndGetInt(string name)
    {
        if (PlayerPrefs.HasKey(name))
        {
            return PlayerPrefs.GetInt(name);
        }
        else
        {
            PlayerPrefs.SetInt(name, 0);
            return 0;
        }
    }

    public static float GetFloat(string name)
    {
        return PlayerPrefs.GetFloat(name);
    }

    // SET /////////////////////////////////////////////////////////////////////////////////////////////////////////
    public static void SetBool(string name, bool value = false)
    {
        if (value)
        {
            PlayerPrefs.SetInt(name, 1);
        }
        else
        {
            PlayerPrefs.SetInt(name, 0);
        }
    }

    public static void SetString(string name, string value)
    {
        PlayerPrefs.SetString(name, value);
    }

    public static void SetInt(string name, int value)
    {
        PlayerPrefs.SetInt(name, value);
    }

    public static void SetFloat(string name, float value)
    {
        PlayerPrefs.SetFloat(name, value);
    }

    public static void Get_Set_Increce_Int(string name)
    {
        int intValue = PlayerPrefs.GetInt(name);
        int increceValue = intValue + 1;
        PlayerPrefs.SetInt(name, increceValue);
        // LW_Blue("GetInt(name) = " + GetInt(name));
    }

    public static void DeteteAll()
    {
        L.W();
        PlayerPrefs.DeleteAll();
    }
}
