using System;
using UnityEngine;

/// <summary>
/// Basic enemy AI that chases and attacks the player
/// </summary>
public class EnemyAI : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float moveSpeed = 1f;
    [SerializeField] private float rotationSpeed = 5f;
    
    [Header("Attack Settings")]
    [SerializeField] private int attackDamage = 10;
    [SerializeField] private float attackRange = 1.5f;
    [SerializeField] private float attackCooldown = 1f;
    private float distanceToPlayer;
    private Action doAction;
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
        setModeVoid();
    }
    
    void Update()
    {
        if (player == null)
            return;

        doAction?.Invoke();

        
       
    }
    private void setModeVoid()
    {
        doAction = doActionVoid;
    }
    private void doActionVoid()
    {
        // Attack if in range

        if (distanceToPlayer <= attackRange && Time.time >= nextAttackTime)
        {
            setModeAttack();
        }
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
    private void setModeAttack()
    {
        doAction = doActionAttack;
    }
    private void doActionAttack()
    {
        if (distanceToPlayer <= attackRange && Time.time >= nextAttackTime)
        {
            Attack();
            nextAttackTime = Time.time + attackCooldown;
        }
        else setModeVoid();
    }
    void FixedUpdate()
    {
        if (player == null)
            return;
        
        distanceToPlayer = Vector3.Distance(transform.position, player.position);
        
    }
    
    void Attack()
    {

        Debug.Log("ATTACKING PLAYER");

        Health playerHealth = player.GetComponent<Health>();
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(attackDamage);
        }
    }
}
