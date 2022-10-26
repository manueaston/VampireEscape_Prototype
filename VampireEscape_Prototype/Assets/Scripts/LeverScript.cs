using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverScript : MonoBehaviour
{
    public SpriteRenderer SpriteRenderer;
    public Sprite newSprite;
    public Sprite currentSprite;

    void ChangeSprite()
    {
        SpriteRenderer.sprite = newSprite;
    }
}
