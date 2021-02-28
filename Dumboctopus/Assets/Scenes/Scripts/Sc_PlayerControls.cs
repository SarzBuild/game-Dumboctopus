using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sc_PlayerControls : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameObject createdPlatform;
    private KeyCode inputSkill = KeyCode.Q;
    private KeyCode inputRight = KeyCode.D;
    private KeyCode inputLeft = KeyCode.A;
    private KeyCode inputJump = KeyCode.Space;

    public float acceleration = 0.01f;
    public float speed;
    public float baseSpeed = 10;
    public float speedCap = 16f;
    private bool goingLeft;
    private bool goingRight;

    public bool isGrounded = true;
    public float jumpForce = 17f;

    public float jumpChargeLimit = 0.7f;
    public float jumpTimeCounter = 0f;
    public float jumpChargeMultiplier = 14f;

    public Transform groundCheck;
    public float groundCheckRadius;
    private Sc_GroundChecker sc_GroundChecker;

    public float platformCreationCooldown = 3;
    public float platformCreationTimer = 0;

    void Start()
    {

    rb = GetComponent<Rigidbody2D>();

    sc_GroundChecker = GetComponentInChildren<Sc_GroundChecker>();
    }


    void Update()
    {
        isGrounded = sc_GroundChecker.isGrounded;

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

        if (Input.GetKeyDown(inputSkill) && platformCreationTimer <= 0)
            CreatePlatform();

        if (platformCreationTimer > 0)
            platformCreationTimer -= Time.deltaTime;

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

    void CreatePlatform()
    {
        Vector3 v3 = new Vector3(transform.position.x, transform.position.y - 3, transform.position.z);
        Instantiate(createdPlatform, v3, transform.rotation);

        platformCreationTimer = platformCreationCooldown;
        //need to add a 30 to 45 seconds penalty to the countdown here once the countdown is done.
    }
}
