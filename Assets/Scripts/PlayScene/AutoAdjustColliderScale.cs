using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoAdjustColliderScale : MonoBehaviour
{
    public enum BoxColiderType
    {
        Vertical,
        Horizontal
    }

    public BoxColiderType colliderType = BoxColiderType.Vertical;
    public RectTransform panel;

    void Start()
    {
        var rect = panel.rect;
        var boxCollider = GetComponent<BoxCollider2D>();
        var boxSize = boxCollider.size;

        if (colliderType == BoxColiderType.Vertical)
        {
            boxSize.y = rect.height;
        }
        else
        {
            boxSize.x = rect.width;
        }

        boxCollider.size = boxSize;
    }

    
    
}
