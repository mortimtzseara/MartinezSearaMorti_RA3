using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject topBar;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject winPanel;

    private int startingLives = 5;
    private int currentLives;
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
        topBar.SetActive(false);
        gameOverPanel.SetActive(false);
    }
    private void OnEnable()
    {
        GameEvents.OnGameWin += GameWin;
        GameEvents.OnSceneChanged += ChangeScene;
        GameEvents.OnTakeDamage += TakeDamage;
    }
    private void OnDisable()
    {
        GameEvents.OnGameWin -= GameWin;
        GameEvents.OnSceneChanged -= ChangeScene;
        GameEvents.OnTakeDamage -= TakeDamage;
    }
    public void RestartGame() 
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Level1");
        StartGame();
        pausePanel.SetActive(false);
    }
    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    public void PauseGame()
    {
        Time.timeScale = 0;
        pausePanel.SetActive(true);
        topBar.SetActive(false);
    }
    public void UnpauseGame()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
        topBar.SetActive(true);
    }
    public void StartGame()
    {
        Time.timeScale = 1;
        IsGameOver = false;
        topBar.SetActive(true);
        gameOverPanel.SetActive(false);
        RestartLives();
        GameEvents.GameStart();
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    public void GameOver()
    {
        GameEvents.GameOver();
        gameOverPanel.SetActive(true);
        Time.timeScale = 0;        
    }
    private void RestartLives()
    {
        currentLives = startingLives;
        GameEvents.PlayerHealthChanged(currentLives);
    }
    private void TakeDamage()
    {
        currentLives--;
        if(currentLives <= 0)
        {
            IsGameOver = true;
            GameOver();
        }
        else
        {
            GameEvents.PlayerHealthChanged(currentLives);
        }        
    }
    public void GameWin()
    {
        winPanel.SetActive(true);
        Time.timeScale = 0;
    }
}
