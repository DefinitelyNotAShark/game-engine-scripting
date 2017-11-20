using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    bool facingRight = true;
    bool grounded = false;

    public Transform groundCheck;
    public LayerMask whatIsGround;

    float groundRadius = 0.2f;
    float move;

    [SerializeField]
    private float jumpForce = 700;

    [SerializeField]
    private float maxSpeed = 10f;

    private bool isOnGround;
    private bool pressedJump;
    private Rigidbody2D myRigidbody2D;

    Animator anim;
    AudioSource audioSource = new AudioSource();

    // Use this for initialization
    void Start()
    {
        myRigidbody2D = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        GetMovementInput();
        DoJump();
    }


    private void FixedUpdate()
    {
        CheckGround();
        HandlePlayerMovement();
    }

    private void HandlePlayerMovement()
    {
        myRigidbody2D.velocity = new Vector2(move * maxSpeed, myRigidbody2D.velocity.y);

        anim.SetFloat("Speed", Mathf.Abs(move));

        if (move > 0 && !facingRight)
        {
            Flip();
        }
        else if (move < 0 && facingRight)
        {
            Flip();
        }
    }

    private void GetMovementInput()
    {
        move = Input.GetAxis("Horizontal");
    }

    void Flip()
    {
        facingRight = !facingRight;

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    void CheckGround()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
        anim.SetBool("Ground", grounded);
        anim.SetFloat("Speed", myRigidbody2D.velocity.y);
    }

    void DoJump()
    {
        pressedJump = Input.GetButtonDown("Jump");

        if (grounded && pressedJump)
        {
            audioSource.Play();
            anim.SetBool("Ground", false);
            myRigidbody2D.AddForce(new Vector2(0, jumpForce));
        }
    }
}