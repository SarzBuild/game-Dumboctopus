using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class walkAndJump : MonoBehaviour
{
    public Rigidbody2D rb;
    public KeyCode inputRight = KeyCode.D;
    public KeyCode inputLeft = KeyCode.A;
    public KeyCode inputJump = KeyCode.Space;

    public float acceleration = 0.01f;
    public float speed;
    public float baseSpeed = 7;
    public float speedCap = 14f;
    public bool goingLeft;
    public bool goingRight;


    public LayerMask whatIsGround;
    public bool isGrounded = true;
    public float jumpForce = 10f;

    public float jumpChargeLimit = 0.7f;
    public float jumpTimeCounter = 0f;
    public float jumpChargeMultiplier = 12f;
    public bool isJumping;

    public Transform groundCheck;
    public float groundCheckRadius;

    private groundChecker groundChecker;
    void Start()
    {

    rb = GetComponent<Rigidbody2D>();

    groundChecker = GetComponentInChildren<groundChecker>();
    }


    void Update()
    {
        isGrounded = groundChecker.isGrounded;

        if (Input.GetKeyUp(inputJump) && isGrounded)
            Jump();

        if (Input.GetKey(inputJump) && isGrounded)
        {
            if (jumpTimeCounter < jumpChargeLimit)
                jumpTimeCounter += Time.deltaTime;
            if (jumpTimeCounter > jumpChargeLimit)
                jumpTimeCounter = jumpChargeLimit;
        }
        else
        {
            jumpTimeCounter = 0;
            Run();
        }

    }

    void Run()
    {
        if (Input.GetKeyDown(inputRight))
        {
            goingRight = true;
            goingLeft = false;
        }
        else if (Input.GetKeyDown(inputLeft))
        {
            goingLeft = true;
            goingRight = false;
        }

        if (goingRight && !Input.GetKey(inputRight))
        {
            goingRight = false;
            if (Input.GetKey(inputLeft))
                goingLeft = true;
        }
        if (goingLeft && !Input.GetKey(inputLeft))
        {
            goingLeft = false;
            if (Input.GetKey(inputRight))
                goingRight = true;
        }

        if (goingRight)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            if (speed <= speedCap)
                speed += acceleration;
        }

        if (goingLeft)
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
            if (speed <= speedCap)
                speed += acceleration;
        }

        if (!goingLeft && !goingRight)
            speed = baseSpeed;
    }

    void Jump()
    {
        Vector3 v3 = new Vector3(0, jumpTimeCounter * jumpChargeMultiplier, 0);
        rb.AddForce((transform.up * jumpForce) + v3, ForceMode2D.Impulse);
    }
}
