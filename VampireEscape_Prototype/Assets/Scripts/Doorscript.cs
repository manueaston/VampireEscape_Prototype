using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doorscript : MonoBehaviour
{
    public bool IsOpen;
    public void OpenDoor()
    {
        if(!IsOpen)
        {
            IsOpen = true;
            Debug.Log("Door opens");
        }
    }

}
