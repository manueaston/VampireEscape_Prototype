using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    public bool IsDoorOpen;

    public void Start()
    {
        gameObject.SetActive(true);
    }
    public void OpenDoor()
    {
        if (!IsDoorOpen)
        {
            IsDoorOpen = true;
            gameObject.SetActive(false);

        }
    }
    public void Reset()
    {
        IsDoorOpen = false;
        gameObject.SetActive(true);
    }
}
