using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMoveSpeed : MonoBehaviour
{

    public float maxSpeed;
    public float acceleration;
    public Rigidbody2D rb;
    public bool isOnGround;
    public float jumpForce;
    public float secondaryJumpForce;
    public float secondaryJumpDelay;
    public bool secondaryJump;
    public Animator animator;
    // Start is called before the first frame update
    
    void Start()
    {
        animator = gameObject.GetComponentInChildren<Animator>();
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("speed", Math.Abs(rb.velocity.x));
        if (
            Math.Abs(rb.velocity.magnitude) < maxSpeed &&
            Math.Abs(Input.GetAxis("Horizontal")) >= 0)
        {
         rb.AddForce(new Vector2(acceleration * Input.GetAxis("Horizontal"), 0), ForceMode2D.Force);   
        }
        
        if(Input.GetButtonDown("Jump") && isOnGround)
        {
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            StartCoroutine(SecondaryJump());
        }

        if (Input.GetButtonDown("Jump") &&  secondaryJump == true  && !isOnGround)
        {
            rb.AddForce(new Vector2(0, secondaryJumpForce), ForceMode2D.Force);
        }
    }


    private void OnTriggerStay2D(Collider2D other)
    {
       isOnGround = true;
       
    }

    private void OnTriggerExit2D(Collider2D other)
    {
       isOnGround = false; 
    }
    
    IEnumerator SecondaryJump()
    {
        secondaryJump = true;
        yield return new WaitForSeconds(secondaryJumpDelay);
        secondaryJump = false;
        yield return null;
    }
}
