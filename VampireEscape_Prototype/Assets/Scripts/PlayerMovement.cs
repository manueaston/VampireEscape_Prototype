using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 2.5f;
    public Transform movePoint;
    public Vector3 startPoint;

    public LayerMask whatStopsMovement;

    public bool moving = false;
    public bool dying = false;
    public bool onBloodTrail = false;

    private Animator animator;

    public GameObject bloodTrail;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

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
            animator.SetBool("IsWalking", false);

            if (MoveManager.instance.currentMoves >= MoveManager.instance.maxMoves)
            {
                Die();
            }
        }

        // check if player has used all moves
        if (MoveManager.instance.currentMoves < MoveManager.instance.maxMoves)
        {
            // check if player is already moving
            if (!moving)
            {
                

                if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1.0f)
                {
                    // for animation
                    animator.SetFloat("X", Input.GetAxisRaw("Horizontal"));
                    animator.SetFloat("Y", 0);
                    animator.SetBool("IsWalking", true);
                    //idle = false;

                    if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0.0f, 0.0f), 0.2f, whatStopsMovement))
                    {
                        movePoint.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0.0f, 0.0f);
                        MoveManager.instance.AddMove();
                    }
                }
                else if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1.0f)
                {
                    // for animation
                    animator.SetFloat("X", 0);
                    animator.SetFloat("Y", Input.GetAxisRaw("Vertical"));
                    animator.SetBool("IsWalking", true);
                    //idle = false;

                    if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0.0f, Input.GetAxisRaw("Vertical"), 0.0f), 0.2f, whatStopsMovement))
                    {
                        movePoint.position += new Vector3(0.0f, Input.GetAxisRaw("Vertical"), 0.0f);
                        MoveManager.instance.AddMove();
                    }
                }

                // create blood trail
                if (!onBloodTrail)
                {
                    Instantiate(bloodTrail, transform.position, Quaternion.identity);
                    onBloodTrail = true;
                }
            }
        }
    }

    private void Die()
    {
        animator.SetBool("IsDying", true);
        dying = true;
        StartCoroutine(MoveManager.instance.ScreenFadeOut(0.25f));
    }

    // Sets onBloodTrail variable
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("BloodTrail"))
        {
            onBloodTrail = true;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("BloodTrail"))
        {
            onBloodTrail = false;
        }
    }
}
