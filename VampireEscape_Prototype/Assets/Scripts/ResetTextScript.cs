using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResetTextScript : MonoBehaviour
{
    public bool active = true;
    public float jitterAmount;
    public float waitTime;
    public Text text;
    private Vector3 startPosition;

    // Bolder Red
    float r = 147.0f, g = 26.0f, b = 26.0f, a = 255.0f; //Does this need to be here?

    void Start()
    {
        startPosition = transform.position;
        text = gameObject.GetComponent<Text>();
    }

    public void StartJitter()
    {
        active = true;
        //text.color = new Color(r, g, b, a);
        StartCoroutine(Jitter());
    }

    public IEnumerator Jitter()
    {
        while (active)
        {
            yield return new WaitForSeconds(waitTime);
            transform.position = new Vector3(startPosition.x + Random.Range(-1 * jitterAmount, jitterAmount), startPosition.y + Random.Range(-1 * jitterAmount, jitterAmount), 0);
        }
    }
}
