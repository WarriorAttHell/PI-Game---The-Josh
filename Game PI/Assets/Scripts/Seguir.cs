using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Seguir : MonoBehaviour
{

    private Rigidbody myRigidbody;
    private float horizontalInput;
    public float force = 3;
    public float jumpForce = 10;

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
    }

    private void FixedUpdate()
    {
        myRigidbody.AddForce(Vector3.forward * myRigidbody.mass * force * horizontalInput);
    }

    public void Pulo()
    {
        myRigidbody.AddForce(Vector3.up * myRigidbody.mass * jumpForce, ForceMode.Impulse);
    }
}
