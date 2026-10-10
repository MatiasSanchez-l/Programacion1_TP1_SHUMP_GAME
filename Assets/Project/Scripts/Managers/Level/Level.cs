using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;          

public class Level : MonoBehaviour
{
    public static Level instance;

    [SerializeField] private float nextLevelDelay = 3f;
    [SerializeField] private int numEnemies = 0;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject victoryPanel;
    [SerializeField] private TMP_Text victoryText;
    [SerializeField] private string wonMessage = "¡VICTORIA!";
    [SerializeField] private string survivedMessage = "¡AGUANTASTE!";

    private int score = 0;      
    private bool levelCompleted = false;
    private bool allSpawned = true; 
    private float nextLevelTimer;

    void Start()
    {
        UpdateScoreText();
        gameOverPanel.SetActive(false);
        victoryPanel.SetActive(false);
    }

    public void AddScore(int points)
    {
        score += points;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        scoreText.text = "SCORE: " + score.ToString("D6");
    }

    private void Awake(){
        if(instance == null){
            instance = this;
            DontDestroyOnLoad(gameObject);
        }else{
            Destroy(gameObject);
        }
    }

    void OnDestroy(){
        if (instance == this) instance = null;
    }

    void Update(){
        if (!levelCompleted) return;

        nextLevelTimer -= Time.deltaTime;
        if (nextLevelTimer <= 0)
        {
            levelCompleted = false;
            LoadNextLevel();
        }
    }

    public void AddEnemy(){
        numEnemies++;
    }

    public void RemoveEnemy()
    {
        numEnemies--;
        CheckLevelCompleted();
    }

    public void StartSpawning()
    {
        allSpawned = false;
    }

    public void SpawningFinished()
    {
        allSpawned = true;
        CheckLevelCompleted();
    }

    private void CheckLevelCompleted()
    {
        if (allSpawned && numEnemies == 0 && !levelCompleted)
        {
            levelCompleted = true;
            nextLevelTimer = nextLevelDelay;
        }
    }

    private void LoadNextLevel()
    {
        int next = SceneManager.GetActiveScene().buildIndex + 1;

        if (next < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(next);
        }
        else
        {
            Victory(true);
        }
    }

    public void GameOver(){
        if (IsLastLevel())
        {
            Victory(false);
            return;
        }

        gameOverPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    private bool IsLastLevel(){
        return SceneManager.GetActiveScene().buildIndex == SceneManager.sceneCountInBuildSettings - 1;
    }

    private void Victory(bool won){
        string title = won ? wonMessage : survivedMessage;
        victoryText.text = title + "\n<size=50%>SCORE: " + score.ToString("D6") + "</size>";

        victoryPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Retry(){
        LeaveTo("Level1");
    }

    public void GoToMenu(){
        LeaveTo("Menu");
    }    

    private void LeaveTo(string sceneName)
    {
        Time.timeScale = 1f;
        instance = null;
        Destroy(gameObject);
        SceneManager.LoadScene(sceneName);
    }
}
