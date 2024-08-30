using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class ScriptHierarchyGenerator : EditorWindow
{
    public List<Object> searchFolders = new List<Object>();
    private Dictionary<string, int> folderScriptCounts = new Dictionary<string, int>();
    private int totalScriptsFound = 0;

    [MenuItem("Tools/_Generate Script Hierarchy")]
    private static void Init()
    {
        ScriptHierarchyGenerator window = GetWindow<ScriptHierarchyGenerator>();
        window.titleContent = new GUIContent("Script Hierarchy Generator");
        window.Show();
        window.InitializeDefaultFolder();
    }

    private void OnGUI()
    {
        GUILayout.Label("Script Hierarchy Generator", EditorStyles.boldLabel);

        SerializedObject serializedObject = new SerializedObject(this);
        SerializedProperty serializedProperty = serializedObject.FindProperty("searchFolders");

        EditorGUILayout.PropertyField(serializedProperty, new GUIContent("Search Folders"), true);
        serializedObject.ApplyModifiedProperties();

        GUILayout.Space(10);
        GUILayout.Label("Script Counts by Folder:", EditorStyles.boldLabel);
        foreach (var kvp in folderScriptCounts)
        {
            GUILayout.Label($"{kvp.Key}: {kvp.Value} scripts");
        }

        if (GUILayout.Button("Copy Script Hierarchy to Clipboard"))
        {
            CopyScriptHierarchyToClipboard();
        }
    }

    private void OnValidate()
    {
        UpdateFolderScriptCounts();
    }

    private void InitializeDefaultFolder()
    {
        string defaultFolder = FindFolderWithMostScripts();
        if (!string.IsNullOrEmpty(defaultFolder))
        {
            Object folderObject = AssetDatabase.LoadAssetAtPath<Object>(defaultFolder);
            searchFolders.Add(folderObject);
        }
        UpdateFolderScriptCounts();
    }

    private string FindFolderWithMostScripts()
    {
        var allFolders = Directory.GetDirectories(Application.dataPath, "*", SearchOption.AllDirectories);
        string folderWithMostScripts = "";
        int maxScriptCount = 0;

        foreach (var folder in allFolders)
        {
            int scriptCount = Directory.GetFiles(folder, "*.cs", SearchOption.AllDirectories).Length;
            if (scriptCount > maxScriptCount)
            {
                maxScriptCount = scriptCount;
                folderWithMostScripts = "Assets" + folder.Substring(Application.dataPath.Length).Replace("\\", "/");
            }
        }

        return folderWithMostScripts;
    }

    private void CopyScriptHierarchyToClipboard()
    {
        var allScripts = FindAllScripts();
        var hierarchy = string.Join("\n", allScripts);

        EditorGUIUtility.systemCopyBuffer = hierarchy;
        Debug.Log($"Script hierarchy has been copied to clipboard. {totalScriptsFound} scripts found.");
    }

    private List<string> FindAllScripts()
    {
        var scriptPaths = new List<string>();
        totalScriptsFound = 0;

        foreach (var folder in searchFolders)
        {
            string folderPath = AssetDatabase.GetAssetPath(folder);
            if (!string.IsNullOrEmpty(folderPath))
            {
                folderPath = Path.Combine(Application.dataPath.Substring(0, Application.dataPath.Length - "Assets".Length), folderPath);
                if (Directory.Exists(folderPath))
                {
                    var scriptFiles = Directory.GetFiles(folderPath, "*.cs", SearchOption.AllDirectories);
                    scriptPaths.AddRange(scriptFiles.Select(path => "Assets" + path.Substring(Application.dataPath.Length).Replace("\\", "/")));
                    totalScriptsFound += scriptFiles.Length;
                }
            }
        }

        return scriptPaths;
    }

    private void UpdateFolderScriptCounts()
    {
        folderScriptCounts.Clear();

        foreach (var folder in searchFolders)
        {
            string folderPath = AssetDatabase.GetAssetPath(folder);
            if (!string.IsNullOrEmpty(folderPath))
            {
                folderPath = Path.Combine(Application.dataPath.Substring(0, Application.dataPath.Length - "Assets".Length), folderPath);
                if (Directory.Exists(folderPath))
                {
                    int scriptCount = Directory.GetFiles(folderPath, "*.cs", SearchOption.AllDirectories).Length;
                    string relativeFolderPath = "Assets" + folderPath.Substring(Application.dataPath.Length).Replace("\\", "/");
                    folderScriptCounts[relativeFolderPath] = scriptCount;
                }
            }
        }
    }
}
