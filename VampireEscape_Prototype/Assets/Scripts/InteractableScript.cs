using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractableScript : MonoBehaviour
{
    public bool isInRange;
   // public KeyCode InteractKey;
    public UnityEvent InteractAction;
    // Start is called before the first frame   
   

    // Update is called once per frame
    void Update()
    {

           
    }
    public void OnTriggerEnter2D(Collider2D collision)
    { 
        if (collision.gameObject.CompareTag("Player"))
        {
            isInRange = true;
            //Debug.Log("Player is on " + gameObject);
            InteractAction.Invoke();
        } 
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        
        if (collision.gameObject.CompareTag("Player"))
        {
            isInRange = false;
           // Debug.Log("Player is off " + gameObject);
        }
    }
}
