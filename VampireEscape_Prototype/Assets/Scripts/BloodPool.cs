using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodPool : MonoBehaviour
{
    public int movesAdded;
    private bool active = true;

    //Sprite stuff
    private SpriteRenderer spriteRenderer;
    public Sprite rat;
    public Sprite noRat;
    //

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = rat;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && active)
        {
            Debug.Log("Player At Blood Pool");
            MoveManager.instance.DecreaseMoves(movesAdded);
            active = false;
            spriteRenderer.sprite = noRat;
        }
    }
}
