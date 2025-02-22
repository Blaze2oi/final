using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;  // Movement speed of the player
    public float jumpForce = 7f;  // Jump force

    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private bool canJump;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>(); // Get the Animator component
        spriteRenderer = GetComponent<SpriteRenderer>(); // Get the SpriteRenderer component
        rb.freezeRotation = true; // Prevents rotation
    }

    void Update()
    {
        // Get movement input (horizontal axis)
        float moveHorizontal = Input.GetAxis("Horizontal");

        // Apply movement to Rigidbody2D
        rb.linearVelocity = new Vector2(moveHorizontal * moveSpeed, rb.linearVelocity.y);

        // Set animation state
        animator.SetFloat("Speed", Mathf.Abs(moveHorizontal)); // Absolute value to handle left/right movement

        // Flip the character when moving left
        if (moveHorizontal > 0)
        {
            spriteRenderer.flipX = false; // Face right
        }
        else if (moveHorizontal < 0)
        {
            spriteRenderer.flipX = true; // Face left
        }

        // Jumping mechanic - Allow jump only when grounded
        if (canJump && Input.GetButtonDown("Jump"))
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0);  // Reset vertical velocity
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            canJump = false; // Prevents double jumps
        }
    }

    // Ground detection using collision
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            canJump = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            canJump = false;
        }
    }
}
