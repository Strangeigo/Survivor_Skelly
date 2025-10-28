using UnityEngine;

/// <summary>
/// Automatically shoots at the nearest enemy
/// </summary>
public class AutoShoot : MonoBehaviour
{
    [Header("Shooting Settings")]
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firePoint;
    [SerializeField] private float fireRate = 0.5f;
    [SerializeField] private float detectionRange = 15f;
    [SerializeField] private LayerMask enemyLayer;
    
    private float nextFireTime = 0f;
    private Transform nearestEnemy;
    
    void Start()
    {
        // Create fire point if not assigned
        if (firePoint == null)
        {
            GameObject firePointObj = new GameObject("FirePoint");
            firePointObj.transform.SetParent(transform);
            firePointObj.transform.localPosition = Vector3.forward;
            firePoint = firePointObj.transform;
        }
    }
    
    void Update()
    {
        // Find nearest enemy
        nearestEnemy = FindNearestEnemy();
        
        // Shoot if enemy is in range and cooldown is ready
        if (nearestEnemy != null && Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireRate;
        }
    }
    
    Transform FindNearestEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        Transform nearest = null;
        float minDistance = detectionRange;
        
        foreach (GameObject enemy in enemies)
        {
            float distance = Vector3.Distance(transform.position, enemy.transform.position);
            if (distance < minDistance)
            {
                minDistance = distance;
                nearest = enemy.transform;
            }
        }
        
        return nearest;
    }
    
    void Shoot()
    {
        if (bulletPrefab == null || nearestEnemy == null)
            return;
        
        // Calculate direction to enemy
        Vector3 direction = (nearestEnemy.position - firePoint.position).normalized;
        
        // Create bullet
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.LookRotation(direction));
        
        // Set bullet velocity
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.linearVelocity = direction * 20f;
        }
    }
}
