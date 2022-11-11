using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlateController : MonoBehaviour
{
    public SpriteRenderer SpriteRenderer;
    public Sprite offSprite;
    public Sprite OnSprite;
    public bool SteppedOn;

    //Audio Controller
    public AudioSource audioSource;
    public AudioClip audioClip;
    [Range(0, 1)] public float volume;

    private void Start()
    {
        SpriteRenderer = GetComponent<SpriteRenderer>();
        SpriteRenderer.sprite = offSprite;

        audioSource = GetComponent<AudioSource>();
    }
    public void Stepped()
    {
       if(!SteppedOn)
       {

           SteppedOn = true;
           Debug.Log("PressurePlate stepped on trigger door/trap");
       }
       else if (SteppedOn)
       {
            SteppedOn = false;
       }
    }
    public void ChangeSprite()
    {
        
            if (SteppedOn)
            {
                SpriteRenderer.sprite = OnSprite;
                audioSource.PlayOneShot(audioClip, volume);
            }
            else if (!SteppedOn)
            {
                SpriteRenderer.sprite = offSprite;
            }
        
    }
}
