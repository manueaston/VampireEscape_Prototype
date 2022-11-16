using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodTrail : MonoBehaviour
{
    public Sprite[] sprites;
    private SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        sr = gameObject.GetComponent<SpriteRenderer>();
        int spriteInt = Random.Range(0, 4);
        sr.sprite = sprites[spriteInt];
    }


}
