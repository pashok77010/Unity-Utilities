using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Unity.VisualScripting;

[RequireComponent(typeof(Holder))]
public class Anim : MonoBehaviour
{
    public Holder holder;
    public Vector3 instantScale;

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
    public bool destroy;

    void OnValidate()
    {
        if (holder == null) holder = GetComponent<Holder>();
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

    void Awake()
    {
        startScale = holder.tr.localScale;
    }

    void Start()
    {
        // L.LW("name = "+ name);
        if (activeStart)
        {
            AnimStart();
        }

        if (activeEnd)
        {
            // L.LW("if (endWaitDur > 0)");
            StartCoroutine(WaitAndEndScale());
        }
    }

    public void AnimStart()
    {
        // L.LW("name = "+ name);
        holder.obj.SetActive(true);
        holder.tr.localScale = instantScale;
        if(startScaleTween != null) startScaleTween.Kill();
        startScaleTween = holder.tr.DOScale(startScale, startDur)
        .SetEase(startEase)
        .OnComplete(()=>
        {
            if (liveDur > 0 & endWaitDur == 0)
            {
                AnimLive();
            }
        });

        if(holder.cg) 
        {
            holder.cg.alpha = 0;
            holder.cg.DOFade(1, startDur);
        }
        if(holder.button) holder.button.interactable = true;
    }

    public void AnimLive()
    {
        liveTween = holder.tr.DOScale(liveScale, liveDur)
        .SetEase(liveEase)
        .SetLoops(-1, LoopType.Yoyo);
    }

    public IEnumerator WaitAndEndScale()
    {
        // L.LW("name = "+ name);
        yield return new WaitForSeconds(endWaitDur);
        AnimEnd();
    }

    public void AnimEnd()
    {
        // L.LW("name = "+name);
        if(liveTween != null)
        {
            // L.LW();
            liveTween.Kill();
        }

        holder.tr.DOScale(endScale, endDur)
        .SetEase(endEase)
        .OnComplete(() =>
        {
            if (destroy)
            {
                Destroy(holder.obj);
            }
            else
            {
                holder.obj.SetActive(false);
            }
        });

        if(holder.cg) holder.cg.DOFade(0, startDur);
        if(holder.button) holder.button.interactable = false;
    }

    void OnEnable() 
    {
        AnimStart();    
    }
}
