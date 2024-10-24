//using UnityEngine;

//public class PlayerMovement : MonoBehaviour
//{
//    public float speed = 6f;                  // Movement speed
//    public float jumpForce = 5f;              // Jump force
//    public float groundCheckDistance = 0.1f;  // Distance to check if the player is grounded
//    public LayerMask groundMask;              // Layer mask for identifying ground

//    private Rigidbody rb;
//    private Vector3 movement;
//    private bool isGrounded;
//    private Camera mainCamera;

//    // Start is called before the first frame update
//    void Start()
//    {
//        rb = GetComponent<Rigidbody>();
//        mainCamera = Camera.main;  // Get reference to the main camera
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        // Handle movement input
//        HandleMovementInput();

//        // Rotate the player towards the mouse cursor
//        RotateTowardsMouse();
//    }

//    // FixedUpdate is called at fixed intervals (better for physics)
//    void FixedUpdate()
//    {
//        // Apply movement to the player
//        MovePlayer();
//    }

//    // Handle movement input (WASD keys)
//    void HandleMovementInput()
//    {
//        float moveX = 0f;
//        float moveZ = 0f;

//        if (Input.GetKey(KeyCode.W)) moveZ = 1f;    // Move forward
//        if (Input.GetKey(KeyCode.S)) moveZ = -1f;   // Move backward
//        if (Input.GetKey(KeyCode.A)) moveX = -1f;   // Move left
//        if (Input.GetKey(KeyCode.D)) moveX = 1f;    // Move right

//        // Create movement vector
//        movement = transform.right * moveX + transform.forward * moveZ;

//        // Jumping on space bar
//        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
//        {
//            Jump();
//        }
//    }

//    // Move the player
//    void MovePlayer()
//    {
//        Vector3 velocity = movement * speed * Time.fixedDeltaTime;
//        rb.MovePosition(rb.position + velocity);
//    }

//    // Jump function
//    void Jump()
//    {
//        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
//    }

//    // Check if the player is grounded
//    bool IsGrounded()
//    {
//        RaycastHit hit;
//        isGrounded = Physics.Raycast(transform.position, Vector3.down, out hit, groundCheckDistance, groundMask);
//        return isGrounded;
//    }

//    // Rotate player to look at where the mouse is pointing
//    void RotateTowardsMouse()
//    {
//        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
//        RaycastHit hit;

//        if (Physics.Raycast(ray, out hit, Mathf.Infinity, groundMask))
//        {
//            // Find the direction from the player to the point where the ray hit
//            Vector3 targetPosition = new Vector3(hit.point.x, transform.position.y, hit.point.z); // Keep player's Y position the same
//            Vector3 direction = (targetPosition - transform.position).normalized;

//            // Rotate player to face the direction
//            Quaternion lookRotation = Quaternion.LookRotation(direction);
//            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 10f);  // Smooth rotation
//        }
//    }
//}
