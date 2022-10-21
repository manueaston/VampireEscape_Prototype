using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public GameObject[] doors;

    public void Reset()
    {
        player.GetComponent<PlayerMovement>().Reset();
        
        foreach (GameObject door in doors)
        {
            door.GetComponent<DoorScript>().Reset();
        }
    }
}
