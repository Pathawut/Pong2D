using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    public BrickManager brickManager;

    protected RectTransform rectTransform;

    protected virtual void Start()
    {
        
    }

    public virtual void OnHit()
    {
        Destroy();
    }

    public virtual void Destroy()
    {
        brickManager.DestroyBrick(this);
    }

    public void SetPosition(Vector2 pos)
    {
        if (rectTransform == null)
        {
            rectTransform = gameObject.transform as RectTransform;
        }
       
        rectTransform.localPosition = pos;
        
    }
}
