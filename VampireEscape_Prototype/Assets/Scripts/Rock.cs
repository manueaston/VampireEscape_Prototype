using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Rock : MonoBehaviour
{
    //Sprite stuff
    private SpriteRenderer spriteRenderer;
    public Sprite unbroken;
    public Sprite broken;
    private UnityEngine.Rendering.Universal.Light2D doorLight;
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

        doorLight = GetComponent<UnityEngine.Rendering.Universal.Light2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        rockCollider = GetComponent<BoxCollider2D>();
        spriteRenderer.sprite = unbroken;
        gameObject.layer = 6; // Layer StopMovement

        
        doorLight.enabled = false;
    }
    public void OpenDoor()
    {
        if (IsActive)
        {
            StartCoroutine(OpenDoorCoroutine());
           
        }
    }

    public IEnumerator OpenDoorCoroutine()
    {
        yield return new WaitForSeconds(0.5f);
        if(IsActive == true)
        {
            audioSource.PlayOneShot(audioClip, volume);
        }

        IsActive = false;

        rockCollider.enabled = false;
        spriteRenderer.sprite = broken;
        gameObject.layer = 0; // Layer Default
        doorLight.enabled = true;
        
    }
}
