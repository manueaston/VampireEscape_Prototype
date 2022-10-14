using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ActivateFOWOnLayer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        TilemapRenderer renderer = GetComponent<TilemapRenderer>();
        renderer.maskInteraction = SpriteMaskInteraction.VisibleInsideMask;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
