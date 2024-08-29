using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Holder : MonoBehaviour
{
    public GameObject obj;
    public Transform tr;
    public RectTransform rt;
    public Rigidbody2D rb;
    public Collider2D col;
    public SpriteRenderer sr;
    public LineRenderer lr;
    public Button button;
    public Image img;
    public Text text;
    public CanvasGroup cg;

    void OnValidate() 
    {
        if(obj == null) obj = gameObject;
        if(tr == null) tr = transform;
        if(rt == null) rt = GetComponent<RectTransform>();
        if(rb == null) rb = GetComponent<Rigidbody2D>();
        if(col == null) col = GetComponent<Collider2D>();
        if(sr == null) sr = GetComponent<SpriteRenderer>();
        if(lr == null) lr = GetComponent<LineRenderer>();
        if(button == null) button = GetComponent<Button>();
        if(img == null) img = GetComponent<Image>();
        if(text == null) text = GetComponent<Text>();
        if(cg == null) cg = GetComponent<CanvasGroup>();
    }
}
