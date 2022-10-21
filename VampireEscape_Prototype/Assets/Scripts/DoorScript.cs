using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    //public bool doorOpen;

    //public void Start()
    //{
    //    gameObject.SetActive(false);
    //}

    //public void OpenDoor()
    //{
    //    if(!doorOpen)
    //    {
    //        doorOpen = true;
    //        gameObject.SetActive(true);
              
    //    }
    //}

    //public void Reset()
    //{
    //    doorOpen = false;
    //    gameObject.SetActive(false);
    //}

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player At Door");
        }
    }
}
