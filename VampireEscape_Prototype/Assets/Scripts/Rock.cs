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

    private BoxCollider2D collider;
    private bool IsActive = true;

    public void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        collider = GetComponent<BoxCollider2D>();
        spriteRenderer.sprite = unbroken;
        gameObject.layer = 6; // Layer StopMovement
    }
    public void OpenDoor()
    {
        if (IsActive)
        {
            IsActive = false;
            collider.enabled = false;
            spriteRenderer.sprite = broken;
            gameObject.layer = 0; // Layer Default
        }
    }
}
