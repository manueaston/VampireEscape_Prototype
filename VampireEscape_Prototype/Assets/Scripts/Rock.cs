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


    public BoxCollider2D rockCollider;
    private bool IsActive = true;

    public void Start()
    {
        audioSource = GetComponent<AudioSource>();

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

            audioSource.PlayOneShot(audioClip, volume);
        }
    }
}
