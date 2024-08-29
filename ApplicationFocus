using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplicationFocus : MonoBehaviour
{
    public AudioClip focusClip;
    public AudioClip unfocusClip;
    bool unblockSound;

    void Start()
    {
        ManFirstTouch.i.onFirstTouch.AddListener(Activate);
    }

    void Activate()
    {
        unblockSound = true;
    }

    void OnApplicationFocus(bool hasFocus)
    {
        if(unblockSound == false) return;
        if (hasFocus)
        {
            ManAudio.i.Play(focusClip);
        }
        else
        {
            ManAudio.i.Play(unfocusClip);
        }
    }
}
