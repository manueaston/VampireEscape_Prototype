using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject player;

    public int levelMaxMoves;

    //Audio Controller
    public AudioSource audioSource;
    public AudioClip audioClip;
    [Range(0, 1)] public float volume;

    void Start()
    {
        //StartCoroutine(MoveManager.instance.ScreenFadeIn());
        
        soundHandler();
    }

    public void Reset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
    public void Update()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            Reset();
        }
    }

    public void soundHandler()
    {
        if (!audioSource.isPlaying)
        {
            audioSource = GetComponent<AudioSource>();
            audioSource.PlayOneShot(audioClip, volume);
        }
    }
}
