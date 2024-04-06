using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;

    public float normalSpeed;
    public float boostedSpeed;
    
    public float jumpForce;
    public bool isGrounded;
    
    public float horizontalInput;
    public float verticalInput;
    
    public Rigidbody rb;

    public int score;

    public TMP_Text scoreText;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    
    void Update()
    {
        SetInputs();
        
        rb.AddForce(new Vector3(horizontalInput,0,verticalInput)*speed* Time.deltaTime);
        
        Jump();
    }

    private void SetInputs()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = boostedSpeed;
        }
        else
        {
            speed = normalSpeed;
        }
        
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(new Vector3(0,jumpForce,0));
            isGrounded = false;
        }
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }

        if (collision.gameObject.CompareTag("Lava"))
        {
            transform.localScale = transform.localScale * 0.8f;
            Destroy(collision.gameObject);
            score--;
            scoreText.text = "Score: " + score;
        }

        if (collision.gameObject.CompareTag("Water"))
        {
            transform.localScale = transform.localScale * 1.2f;
            Destroy(collision.gameObject);
            score++;
            scoreText.text = "Score: " + score;
        }
    }
    
}
