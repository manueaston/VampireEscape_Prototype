using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Rock : MonoBehaviour
{
    //Sprite stuff
    private SpriteRenderer spriteRenderer;
    public Sprite unbroken;
    public Sprite broken;
    private UnityEngine.Rendering.Universal.Light2D doorLight;
    //

    public BoxCollider2D rockCollider;
    private bool IsActive = true;

    public void Start()
    {
        doorLight = GetComponent<UnityEngine.Rendering.Universal.Light2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        rockCollider = GetComponent<BoxCollider2D>();
        spriteRenderer.sprite = unbroken;
        gameObject.layer = 6; // Layer StopMovement
        doorLight.enabled = false;
    }
    public void OpenDoor()
    {
        if (IsActive)
        {
            StartCoroutine(OpenDoorCoroutine());
        }
    }

    public IEnumerator OpenDoorCoroutine()
    {
        yield return new WaitForSeconds(0.5f);
        IsActive = false;
        rockCollider.enabled = false;
        spriteRenderer.sprite = broken;
        gameObject.layer = 0; // Layer Default
        doorLight.enabled = true;
    }
}
