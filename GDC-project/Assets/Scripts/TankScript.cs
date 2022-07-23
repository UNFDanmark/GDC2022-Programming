using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankScript : MonoBehaviour
{
    public float speed = 1;
    public float turnSpeed = 1;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveInput = Input.GetAxis("Vertical");
        float turnInput = Input.GetAxis("Horizontal");

        float moveSpeed = speed * moveInput;

        Vector3 newVelocity = transform.forward * moveSpeed;
        newVelocity.y = rb.velocity.y;

        

        gameObject.GetComponent<Transform>().Rotate(Vector3.up * turnInput * turnSpeed);

        rb.velocity = newVelocity;
    }
}
