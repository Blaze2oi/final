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
    }

    void Update()
    {
        // Check if player is grounded
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        // Get movement input (horizontal axis only for 2D)
        float moveHorizontal = Input.GetAxis("Horizontal");

        // Move the player horizontally
        Vector2 movement = new Vector2(moveHorizontal, 0).normalized;

        // Apply movement to Rigidbody2D
        rb.linearVelocity = new Vector2(movement.x * moveSpeed, rb.linearVelocity.y);

        // Jumping mechanic
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }
}
