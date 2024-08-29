using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Logging : MonoBehaviour
{
    public bool enableBuildLogging;
    
	void Awake() 
	{
		#if UNITY_EDITOR
			Debug.unityLogger.logEnabled = true;
		#else
			Debug.unityLogger.logEnabled = enableBuildLogging;
		#endif
	}
}
