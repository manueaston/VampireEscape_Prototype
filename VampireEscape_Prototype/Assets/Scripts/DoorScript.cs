using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    private bool IsDoorOpen;
    public void Start()
    {
        gameObject.SetActive(false);
    }
    public void openDoor()
    {
        if (!IsDoorOpen)
        {
            gameObject.SetActive(true);
        }
    }    
}
