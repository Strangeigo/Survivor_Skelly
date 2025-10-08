using UnityEngine;

/// <summary>
/// Base abstract class for all bonuses/power-ups
/// </summary>
public abstract class BonusBase : MonoBehaviour
{
    [Header("Bonus Stats")]
    [SerializeField] protected string bonusName;
    [SerializeField] protected float duration;
    [SerializeField] protected Sprite bonusIcon;
    
    protected float activationTime;
    protected bool isActive;
    
    protected virtual void Start()
    {
        isActive = false;
    }
    
    protected virtual void Update()
    {
        if (isActive && Time.time >= activationTime + duration)
        {
            Deactivate();
        }
    }
    
    /// <summary>
    /// Apply the bonus effect
    /// Override this method in derived classes to implement specific bonus behavior
    /// </summary>
    public virtual void Activate(GameObject player)
    {
        isActive = true;
        activationTime = Time.time;
        Debug.Log($"{bonusName} activated!");
    }
    
    /// <summary>
    /// Remove the bonus effect
    /// Override this method in derived classes to implement specific deactivation behavior
    /// </summary>
    protected virtual void Deactivate()
    {
        isActive = false;
        Debug.Log($"{bonusName} deactivated!");
    }
    
    /// <summary>
    /// Called when player picks up the bonus
    /// </summary>
    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Activate(collision.gameObject);
            // Optionally destroy the bonus pickup object
            // Destroy(gameObject);
        }
    }
}
