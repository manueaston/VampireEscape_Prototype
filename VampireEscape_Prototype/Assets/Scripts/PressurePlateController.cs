using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlateController : MonoBehaviour
{
    public SpriteRenderer SpriteRenderer;
    public Sprite offSprite;
    public Sprite OnSprite;
    public bool SteppedOn;
    
    private void Start()
    {
        SpriteRenderer = GetComponent<SpriteRenderer>();
        SpriteRenderer.sprite = offSprite;
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
            }
            else if (!SteppedOn)
            {
                SpriteRenderer.sprite = offSprite;
            }
        
    }
}
