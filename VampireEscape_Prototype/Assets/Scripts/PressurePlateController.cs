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


    private UnityEngine.Rendering.Universal.Light2D Light;
    

    private void Start()
    {
        SpriteRenderer = GetComponent<SpriteRenderer>();
        Light = GetComponent<UnityEngine.Rendering.Universal.Light2D>();
        SpriteRenderer.sprite = offSprite;

        audioSource = GetComponent<AudioSource>();
        Light.enabled = false;
    }
    public void Stepped()
    {
       if(!SteppedOn)
       {

           SteppedOn = true;
           Debug.Log("PressurePlate stepped on trigger door/trap");
           Light.enabled = true;

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
                
            }
            else if (!SteppedOn)
            {
                SpriteRenderer.sprite = offSprite;
            }
        
    }
}
