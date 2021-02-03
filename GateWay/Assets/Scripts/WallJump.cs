using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WallJump : MonoBehaviour
{
    public float walkSpeed;
    private float moveInput;
    public float jumpSpeed;
    private bool isGrounded;
    private Rigidbody2D rb;
    public LayerMask groundMask;
    public PlayerMoveController playerMoveController;

    private bool isTouchingLeft;
    private bool isTouchingright;
    private bool wallJumping;
    private float touchingLeftOrRight;
    // Start is called before the first frame update
    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        moveInput = Input.GetAxisRaw("Horizontal");

        rb.velocity = new Vector2(moveInput * walkSpeed, rb.velocity.y);
        
        if(Input.GetKeyDown("space") && isGrounded)
        {
            playerMoveController.JButtonDown();
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
        }

        isGrounded = Physics2D.OverlapBox(new Vector2(gameObject.transform.position.x, gameObject.transform.position.y - 0.5f),
            new Vector2(0.9f, 0.2f), 0f, groundMask);

        isTouchingLeft = Physics2D.OverlapBox(new Vector2(gameObject.transform.position.x -0.5f, gameObject.transform.position.y),
           new Vector2(0.9f, 0.2f), 0f, groundMask);

        isTouchingLeft = Physics2D.OverlapBox(new Vector2(gameObject.transform.position.x + 0.5f, gameObject.transform.position.y),
           new Vector2(0.9f, 0.2f), 0f, groundMask);
        if(isTouchingLeft)
        {
            touchingLeftOrRight = 1;
        }
        else if(isTouchingright)
        {
            touchingLeftOrRight = -1;
        }

        if(Input.GetKeyDown("space") && (isTouchingright || isTouchingLeft) && !isGrounded)
        {
            wallJumping = true;
            Invoke("SetJumpingToFalse", 0.08f);
        }

        if(wallJumping)
        {
            rb.velocity = new Vector2(walkSpeed * touchingLeftOrRight, jumpSpeed);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawCube(new Vector2(gameObject.transform.position.x, gameObject.transform.position.y - 0.5f), new Vector2(0.9f, 0.2f));
        Gizmos.color = Color.blue;
        Gizmos.DrawCube(new Vector2(gameObject.transform.position.x - 0.5f, gameObject.transform.position.y), new Vector2(0.2f, 0.2f));
        Gizmos.DrawCube(new Vector2(gameObject.transform.position.x + 0.5f, gameObject.transform.position.y), new Vector2(0.2f, 0.2f));
    }
    
    void SetJumpingToFalse()
    {
        wallJumping = false;
    }
}
