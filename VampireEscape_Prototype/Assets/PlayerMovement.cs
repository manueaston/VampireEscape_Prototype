using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public Transform movePoint;
    public int moveCount = 0;

    public LayerMask whatStopsMovement;

    private bool moving = false;

    // Start is called before the first frame update
    private void Start()
    {
        movePoint.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position != movePoint.position)
        {
            transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);
            moving = true;
        }
        else
        {
            moving = false;
        }

        if (Vector3.Distance(transform.position, movePoint.position) <= 0.05f && !moving)
        {
            if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1.0f)
            {
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0.0f, 0.0f), 0.2f, whatStopsMovement))
                {
                    movePoint.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0.0f, 0.0f);
                    moveCount++;
                    Debug.Log(moveCount);
                }
            }
            else if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1.0f)
            {
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0.0f, Input.GetAxisRaw("Vertical"), 0.0f), 0.2f, whatStopsMovement))
                {
                    movePoint.position += new Vector3(0.0f, Input.GetAxisRaw("Vertical"), 0.0f);
                    moveCount++;
                    Debug.Log(moveCount);
                }
            }
        }  
    }
}
