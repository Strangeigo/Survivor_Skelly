using UnityEngine;

/// <summary>
/// Controls player movement using WASD or arrow keys
/// </summary>
public class PlayerController : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float moveSpeed = 5f;
    
    private Rigidbody2D rb;
    private Vector2 moveInput;
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
    private void Update()
    {
        // Get input from player
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");
        
        // Normalize diagonal movement
        moveInput = moveInput.normalized;
    }
    
    private void FixedUpdate()
    {
        // Apply movement
        rb.velocity = moveInput * moveSpeed;
    }
}
