# Survivor_Skelly

A third-person automatic shooter survival game built with Unity. Survive waves of enemies that spawn around you while your character automatically shoots at the nearest threat.

## Game Description

Survivor_Skelly is a survival-style game where you control a character from a third-person perspective. Your character automatically shoots at the nearest enemy, allowing you to focus on movement and positioning. Waves of enemies continuously spawn around you, increasing in difficulty as you survive longer.

## Features

- **Third-Person Perspective**: Smooth camera following the player from behind
- **Automatic Shooting**: Player automatically targets and shoots the nearest enemy
- **Wave-Based Spawning**: Enemies spawn in increasingly difficult waves
- **Enemy AI**: Basic enemy behavior that chases and attacks the player
- **Health System**: Both player and enemies have health systems
- **Score Tracking**: Track your score, kills, and survival time

## Game Components

### Core Scripts

1. **PlayerController.cs** - Handles player movement with WASD/Arrow keys
2. **CameraFollow.cs** - Third-person camera that smoothly follows the player
3. **AutoShoot.cs** - Automatic shooting system that targets nearest enemies
4. **EnemyAI.cs** - Enemy behavior for chasing and attacking the player
5. **EnemySpawner.cs** - Spawns enemies in waves around the player
6. **Health.cs** - Health system for both player and enemies
7. **Bullet.cs** - Projectile behavior with damage on collision
8. **GameManager.cs** - Manages game state, score, and game over conditions

## Setup Instructions

### Prerequisites

- Unity 2020.3 LTS or newer
- Basic understanding of Unity Editor

### Setting Up the Game

1. **Clone the repository**
   ```bash
   git clone https://github.com/Strangeigo/Survivor_Skelly.git
   cd Survivor_Skelly
   ```

2. **Open in Unity**
   - Open Unity Hub
   - Click "Add" and select the cloned repository folder
   - Open the project

3. **Create the Scene**

   a. **Player Setup**:
   - Create a Cube GameObject (name it "Player")
   - Tag it as "Player"
   - Add the `PlayerController` script
   - Add the `AutoShoot` script
   - Add the `Health` script (check "Is Player")
   - Add a Rigidbody component
   - Add a Capsule Collider

   b. **Camera Setup**:
   - Select the Main Camera
   - Add the `CameraFollow` script
   - Assign the Player to the Target field

   c. **Enemy Prefab**:
   - Create a Cube GameObject (name it "Enemy")
   - Tag it as "Enemy"
   - Change its color (Material) to red
   - Add the `EnemyAI` script
   - Add the `Health` script
   - Add a Rigidbody component
   - Add a Capsule Collider
   - Make it a Prefab by dragging to Assets/Prefabs folder
   - Delete the instance from the scene

   d. **Bullet Prefab**:
   - Create a Sphere GameObject (name it "Bullet")
   - Scale it down (0.2, 0.2, 0.2)
   - Add the `Bullet` script
   - Add a Rigidbody component (disable gravity)
   - Add a Sphere Collider (check "Is Trigger")
   - Make it a Prefab by dragging to Assets/Prefabs folder
   - Delete the instance from the scene

   e. **Game Manager**:
   - Create an Empty GameObject (name it "GameManager")
   - Add the `GameManager` script

   f. **Enemy Spawner**:
   - Create an Empty GameObject (name it "EnemySpawner")
   - Add the `EnemySpawner` script
   - Assign the Enemy Prefab to the "Enemy Prefab" field

   g. **Environment** (Optional):
   - Create a Plane GameObject for the ground
   - Scale it appropriately (10, 1, 10)

4. **Configure the Player**:
   - Select the Player GameObject
   - In the AutoShoot component:
     - Assign the Bullet Prefab to "Bullet Prefab"
     - Set Fire Rate (0.5 recommended)
     - Set Detection Range (15 recommended)

5. **Press Play** to test the game!

## Controls

- **W/Up Arrow** - Move Forward
- **S/Down Arrow** - Move Backward
- **A/Left Arrow** - Move Left
- **D/Right Arrow** - Move Right
- Shooting is automatic - no input required!

## Gameplay Tips

- Keep moving to avoid being surrounded by enemies
- Position yourself to maximize your shooting efficiency
- Watch your health - enemies deal damage on contact
- Survive as long as possible to achieve a high score
- Each wave brings more enemies with scaled difficulty

## Customization

You can adjust various parameters in the Unity Inspector:

### Player Settings
- Move Speed
- Rotation Speed
- Max Health

### Shooting Settings
- Fire Rate
- Detection Range
- Bullet Damage

### Enemy Settings
- Move Speed
- Attack Damage
- Attack Range
- Max Health

### Spawner Settings
- Enemies Per Wave
- Spawn Interval
- Wave Interval
- Difficulty Increase Rate

## Future Enhancements

Potential features to add:
- Different enemy types
- Power-ups and upgrades
- Multiple weapons
- UI for health, score, and wave counter
- Sound effects and music
- Particle effects for shooting and explosions
- Boss enemies
- Multiple levels/arenas

## License

This project is open source and available under the MIT License.

## Contributing

Feel free to fork this project and submit pull requests with improvements!