using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(Holder))]
public class Anim : MonoBehaviour
{
    public Holder holder;
    public Vector3 instantScale;
    public bool unscaledTime = true;

    [Header("Start")]
    public Ease startEase = Ease.InOutExpo;
    public bool activeStart = true;
    public float startDur = 0.314f;
    public Vector3 startScale;
    Tween startScaleTween;

    [Header("Live")]
    public Ease liveEase = Ease.InOutExpo;
    public Tween liveTween;
    public float liveDur;
    public float liveScale = 1.2f;

    [Header("End")]
    public bool activeEnd;
    public Ease endEase = Ease.InOutExpo;
    public float endWaitDur = 0;
    public float endDur = 0.314f;
    public float endScale;
    public float endFade = 0;
    public bool destroy;
    
    void OnValidate()
    {
        if (holder == null) holder = GetComponent<Holder>();
        startScale = holder.tr.localScale;
    }

    public void Activate(bool enable)
    {
        // L.LW("name = "+ name+"  enable = "+enable);
        if(enable)
        {
            AnimStart();
        }
        else
        {
            AnimEnd();
        }
    }

    void Start()
    {
        // L.W("name = "+ name);
        if (activeStart)
        {
            AnimStart();
        }
    }

    public void AnimStart()
    {
        // L.W("name = "+ name);
        holder.obj.SetActive(true);
        holder.tr.localScale = instantScale;
        if(startScaleTween != null) startScaleTween.Kill();
        startScaleTween = holder.tr.DOScale(startScale, startDur)
        .SetEase(startEase)
        .SetUpdate(unscaledTime)
        .OnComplete(()=>
        {
            if (liveDur > 0 & endWaitDur == 0)
            {
                AnimLive();
            }

            if (activeEnd)
            {
                // L.W("activeEnd if (endWaitDur > 0)");
                StartCoroutine(WaitAndEndScale());
            }
        });

        if(holder.cg) 
        {
            holder.cg.alpha = 0;
            holder.cg.DOFade(1, startDur)
            .SetUpdate(unscaledTime)
            .OnComplete(()=>
            {
                holder.cg.interactable = true;
            });
        }
        if(holder.button) holder.button.interactable = true;
    }

    public void AnimLive()
    {
        if(liveTween != null) liveTween.Kill();
        liveTween = holder.tr.DOScale(liveScale, liveDur)
        .SetEase(liveEase)
        .SetUpdate(unscaledTime)
        .SetLoops(-1, LoopType.Yoyo);
    }

    public IEnumerator WaitAndEndScale()
    {
        // L.W("name = "+ name);
        yield return new WaitForSeconds(endWaitDur);
        AnimEnd();
    }

    public void AnimEnd()
    {
        // L.W("START name = "+name);
        if(liveTween != null)
        {
            // L.LW();
            liveTween.Kill();
        }

        holder.tr.DOScale(endScale, endDur)
        .SetEase(endEase)
        .SetUpdate(unscaledTime)
        .OnComplete(() =>
        {
            // L.W("OnComplete");
            if (destroy)
            {
                Destroy(holder.obj);
            }
            else
            {
                if(endFade == 0)
                {
                    holder.obj.SetActive(false);
                }
            }
        });

        if(holder.cg)
        {
            holder.cg.DOFade(endFade, endDur);
            holder.cg.interactable = false;
        }
        else
        {
            if(holder.button) holder.button.interactable = false;
        }
        // L.W("END");
    }

    void OnEnable() 
    {
        if(activeStart)
        {
            AnimStart();
        }
    }
}
