using UnityEngine;

/// <summary>
/// Basic enemy AI that chases and attacks the player
/// </summary>
public class EnemyAI : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private float rotationSpeed = 5f;
    
    [Header("Attack Settings")]
    [SerializeField] private int attackDamage = 10;
    [SerializeField] private float attackRange = 1.5f;
    [SerializeField] private float attackCooldown = 1f;
    
    private Transform player;
    private Rigidbody rb;
    private float nextAttackTime = 0f;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            rb = gameObject.AddComponent<Rigidbody>();
        }
        rb.freezeRotation = true;
        
        // Find player
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
        {
            player = playerObj.transform;
        }
    }
    
    void Update()
    {
        if (player == null)
            return;
        
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        
        // Attack if in range
        if (distanceToPlayer <= attackRange && Time.time >= nextAttackTime)
        {
            Attack();
            nextAttackTime = Time.time + attackCooldown;
        }
    }
    
    void FixedUpdate()
    {
        if (player == null)
            return;
        
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        
        // Move towards player if not in attack range
        if (distanceToPlayer > attackRange)
        {
            Vector3 direction = (player.position - transform.position).normalized;
            
            // Move enemy
            rb.MovePosition(rb.position + direction * moveSpeed * Time.fixedDeltaTime);
            
            // Rotate towards player
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.fixedDeltaTime);
        }
    }
    
    void Attack()
    {
        Health playerHealth = player.GetComponent<Health>();
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(attackDamage);
        }
    }
}
