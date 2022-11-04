using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    //Sprite stuff
    private SpriteRenderer spriteRenderer;
    public Sprite unbroken;
    public Sprite broken;
    //

    public BoxCollider2D rockCollider;
    private bool IsActive = true;

    public void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rockCollider = GetComponent<BoxCollider2D>();
        spriteRenderer.sprite = unbroken;
        gameObject.layer = 6; // Layer StopMovement
    }
    public void OpenDoor()
    {
        if (IsActive)
        {
            IsActive = false;
            rockCollider.enabled = false;
            spriteRenderer.sprite = broken;
            gameObject.layer = 0; // Layer Default
        }
    }
}
