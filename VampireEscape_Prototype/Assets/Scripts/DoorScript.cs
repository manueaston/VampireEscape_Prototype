using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    public bool IsDoorOpen;

    public void Start()
    {
        gameObject.SetActive(false);
    }
    public void OpenDoor()
    {
        if(!IsDoorOpen)
        {
            IsDoorOpen = true;
            gameObject.SetActive(true);
              
        }
    }

    public void Reset()
    {
        IsDoorOpen = false;
        gameObject.SetActive(false);
    }
}
