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

    private int score = 0;      
    private bool levelCompleted = false;
    private float nextLevelTimer;

    void Start()
    {
        UpdateScoreText();
        gameOverPanel.SetActive(false);
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

        if (numEnemies == 0 && !levelCompleted)
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
            Debug.Log("¡Ganaste! No hay más niveles");
        }
    }

    public void GameOver(){
        gameOverPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Retry(){
        Time.timeScale = 1f;
        instance = null;
        Destroy(gameObject);

        SceneManager.LoadScene("Level1");
    }

    public void GoToMenu(){
        Debug.Log("Menú: todavía no implementado");
    }    
}
