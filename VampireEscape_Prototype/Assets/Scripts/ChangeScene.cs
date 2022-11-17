using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public void LoadScene(int SceneNumber)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneNumber);
    }

    public void Quit()
    {
        Application.Quit();

    }
}