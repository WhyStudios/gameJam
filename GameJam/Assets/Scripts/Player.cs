using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Transform checkGround;
    public LayerMask groundLayer;

    public float radius;
    public Transform checkDeathStart;
    public Transform checkDeathEnd;
    public LayerMask enemyLayer;

    private int distance;
    private float gravity = -20f;
    private float rotationSpeed = 6f;
    private bool isGrounded = false;
    private bool died = false;

    public bool isDead { get => died; }

    private Vector3 rotation;
    private MenuManager menuManager;
    private float timeToAddDistance;

    private Animator animator;

    void Start()
    {
        Physics.gravity = new Vector3(0f, gravity);
        menuManager = FindObjectOfType<MenuManager>();
        animator = GetComponentInChildren<Animator>();
    }
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && isGrounded && !died) SetGravity();
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(rotation), rotationSpeed * Time.deltaTime);

        isGrounded = Physics.CheckSphere(checkGround.position, 0.1f, groundLayer);
        if (Physics.CheckCapsule(checkDeathStart.position, checkDeathEnd.position, radius, enemyLayer) && !died) Morreu();

        animator.SetBool("IsGrounded", isGrounded);
        animator.SetBool("Died", died);
    }

    void SetGravity()
    {
        gravity *= -1;

        float impulseForce = GameManager.impulseForce;
        GetComponent<Rigidbody>().AddForce(new Vector3(0f, impulseForce * Mathf.Sign(gravity), 0f));

        rotation = (gravity > 0)? new Vector3(-180f, 0f, 0f) : Vector3.zero;
        Physics.gravity = new Vector3(0f, gravity);
    }

    void Morreu()
    {
        died = true;
        GameManager.StopGameplay();
        menuManager.SetGameOverMenu();
    }

    private void OnCollisionStay(Collision other)
    {
        //if (other.collider.CompareTag("Ground")) isGrounded = true;
        if (other.collider.GetComponent<Obstacle>() && !died) Morreu();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.GetComponent<Obstacle>()) Morreu(); 
    }

    //private void OnCollisionExit(Collision other)
    //{
    //    if (other.collider.CompareTag("Ground")) isGrounded = false;
    //}

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(checkGround.position, 0.1f);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(checkDeathStart.position, radius);
        Gizmos.DrawWireSphere(checkDeathEnd.position, radius);
    }
}
