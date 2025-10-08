# Survivor Skelly - Unity C# Scripts

This repository contains C# scripts for a Unity survivor-style game with player movement, weapons, and bonuses.

## Scripts Overview

### Player
- **PlayerController.cs**: Handles player movement using WASD or arrow keys
  - Uses Rigidbody2D for physics-based movement
  - Normalizes diagonal movement for consistent speed
  - Configurable move speed via the Inspector

### Weapons
- **WeaponBase.cs**: Abstract base class for all weapons
  - Contains core weapon stats (damage, attack speed, range)
  - Implements attack cooldown logic
  - Provides virtual Upgrade() method
  
- **Weapon.cs**: Example weapon implementation
  - Template for creating specific weapons
  - Includes commented examples for projectile spawning
  - Can be extended to create specific weapon types (sword, gun, magic, etc.)

### Bonuses
- **BonusBase.cs**: Abstract base class for all bonuses/power-ups
  - Manages bonus activation and duration
  - Implements pickup detection via OnTriggerEnter2D
  - Automatic deactivation after duration expires
  
- **Bonus.cs**: Example bonus implementation
  - Template for creating specific bonuses
  - Includes commented examples for speed boost
  - Can be extended to create specific bonus types (speed, damage, shield, etc.)

## Setup Instructions

### Player Setup
1. Create a GameObject in your scene (e.g., "Player")
2. Add a Rigidbody2D component
3. Set Rigidbody2D to:
   - Body Type: Dynamic
   - Gravity Scale: 0 (for top-down movement)
4. Add a Collider2D component (e.g., CircleCollider2D or BoxCollider2D)
5. Attach the PlayerController.cs script
6. Adjust the Move Speed in the Inspector (default: 5)

### Weapon Setup
1. Create a GameObject in your scene or as a child of the Player
2. Attach your custom weapon script (derived from WeaponBase)
3. Configure weapon stats in the Inspector:
   - Weapon Name
   - Damage
   - Attack Speed
   - Range

### Bonus Setup
1. Create a GameObject for your bonus pickup
2. Add a Collider2D component
3. Set the Collider2D to "Is Trigger"
4. Tag the Player GameObject with "Player" tag
5. Attach your custom bonus script (derived from BonusBase)
6. Configure bonus stats in the Inspector:
   - Bonus Name
   - Duration
   - Bonus Icon (optional)

## Creating Custom Weapons

To create a new weapon, inherit from WeaponBase:

```csharp
public class MyCustomWeapon : WeaponBase
{
    protected override void Attack()
    {
        lastAttackTime = Time.time;
        
        // Implement your weapon's attack behavior here
        // Examples:
        // - Spawn projectiles
        // - Deal melee damage to nearby enemies
        // - Create area-of-effect attacks
    }
}
```

## Creating Custom Bonuses

To create a new bonus, inherit from BonusBase:

```csharp
public class MyCustomBonus : BonusBase
{
    public override void Activate(GameObject player)
    {
        base.Activate(player);
        
        // Implement your bonus effect here
        // Examples:
        // - Increase player stats
        // - Grant temporary abilities
        // - Heal the player
    }
    
    protected override void Deactivate()
    {
        base.Deactivate();
        
        // Revert the bonus effects here
    }
}
```

## Input Controls

- **W / Up Arrow**: Move up
- **S / Down Arrow**: Move down
- **A / Left Arrow**: Move left
- **D / Right Arrow**: Move right

## Notes

- The PlayerController uses FixedUpdate for movement to ensure consistent physics behavior
- Weapons automatically attack when possible based on attack speed
- Bonuses automatically deactivate after their duration expires
- All scripts are designed to be extended and customized for your specific game needs
