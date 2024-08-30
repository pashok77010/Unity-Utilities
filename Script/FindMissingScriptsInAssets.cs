using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;

public class FindMissingScriptsInAssets
{
    [MenuItem("Tools/_Find Missing Scripts in Assets")]
    public static void FindMissingScripts()
    {
        int totalPrefabsChecked = 0, totalPrefabsWithMissingScripts = 0;
        CheckPrefabs(ref totalPrefabsChecked, ref totalPrefabsWithMissingScripts);

        int totalSceneObjectsChecked = 0, totalSceneObjectsWithMissingScripts = 0;
        CheckScenes(ref totalSceneObjectsChecked, ref totalSceneObjectsWithMissingScripts);

        Debug.Log($"ЗАВЕРШЕНО. Проверено префабов: {totalPrefabsChecked}, префабы без скриптов: {totalPrefabsWithMissingScripts}, объектов в сценах: {totalSceneObjectsChecked}, Объекты без скриптов: {totalSceneObjectsWithMissingScripts}");
    }

    private static void CheckPrefabs(ref int totalPrefabsChecked, ref int totalPrefabsWithMissingScripts)
    {
        string[] allPrefabs = AssetDatabase.FindAssets("t:Prefab");
        totalPrefabsChecked = allPrefabs.Length;

        foreach (string prefabGUID in allPrefabs)
        {
            string prefabPath = AssetDatabase.GUIDToAssetPath(prefabGUID);
            GameObject prefab = AssetDatabase.LoadAssetAtPath<GameObject>(prefabPath);

            if (prefab != null && FindInGameObject(prefab, prefabPath, out int missingScripts) > 0)
            {
                if (missingScripts > 0)
                {
                    totalPrefabsWithMissingScripts++;
                }
            }
        }

        // Debug.Log($"Проверено префабов: {totalPrefabsChecked}, префабы без скриптов: {totalPrefabsWithMissingScripts}");
    }

    private static void CheckScenes(ref int totalSceneObjectsChecked, ref int totalSceneObjectsWithMissingScripts)
    {
        string[] allScenes = AssetDatabase.FindAssets("t:Scene");

        foreach (string sceneGUID in allScenes)
        {
            string scenePath = AssetDatabase.GUIDToAssetPath(sceneGUID);
            Scene scene = EditorSceneManager.OpenScene(scenePath, OpenSceneMode.Single);
            GameObject[] rootObjects = scene.GetRootGameObjects();

            int objectsInScene = 0, objectsWithMissingScriptsInScene = 0;

            foreach (GameObject rootObject in rootObjects)
            {
                objectsInScene += FindInGameObject(rootObject, scenePath, out int missingScripts);
                objectsWithMissingScriptsInScene += missingScripts;
            }

            totalSceneObjectsChecked += objectsInScene;
            totalSceneObjectsWithMissingScripts += objectsWithMissingScriptsInScene;

            Debug.Log($"СЦЕНА: {scenePath}, объектов: {objectsInScene}, объекты без скриптов: {objectsWithMissingScriptsInScene}");
        }
    }

    private static int FindInGameObject(GameObject gameObject, string assetPath, out int objectsWithMissingScripts)
    {
        int checkedObjects = 1; // Current object is also checked
        objectsWithMissingScripts = 0;
        Component[] components = gameObject.GetComponentsInChildren<Component>(true);

        foreach (Component component in components)
        {
            if (component == null)
            {
                objectsWithMissingScripts++;
                Debug.LogError($"Пропавший скрипт найден в: {assetPath} в объекте: {GetFullPath(gameObject)}");
            }
        }

        foreach (Transform child in gameObject.transform)
        {
            checkedObjects += FindInGameObject(child.gameObject, assetPath, out int childMissingScripts);
            objectsWithMissingScripts += childMissingScripts;
        }

        return checkedObjects;
    }

    private static string GetFullPath(GameObject gameObject)
    {
        string path = gameObject.name;
        Transform parent = gameObject.transform.parent;

        while (parent != null)
        {
            path = parent.name + "/" + path;
            parent = parent.parent;
        }

        return path;
    }
}
