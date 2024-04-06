using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour
{
    public float speed;
    public float turnSpeed;
    
    public Rigidbody rb;
    
    public float horizontalInput;
    public float verticalInput;
    
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    
    private void Update()
    {
        SetInputs();
        Turn();
        Move();
    }

    private void Move()
    {
        Vector3 movement = transform.forward * verticalInput * speed * Time.deltaTime;
        rb.MovePosition(rb.position + movement);
    }

    private void SetInputs()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
    }

    private void Turn()
    {
        float turn = horizontalInput * turnSpeed * Time.deltaTime;
        Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);
        rb.MoveRotation(rb.rotation * turnRotation);
    }
}
