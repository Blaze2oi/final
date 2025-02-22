using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;  // Movement speed of the player
    public float jumpForce = 7f;  // Jump force
    public Transform groundCheck; // Ground check position (to detect if the player is on the ground)
    public LayerMask groundLayer; // The layer of the ground

    private Rigidbody2D rb;
    private bool isGrounded;
    private float groundCheckRadius = 0.2f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // Lock the rotation of the Rigidbody2D to prevent tipping over
        rb.freezeRotation = true;
    }

    void Update()
    {
        // Check if the player is on the ground
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        // Get movement input (horizontal axis only for 2D)
        float moveHorizontal = Input.GetAxis("Horizontal");

        // Move the player horizontally
        Vector2 movement = new Vector2(moveHorizontal, 0).normalized;

        // Apply movement to Rigidbody2D
        rb.linearVelocity = new Vector2(movement.x * moveSpeed, rb.linearVelocity.y);

        // Jumping mechanic - Allow jump only when grounded
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0);  // Reset vertical velocity to ensure the player doesn't get a speed boost from multiple jumps
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }
}
