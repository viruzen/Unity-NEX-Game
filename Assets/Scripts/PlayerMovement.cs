using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 6f;          // Movement speed
    public float jumpForce = 5f;      // Jump force
    public float groundCheckDistance = 0.1f;  // Distance to check if the player is grounded
    public LayerMask groundMask;      // Layer mask for identifying ground

    private Rigidbody rb;
    private Vector3 movement;
    private bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // Get player input
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        // Create movement vector
        movement = transform.right * moveX + transform.forward * moveZ;

        // Jumping
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            Jump();
        }
    }

    // FixedUpdate is called at fixed intervals (better for physics)
    void FixedUpdate()
    {
        // Apply movement
        MovePlayer();
    }

    void MovePlayer()
    {
        Vector3 velocity = movement * speed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + velocity);
    }

    void Jump()
    {
        // Apply upward force for jumping
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    // Check if player is grounded
    bool IsGrounded()
    {
        // Raycast down to check if we're near the ground
        RaycastHit hit;
        isGrounded = Physics.Raycast(transform.position, Vector3.down, out hit, groundCheckDistance, groundMask);
        return isGrounded;
    }
}
