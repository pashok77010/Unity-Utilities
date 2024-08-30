using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManPlatform : MonoBehaviour
{
    public static ManPlatform i;
    [HideInInspector] public bool pc;

    void Awake()
    {
        i = this;

        #if (UNITY_STANDALONE || UNITY_WEBGL || UNITY_EDITOR)

            pc = true;

        #elif UNITY_ANDROID
                
        #else
                        
        #endif

        L.O("pc = " + pc);
    }
}
