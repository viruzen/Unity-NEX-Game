using UnityEngine;

public class PlayerMovementAndShooting : MonoBehaviour
{
    // Movement variables
    public float speed = 6f;                  // Movement speed
    public float jumpForce = 5f;              // Jump force
    public float groundCheckDistance = 0.1f;  // Distance to check if the player is grounded
    public LayerMask groundMask;              // Layer mask for identifying ground

    // Shooting variables
    public Transform firePoint;               // The point from where bullets will be fired
    public GameObject bulletPrefab;           // The bullet prefab
    public float bulletSpeed = 20f;           // Speed of the bullet
    public float fireRate = 0.5f;             // Time between shots

    private Rigidbody rb;
    private Vector3 movement;
    private bool isGrounded;
    private float nextFireTime = 0f;
    private Camera mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        mainCamera = Camera.main;  // Get reference to the main camera
    }

    // Update is called once per frame
    void Update()
    {
        // Handle movement input
        HandleMovementInput();

        // Rotate the player towards the mouse cursor
        RotateTowardsMouse();

        // Handle shooting input
        HandleShootingInput();
    }

    // FixedUpdate is called at fixed intervals (better for physics)
    void FixedUpdate()
    {
        // Apply movement to the player
        MovePlayer();
    }

    // Handle movement input (WASD keys)
    void HandleMovementInput()
    {
        float moveX = 0f;
        float moveZ = 0f;

        if (Input.GetKey(KeyCode.W)) moveZ = 1f;    // Move forward
        if (Input.GetKey(KeyCode.S)) moveZ = -1f;   // Move backward
        if (Input.GetKey(KeyCode.A)) moveX = -1f;   // Move left
        if (Input.GetKey(KeyCode.D)) moveX = 1f;    // Move right

        // Create movement vector
        movement = transform.right * moveX + transform.forward * moveZ;

        // Jumping on space bar
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            Jump();
        }
    }

    // Move the player
    void MovePlayer()
    {
        Vector3 velocity = movement * speed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + velocity);
    }

    // Jump function
    void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    // Check if the player is grounded
    bool IsGrounded()
    {
        RaycastHit hit;
        isGrounded = Physics.Raycast(transform.position, Vector3.down, out hit, groundCheckDistance, groundMask);
        return isGrounded;
    }

    // Rotate player to look at where the mouse is pointing
    void RotateTowardsMouse()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        // Cast a ray from the camera to the mouse position
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, groundMask))
        {
            // Get the point where the ray hit
            Vector3 targetPosition = new Vector3(hit.point.x, transform.position.y, hit.point.z); // Maintain player's current Y position

            // Calculate direction to look at
            Vector3 direction = (targetPosition - transform.position).normalized;

            // Rotate player towards the direction
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 10f);  // Smooth rotation
        }
    }

    // Handle shooting input (mouse click)
    void HandleShootingInput()
    {
        // Shoot when left mouse button is pressed and enough time has passed since the last shot
        if (Input.GetMouseButton(0) && Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireRate;
        }
    }

    // Shoot bullets from the firePoint
    void Shoot()
    {
        // Instantiate the bullet at the fire point
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();

        // Apply velocity to the bullet in the forward direction of the firePoint
        bulletRb.velocity = firePoint.forward * bulletSpeed;
    }
}
