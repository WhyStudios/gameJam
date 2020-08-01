using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float gravity = -20f;
    private float rotationSpeed = 6f;
    private bool isGrounded = false;

    private Vector3 rotation;

    void Start()
    {
        Physics.gravity = new Vector3(0f, gravity);
    }
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && isGrounded) SetGravity();

        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(rotation), rotationSpeed * Time.deltaTime);
    }

    void SetGravity()
    {
        gravity *= -1;

        rotation = (gravity > 0)? new Vector3(-180f, 0f, 0f) : Vector3.zero;
        Physics.gravity = new Vector3(0f, gravity);
    }

    void Morreu()
    {
        Time.timeScale = 0f;

        Debug.Log("Morreu");
    }

    private void OnCollisionStay(Collision other)
    {
        if (other.collider.CompareTag("Ground")) isGrounded = true;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.GetComponent<Obstacle>()) Morreu(); 
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.collider.CompareTag("Ground")) isGrounded = false;
    }


}
