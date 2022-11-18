using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LeverScript : MonoBehaviour
{
    
    public SpriteRenderer SpriteRenderer;
    public Sprite OnSprite;
    public Sprite offSprite;
    private bool LeverState = false;
    private int Timer = 0;
    public UnityEvent InteractAction;
    public Transform TransformComponate;

    //Audio Controller
    public AudioSource audioSourceOn;
    public AudioClip audioClipOn;
    [Range(0, 1)] public float volumeOn;

    public AudioSource audioSourceOff;
    public AudioClip audioClipOff;
    [Range(0, 1)] public float volumeOff;


    private void Start()
    {
        TransformComponate = GetComponent<Transform>();
        SpriteRenderer = GetComponent<SpriteRenderer>();
        SpriteRenderer.sprite = offSprite;
        audioSourceOn = GetComponent<AudioSource>();
        audioSourceOff = GetComponent<AudioSource>();
    }
    private void Update()
    {
        if(Timer != 0)
        {
            Timer -= 1;
        }
    }
    public void ChangeSprite()
    {
        if (Timer == 0)
        {
            MoveManager.instance.AddMove(); // Adds a move to the player

            if (!LeverState)
            {
                audioSourceOn.PlayOneShot(audioClipOn, volumeOn);
                SpriteRenderer.sprite = OnSprite;
                LeverState = true;
                gameObject.transform.localScale = new Vector3(-1, 1, 1);
                InteractAction.Invoke();
                
            }
            else if (LeverState)
            {
                audioSourceOff.PlayOneShot(audioClipOff, volumeOff);
                SpriteRenderer.sprite = offSprite;
                LeverState = false;
                gameObject.transform.localScale = new Vector3(1, 1, 1);
                InteractAction.Invoke();
            }
           

            Timer = 200;
        }
    }
    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
           if(Input.GetKey(KeyCode.E))
           {
                ChangeSprite();
           }
            Debug.Log("Player is on " + gameObject);
        }
    }
}
