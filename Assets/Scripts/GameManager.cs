using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{

    public GameObject CurrentPlayer { get; private set; }
    private GameObject playerObj;

    [SerializeField] private CameraFollow gameCamera;
    [SerializeField] private EnemySpawner spawner;
    [SerializeField] private Transform playerSpawn;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                var go = new GameObject("GameManager");
                _instance = go.AddComponent<GameManager>();
                DontDestroyOnLoad(go);
            }

            return _instance;
        }
    }

    public void SetCurrentPlayer(GameObject player)
{
        CurrentPlayer = player;
        playerObj = Instantiate(CurrentPlayer);
        gameCamera.target = playerObj.transform;
        playerObj.transform.position = playerSpawn.position;
        spawner.StartGame();
}
    private static GameManager _instance;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
            return;
        }

        _instance = this;
    }

}
