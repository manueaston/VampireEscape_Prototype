using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public Transform movePoint;
    public Vector3 startPoint;

    public LayerMask whatStopsMovement;

    private bool moving = false;

    // Start is called before the first frame update
    private void Start()
    {
        movePoint.parent = null;
        startPoint = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position != movePoint.position) // if player is already moving to tile
        {
            transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);
            moving = true;
        }
        else
        {
            moving = false;
        }

        // check if player is already moving, and if they have no moves left
        if (!moving && MoveManager.instance.currentMoves < MoveManager.instance.maxMoves)
        {
            if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1.0f)
            {
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0.0f, 0.0f), 0.2f, whatStopsMovement))
                {
                    movePoint.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0.0f, 0.0f);
                    MoveManager.instance.AddMove();
                }
            }
            else if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1.0f)
            {
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0.0f, Input.GetAxisRaw("Vertical"), 0.0f), 0.2f, whatStopsMovement))
                {
                    movePoint.position += new Vector3(0.0f, Input.GetAxisRaw("Vertical"), 0.0f);
                    MoveManager.instance.AddMove();
                }
            }
        }  
    }

    //public void Reset()
    //{
    //    Debug.Log("success");
    //    MoveManager.instance.Reset();
    //    movePoint.position = startPoint;
    //    transform.position = startPoint;
    //}
}
