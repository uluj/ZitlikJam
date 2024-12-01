using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f; // Speed of movement
    public float jumpForce = 10f; // Force applied when jumping

    public RuntimeAnimatorController badCharacterController;
    public RuntimeAnimatorController goodCharacterController;

    private bool key = true;

    [SerializeField]
    private GameObject bulletPrefab; // Bullet prefab

    [SerializeField]
    private Transform firePoint;

    private Rigidbody2D rb;
    private bool isGrounded;

    private Animator _animator;

    //[SerializeField]
    void Start()
    {
        // Get the Rigidbody2D component
        rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        // bullet scr is in another prefab that is spawning can you use unity events here

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
        //Hey chatgbt can you make g button to change the animator of this character
        if (Input.GetKeyDown(KeyCode.G))
        {

            if (badCharacterController != null && key)
            {
                // Switch to the new controller
                _animator.runtimeAnimatorController = badCharacterController; // Assign the new controller
                Debug.Log("Animator controller switched to 'BadCharacter'");
                key = false;
            }
            else if (badCharacterController != null && !key)
            {
                key = true;
                // Switch to the new controller
                _animator.runtimeAnimatorController = goodCharacterController; // Assign the new controller
                Debug.Log("Animator controller switched to 'GoodCharacter'");
            }
            else
            {
                Debug.LogWarning("Animator Controller 'BadCharacter' not found in Resources folder.");
            }
        }

        if ((Input.GetKeyDown(KeyCode.D) && transform.localScale.x < 0) || (Input.GetKeyDown(KeyCode.A) && transform.localScale.x > 0))
        {
            Vector3 newScale = transform.localScale;
            newScale.x *= -1;
            transform.localScale = newScale;
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            Shoot();
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
    private void Shoot()
    {
        if (bulletPrefab != null && firePoint != null)
        {
            // Instantiate the bullet
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

            // Set the direction of the bullet based on the player's direction
            if (transform.localScale.x > 0)
            {
                bullet.transform.localScale = new Vector3(1, 1, 1);
            }
            else
            {
                bullet.transform.localScale = new Vector3(-1, 1, 1);
            }

            Debug.Log("Bullet fired!");
        }
        else
        {
            Debug.LogWarning("Bullet prefab or fire point not assigned.");
        }
    }
<<<<<<< HEAD
}

=======
}
>>>>>>> 451c3b25397221faae35c20b655a2231801a0350
