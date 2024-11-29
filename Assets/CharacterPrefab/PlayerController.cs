using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f; // Speed of movement
    public float jumpForce = 10f; // Force applied when jumping

    private Rigidbody2D rb;
    private bool isGrounded;

    void Start()
    {
        // Get the Rigidbody2D component
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Horizontal movement
        float moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        // Check for jump input and ground status
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the player touches any surface
        isGrounded = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        // Check if the player leaves the surface
        isGrounded = false;
    }
}
