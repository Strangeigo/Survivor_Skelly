using UnityEngine;

/// <summary>
/// Example weapon implementation - can be used as a template for specific weapons
/// </summary>
public class Weapon : WeaponBase
{
    [Header("Weapon Specific Settings")]
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform firePoint;
    
    protected override void Attack()
    {
        lastAttackTime = Time.time;
        
        // TODO: Implement weapon attack logic
        // Example: Instantiate projectile, apply damage to enemies, etc.
        Debug.Log($"{weaponName} attacked with {damage} damage!");
        
        // Example projectile spawning (uncomment when you have a projectile prefab)
        // if (projectilePrefab != null && firePoint != null)
        // {
        //     Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
        // }
    }
}
