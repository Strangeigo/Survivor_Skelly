using UnityEngine;

/// <summary>
/// Projectile that damages enemies on collision
/// </summary>
public class Bullet : MonoBehaviour
{
    [Header("Bullet Settings")]
    [SerializeField] private int damage = 25;
    [SerializeField] private float lifetime = 5f;
    
    void Start()
    {
        // Destroy bullet after lifetime
        Destroy(gameObject, lifetime);
    }
    
    void OnTriggerEnter(Collider other)
    {
        // Check if hit an enemy
        if (other.CompareTag("Enemy"))
        {
            Health enemyHealth = other.GetComponent<Health>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(damage);
            }
            
            Destroy(gameObject);
        }
        
        // Destroy on collision with environment
        if (other.CompareTag("Environment") || other.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
    }
}
