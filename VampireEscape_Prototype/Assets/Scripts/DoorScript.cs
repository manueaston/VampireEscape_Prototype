using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorScript : MonoBehaviour
{
    public SpriteRenderer SpriteRenderer;
    public BoxCollider2D BoxCollider;
    public Sprite ClosedSprite;
    public Sprite OpenSprite;
    public int LevelIndex;
    public bool StayOpen;
    private bool isOpen = false;
    public bool exitDoor = true;
    public bool OnTimer = false;
    public int defultMoveTimer = -1;
    private int MoveTimer;

    // Door light
    UnityEngine.Rendering.Universal.Light2D doorLight;

    public void Start()
    {
        MoveTimer = defultMoveTimer;
        LevelIndex = SceneManager.GetActiveScene().buildIndex;
        SpriteRenderer = GetComponent<SpriteRenderer>();
        SpriteRenderer.sprite = ClosedSprite;
        if (StayOpen)
        {
            isOpen = true;
            SpriteRenderer.sprite = OpenSprite;
        }
        else
        {
            doorLight.enabled = false; // disable light
        }

        doorLight = GetComponent<UnityEngine.Rendering.Universal.Light2D>();
        
    }

    public void OpenDoor()
    {
        BoxCollider = GetComponent<BoxCollider2D>();

        if (!isOpen)
        {
            isOpen = true;
            SpriteRenderer.sprite = OpenSprite;
            doorLight.enabled = true; // enable light
        }
        else if (isOpen)
        {
            isOpen = false;
            SpriteRenderer.sprite = ClosedSprite;
            BoxCollider.enabled = true;
            doorLight.enabled = false; // disbale light
        }

        if (!exitDoor && isOpen)
        {
            
            BoxCollider.enabled = false;
        }

    }

    //public void Reset()
    //{
    //    doorOpen = false;
    //    gameObject.SetActive(false);
    //}
    private void Awake()
    {
        
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && isOpen&&exitDoor)
        {
            Debug.Log("Player At Door");
            SceneManager.LoadScene(LevelIndex+1);
        }
       
    }
    public void PressurePadTimer()
    {
        if(MoveTimer > 0)
        {
            MoveTimer -= 1;
        }
        else if(MoveTimer == 0)
        {
            OpenDoor();
            MoveTimer = defultMoveTimer;
        }
    }
}
