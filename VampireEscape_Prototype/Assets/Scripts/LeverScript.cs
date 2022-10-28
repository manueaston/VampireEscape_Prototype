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
    private void Start()
    {
        SpriteRenderer = GetComponent<SpriteRenderer>();
        SpriteRenderer.sprite = offSprite;
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
            if (!LeverState)
            {
                SpriteRenderer.sprite = OnSprite;
                LeverState = true;
                InteractAction.Invoke();
            }
            else if (LeverState)
            {
                SpriteRenderer.sprite = offSprite;
                LeverState = false;
            }
            Timer = 100;
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
