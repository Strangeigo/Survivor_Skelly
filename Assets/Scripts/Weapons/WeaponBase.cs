using UnityEngine;

/// <summary>
/// Base abstract class for all weapons
/// </summary>
public abstract class WeaponBase : MonoBehaviour
{
    [Header("Weapon Stats")]
    [SerializeField] protected string weaponName;
    [SerializeField] protected float damage;
    [SerializeField] protected float attackSpeed;
    [SerializeField] protected float range;
    
    protected float lastAttackTime;
    
    protected virtual void Start()
    {
        lastAttackTime = 0f;
    }
    
    protected virtual void Update()
    {
        if (CanAttack())
        {
            Attack();
        }
    }
    
    /// <summary>
    /// Check if weapon can attack based on attack speed
    /// </summary>
    protected virtual bool CanAttack()
    {
        return Time.time >= lastAttackTime + (1f / attackSpeed);
    }
    
    /// <summary>
    /// Execute the weapon's attack
    /// Override this method in derived classes to implement specific weapon behavior
    /// </summary>
    protected abstract void Attack();
    
    /// <summary>
    /// Upgrade the weapon stats
    /// Override this method in derived classes to implement specific upgrade behavior
    /// </summary>
    public virtual void Upgrade()
    {
        damage *= 1.2f;
        attackSpeed *= 1.1f;
    }
}
