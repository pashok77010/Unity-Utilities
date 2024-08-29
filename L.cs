using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class L
{
    public static void LO(string theString = null, [System.Runtime.CompilerServices.CallerFilePath] string filePath = "", [System.Runtime.CompilerServices.CallerMemberName] string callerName = "")
    {
        string coloredMessage = Generate(theString, filePath, callerName);
        Debug.Log(coloredMessage);
    }

    public static void W(string theString = null, [System.Runtime.CompilerServices.CallerFilePath] string filePath = "", [System.Runtime.CompilerServices.CallerMemberName] string callerName = "")
    {
        string coloredMessage = Generate(theString, filePath, callerName);
        Debug.LogWarning(coloredMessage);
    }

    public static void W_Blue(string theString = null, [System.Runtime.CompilerServices.CallerFilePath] string filePath = "", [System.Runtime.CompilerServices.CallerMemberName] string callerName = "")
    {
        // Генерация сообщения с применением цветов
        string coloredMessage = GenerateColor(theString, filePath, callerName, Color.blue);
        Debug.LogWarning(coloredMessage);
    }

    public static void E(string theString = null, [System.Runtime.CompilerServices.CallerFilePath] string filePath = "", [System.Runtime.CompilerServices.CallerMemberName] string callerName = "")
    {
        Debug.LogError(Generate(theString, filePath, callerName));
    }

    public static void DL(Vector3 startPos, Vector3? endPos, Color color, float dur = 2)
    {   
        if (!endPos.HasValue) 
            endPos = new Vector3(startPos.x, startPos.y, startPos.z + 50);
        Debug.DrawLine(startPos, endPos.Value, color, dur);
    }

    public static void DR(Vector3 startPos, Vector3? endPos, Color color, float dur = 2)
    {
        if (!endPos.HasValue) 
            endPos = new Vector3(startPos.x, startPos.y, startPos.z + 50);
        Debug.DrawRay(startPos, endPos.Value, color, dur);
    }

    static string Generate(string theString = null, [System.Runtime.CompilerServices.CallerFilePath] string filePath = "", [System.Runtime.CompilerServices.CallerMemberName] string callerName = "")
    {
        string separatingSymbol = " | ";
        string scriptType = System.IO.Path.GetFileNameWithoutExtension(filePath);
        string caller = callerName;
        string message = theString;
        return scriptType + separatingSymbol + caller + separatingSymbol + message;
    }

    static string GenerateColor(string theString = null, [System.Runtime.CompilerServices.CallerFilePath] string filePath = "", [System.Runtime.CompilerServices.CallerMemberName] string callerName = "", Color color = default)
    {
        string separatingSymbol = " | ";
        string scriptType = $"<color=#{ColorUtility.ToHtmlStringRGBA(color)}>{System.IO.Path.GetFileNameWithoutExtension(filePath)}</color>";
        Color lighterColor1 = Color.Lerp(color, Color.white, 0.5f);
        string caller = $"<color=#{ColorUtility.ToHtmlStringRGBA(lighterColor1)}>{callerName}</color>";
        Color lighterColor2 = Color.Lerp(color, Color.white, 0.75f);
        string message = $"<color=#{ColorUtility.ToHtmlStringRGBA(lighterColor2)}>{theString}</color>";
        return scriptType + separatingSymbol + caller + separatingSymbol + message;
    }
}   
