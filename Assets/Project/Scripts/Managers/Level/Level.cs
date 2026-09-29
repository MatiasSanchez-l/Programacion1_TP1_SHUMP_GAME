using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    public static Level instance;

    [SerializeField] private float nextLevelDelay = 3f;
    [SerializeField] private int numEnemies = 0;

    private bool levelCompleted = false;
    private float nextLevelTimer;

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
}
