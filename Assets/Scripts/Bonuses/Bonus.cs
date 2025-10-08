using UnityEngine;

/// <summary>
/// Example bonus implementation - can be used as a template for specific bonuses
/// </summary>
public class Bonus : BonusBase
{
    [Header("Bonus Specific Settings")]
    [SerializeField] private float multiplier = 1.5f;
    
    private PlayerController playerController;
    private float originalMoveSpeed;
    
    public override void Activate(GameObject player)
    {
        base.Activate(player);
        
        // TODO: Implement specific bonus logic
        // Example: Speed boost, damage boost, invincibility, etc.
        
        // Example speed boost implementation (uncomment when integrated with player)
        // playerController = player.GetComponent<PlayerController>();
        // if (playerController != null)
        // {
        //     originalMoveSpeed = playerController.moveSpeed;
        //     playerController.moveSpeed *= multiplier;
        // }
    }
    
    protected override void Deactivate()
    {
        base.Deactivate();
        
        // TODO: Revert bonus effects
        
        // Example speed boost removal (uncomment when integrated with player)
        // if (playerController != null)
        // {
        //     playerController.moveSpeed = originalMoveSpeed;
        // }
    }
}
