using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public GameObject[] doors;

    public void Reset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        //player.GetComponent<PlayerMovement>().Reset();
        
        //foreach (GameObject door in doors)
        //{
        //    door.GetComponent<DoorScript>().Reset();
        //}
    }
}
