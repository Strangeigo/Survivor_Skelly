using UnityEngine;

/// <summary>
/// Spawns enemies in waves for survivor game mode
/// </summary>
public class EnemySpawner : MonoBehaviour
{
    [Header("Spawning Settings")]
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private float spawnRadius = 20f;
    [SerializeField] private float spawnInterval = 2f;
    [SerializeField] private int enemiesPerWave = 5;
    [SerializeField] private float waveInterval = 10f;
    
    [Header("Difficulty Scaling")]
    [SerializeField] private float difficultyIncreaseRate = 1.2f;
    
    private Transform player;
    private float nextSpawnTime = 0f;
    private float nextWaveTime = 0f;
    private int currentWave = 0;
    private int enemiesSpawnedThisWave = 0;
    
    public void StartGame()
    {
        player = GameManager.Instance.CurrentPlayer.transform;
         nextWaveTime = Time.time + 2f; // Start first wave after 2 seconds
    }
    void Update()
    {
        if (player == null)
            return;
        
        // Check if it's time to start a new wave
        if (Time.time >= nextWaveTime && enemiesSpawnedThisWave >= enemiesPerWave)
        {
            StartNewWave();
        }
        
        // Spawn enemies at intervals during wave
        if (enemiesSpawnedThisWave < enemiesPerWave && Time.time >= nextSpawnTime)
        {
            SpawnEnemy();
            nextSpawnTime = Time.time + spawnInterval;
        }
    }
    
    void StartNewWave()
    {
        currentWave++;
        enemiesSpawnedThisWave = 0;
        
        // Increase difficulty
        enemiesPerWave = Mathf.RoundToInt(enemiesPerWave * difficultyIncreaseRate);
        
        nextWaveTime = Time.time + waveInterval;
        nextSpawnTime = Time.time;
        
        Debug.Log($"Wave {currentWave} started! Enemies: {enemiesPerWave}");
    }
    
    void SpawnEnemy()
    {
        if (enemyPrefab == null || player == null)
            return;
        
        // Generate random spawn position around player
        Vector2 randomCircle = Random.insideUnitCircle.normalized * spawnRadius;
        Vector3 spawnPosition = player.position + new Vector3(randomCircle.x, 0f, randomCircle.y);
        
        // Spawn enemy
        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        enemiesSpawnedThisWave++;
    }
    
    public int GetCurrentWave()
    {
        return currentWave;
    }
}
