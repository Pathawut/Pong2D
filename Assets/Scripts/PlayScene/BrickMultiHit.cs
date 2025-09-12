using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BrickMultiHit : Brick
{
    public int NumHit;
    public Color[] colors;

    private int hits;
    private Image image;

    protected override void Start()
    {
        image = GetComponent<Image>();
        hits = NumHit-1;
        SetHit(hits);
    }

    public override void OnHit()
    {
        hits--;
        if (hits >= 0)
        {
            SetHit(hits);
        }
        else
        {
            Destroy();
        }
    }

    private void SetHit(int hp)
    {
        image.color = colors[hp];
    }
}
