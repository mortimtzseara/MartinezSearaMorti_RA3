using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private int startingLives = 3;
    private int lives;
    public bool IsGameOver { get; private set; }
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject); return;
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    private void OnEnable()
    {
        GameEvents.OnSceneChanged += ChangeScene;
    }
    private void OnDisable()
    {
        GameEvents.OnSceneChanged -= ChangeScene;
    }
    void Start()
    {
        lives = startingLives;
        IsGameOver = false;
    }

    private void GameOver() 
    {
        Time.timeScale = 0;
    }
    public void RestartGame() 
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
