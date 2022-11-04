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

    //Audio Controller
    public AudioSource audioSource;
    public AudioClip audioClip;
    [Range(0, 1)] public float volume;


    private BoxCollider2D collider;
    private bool IsActive = true;

    public void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        collider = GetComponent<BoxCollider2D>();
        spriteRenderer.sprite = unbroken;
        gameObject.layer = 6; // Layer StopMovement

        audioSource = GetComponent<AudioSource>();
    }
    public void OpenDoor()
    {
        if (IsActive)
        {
            IsActive = false;
            collider.enabled = false;
            spriteRenderer.sprite = broken;
            gameObject.layer = 0; // Layer Default

            audioSource.PlayOneShot(audioClip, volume);
        }
    }

}
