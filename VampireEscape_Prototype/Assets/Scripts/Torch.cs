using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class Torch : MonoBehaviour
{
    public float minLightIntensity;
    public float maxLightIntensity;
    public float secondsBetweenFlickers;

    UnityEngine.Rendering.Universal.Light2D torchLight;

    void Start()
    {
        torchLight = GetComponent<UnityEngine.Rendering.Universal.Light2D>();
        StartCoroutine(LightFlicker());
    }

    IEnumerator LightFlicker()
    {
        yield return new WaitForSeconds(secondsBetweenFlickers);
        torchLight.intensity = Random.Range(minLightIntensity, maxLightIntensity);
        StartCoroutine(LightFlicker());
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
