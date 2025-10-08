using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Manages game state, score, and game over conditions
/// </summary>
public class GameManager : MonoBehaviour
{
    [Header("Game State")]
    [SerializeField] private bool gameIsOver = false;
    
    private int score = 0;
    private int enemiesKilled = 0;
    private float survivalTime = 0f;
    
    void Update()
    {
        if (!gameIsOver)
        {
            survivalTime += Time.deltaTime;
        }
    }
    
    public void EnemyKilled()
    {
        if (gameIsOver)
            return;
        
        enemiesKilled++;
        score += 100;
        
        Debug.Log($"Enemy killed! Score: {score}");
    }
    
    public void GameOver()
    {
        if (gameIsOver)
            return;
        
        gameIsOver = true;
        
        Debug.Log($"Game Over! Final Score: {score}");
        Debug.Log($"Enemies Killed: {enemiesKilled}");
        Debug.Log($"Survival Time: {survivalTime:F2} seconds");
        
        // Optionally restart after delay
        Invoke("RestartGame", 3f);
    }
    
    void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
    public int GetScore()
    {
        return score;
    }
    
    public int GetEnemiesKilled()
    {
        return enemiesKilled;
    }
    
    public float GetSurvivalTime()
    {
        return survivalTime;
    }
    
    public bool IsGameOver()
    {
        return gameIsOver;
    }
}
