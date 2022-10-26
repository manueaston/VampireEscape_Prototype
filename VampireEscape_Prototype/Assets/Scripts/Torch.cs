using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torch : MonoBehaviour
{
    public float minLightIntensity;
    public float maxLightIntensity;
    public float timeBetweenFlickers;

    // Update is called once per frame
    void Update()
    {
        Flicker();
    }

    // Light Flicker
    void Flicker()
    {
        // Flicker script
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player At Light");
            MoveManager.instance.AddMove();
        }
    }
}
