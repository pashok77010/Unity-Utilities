using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
#if TMP_PRESENT
using TMPro;
#endif

public class TextComponentConverter : EditorWindow
{
    private static Font defaultFont;
#if TMP_PRESENT
    private static TMP_FontAsset defaultTMPFont;
#endif

    [MenuItem("Tools/_Convert Text Components")]
    public static void ShowWindow()
    {
        GetWindow<TextComponentConverter>("Text Component Converter");
    }

    private void OnGUI()
    {
        GUILayout.Label("Fonts for Conversion", EditorStyles.boldLabel);
        defaultFont = (Font)EditorGUILayout.ObjectField("Default Font (Text)", defaultFont, typeof(Font), false);
#if TMP_PRESENT
        defaultTMPFont = (TMP_FontAsset)EditorGUILayout.ObjectField("Default TMP Font (TextMeshPro)", defaultTMPFont, typeof(TMP_FontAsset), false);
#endif

#if TMP_PRESENT
        if (GUILayout.Button("Convert Text to TextMeshPro"))
        {
            ConvertTextToTextMeshPro();
        }
        if (GUILayout.Button("Convert TextMeshPro to Text"))
        {
            ConvertTextMeshProToText();
        }
#else
        GUIStyle style = new GUIStyle(GUI.skin.label);
        style.normal.textColor = Color.red;
        GUILayout.Label("TMP Pro ассет не найден в проекте!", style);
        GUI.enabled = false;
        GUILayout.Button("Convert Text to TextMeshPro");
        GUILayout.Button("Convert TextMeshPro to Text");
        GUI.enabled = true;
#endif
    }

#if TMP_PRESENT
    private void ConvertTextToTextMeshPro()
    {
        foreach (var text in GameObject.FindObjectsOfType<Text>())
        {
            var go = text.gameObject;

            // Remove existing Text component
            DestroyImmediate(text);

            // Check if TextMeshProUGUI is already present; if not, add it
            if (go.GetComponent<TextMeshProUGUI>() == null)
            {
                var textMeshPro = go.AddComponent<TextMeshProUGUI>();
                CopyTextProperties(text, textMeshPro);
            }
        }
        Debug.Log("Converted all Text components to TextMeshPro.");
    }

    private void ConvertTextMeshProToText()
    {
        foreach (var textMeshPro in GameObject.FindObjectsOfType<TextMeshProUGUI>())
        {
            var go = textMeshPro.gameObject;

            // Remove existing TextMeshProUGUI component
            DestroyImmediate(textMeshPro);

            // Check if Text is already present; if not, add it
            if (go.GetComponent<Text>() == null)
            {
                var text = go.AddComponent<Text>();
                CopyTextMeshProProperties(textMeshPro, text);
            }
        }
        Debug.Log("Converted all TextMeshPro components to Text.");
    }

    private void CopyTextProperties(Text source, TextMeshProUGUI destination)
    {
        destination.text = source.text;
        destination.fontSize = source.fontSize; // FontSize is a float
        destination.color = source.color;
        destination.alignment = (TextAlignmentOptions)ConvertAlignment(source.alignment);

        // Additional properties
        destination.overflowMode = TextOverflowModes.Overflow;
        destination.enableWordWrapping = source.horizontalOverflow == HorizontalWrapMode.Wrap;
        destination.enableAutoSizing = false; // Set to true if auto-sizing is used
        destination.fontStyle = ConvertFontStyle(source.fontStyle);

        // Set the default TMP font if provided
        if (defaultTMPFont != null)
        {
            destination.font = defaultTMPFont;
        }
    }

    private void CopyTextMeshProProperties(TextMeshProUGUI source, Text destination)
    {
        destination.text = source.text;
        destination.fontSize = (int)source.fontSize; // Convert float to int for Text component
        destination.color = source.color;
        destination.alignment = ConvertAlignment(source.alignment);

        // Additional properties
        destination.horizontalOverflow = source.overflowMode == TextOverflowModes.Overflow ? HorizontalWrapMode.Wrap : HorizontalWrapMode.Overflow;
        destination.verticalOverflow = source.overflowMode == TextOverflowModes.Overflow ? VerticalWrapMode.Truncate : VerticalWrapMode.Overflow;

        // Set the default font if provided
        if (defaultFont != null)
        {
            destination.font = defaultFont;
        }
    }

    private int ConvertAlignment(TextAnchor anchor)
    {
        switch (anchor)
        {
            case TextAnchor.UpperLeft: return (int)TextAlignmentOptions.TopLeft;
            case TextAnchor.UpperCenter: return (int)TextAlignmentOptions.Top;
            case TextAnchor.UpperRight: return (int)TextAlignmentOptions.TopRight;
            case TextAnchor.MiddleLeft: return (int)TextAlignmentOptions.Left;
            case TextAnchor.MiddleCenter: return (int)TextAlignmentOptions.Center;
            case TextAnchor.MiddleRight: return (int)TextAlignmentOptions.Right;
            case TextAnchor.LowerLeft: return (int)TextAlignmentOptions.BottomLeft;
            case TextAnchor.LowerCenter: return (int)TextAlignmentOptions.Bottom;
            case TextAnchor.LowerRight: return (int)TextAlignmentOptions.BottomRight;
            default: return (int)TextAlignmentOptions.TopLeft;
        }
    }

    private TextAnchor ConvertAlignment(TextAlignmentOptions alignment)
    {
        switch (alignment)
        {
            case TextAlignmentOptions.TopLeft: return TextAnchor.UpperLeft;
            case TextAlignmentOptions.Top: return TextAnchor.UpperCenter;
            case TextAlignmentOptions.TopRight: return TextAnchor.UpperRight;
            case TextAlignmentOptions.Left: return TextAnchor.MiddleLeft;
            case TextAlignmentOptions.Center: return TextAnchor.MiddleCenter;
            case TextAlignmentOptions.Right: return TextAnchor.MiddleRight;
            case TextAlignmentOptions.BottomLeft: return TextAnchor.LowerLeft;
            case TextAlignmentOptions.Bottom: return TextAnchor.LowerCenter;
            case TextAlignmentOptions.BottomRight: return TextAnchor.LowerRight;
            default: return TextAnchor.UpperLeft;
        }
    }

    private FontStyle ConvertFontStyle(TMPro.FontStyles fontStyle)
    {
        FontStyle style = FontStyle.Normal;
        if (fontStyle.HasFlag(TMPro.FontStyles.Bold))
            style |= FontStyle.Bold;
        if (fontStyle.HasFlag(TMPro.FontStyles.Italic))
            style |= FontStyle.Italic;
        // Underline and Strikethrough do not have direct equivalents in Unity's FontStyle
        // So we will not include them in the conversion
        return style;
    }

    private TMPro.FontStyles ConvertFontStyle(FontStyle fontStyle)
    {
        TMPro.FontStyles style = TMPro.FontStyles.Normal;
        if (fontStyle.HasFlag(FontStyle.Bold))
            style |= TMPro.FontStyles.Bold;
        if (fontStyle.HasFlag(FontStyle.Italic))
            style |= TMPro.FontStyles.Italic;
        // Underline and Strikethrough are not directly supported, so we will not include them in the conversion
        return style;
    }
#endif
}
