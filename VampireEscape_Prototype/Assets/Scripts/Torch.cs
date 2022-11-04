using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class Torch : MonoBehaviour
{
    public float minLightIntensity;
    public float maxLightIntensity;
    public float secondsBetweenFlickers;

    private bool activated = true;

    UnityEngine.Rendering.Universal.Light2D torchLight;

    void Start()
    {
        torchLight = GetComponent<UnityEngine.Rendering.Universal.Light2D>();
        StartCoroutine(LightFlicker());
    }

    IEnumerator LightFlicker()
    {
        yield return new WaitForSeconds(secondsBetweenFlickers);
        if (activated)
        {
            torchLight.intensity = Random.Range(minLightIntensity, maxLightIntensity);
        }
        StartCoroutine(LightFlicker());
    }

    public void Deactivate()
    {
        activated = false;
        StopCoroutine(LightFlicker());
        torchLight.intensity = 0;

        // change sprite
    }


    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && activated)
        {
            Debug.Log("Player At Light");
            MoveManager.instance.AddMove();
        }
    }
}
