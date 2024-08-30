using UnityEngine;
using UnityEditor;

public class CanvasRendererCleaner : EditorWindow
{
    [MenuItem("Tools/_Clean Canvas Renderers")]
    public static void CleanCanvasRenderers()
    {
        int removedCount = 0;
        CanvasRenderer[] allCanvasRenderers = FindObjectsOfType<CanvasRenderer>();

        foreach (CanvasRenderer canvasRenderer in allCanvasRenderers)
        {
            GameObject obj = canvasRenderer.gameObject;

            // Check if the GameObject has any UI components that require CanvasRenderer
            bool hasUIComponent = obj.GetComponent<UnityEngine.UI.Graphic>() != null;

            if (!hasUIComponent)
            {
                DestroyImmediate(canvasRenderer);
                removedCount++;
            }
        }

        Debug.Log($"Removed {removedCount} unnecessary Canvas Renderers.");
    }
}
