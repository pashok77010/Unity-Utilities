using UnityEngine;
using UnityEditor;

public class AudioMonoOnImport : AssetPostprocessor
{
    void OnPreprocessAudio()
    {
        AudioImporter audioImporter = (AudioImporter)assetImporter;
        audioImporter.forceToMono = true;
    }
}
