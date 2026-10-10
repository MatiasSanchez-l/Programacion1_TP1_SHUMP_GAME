/**
 * @author Matias
 * @create date 2026-10-05 21:02:34
 * @modify date 2026-10-05 21:02:34
 * @desc botones del menú principal: jugar, créditos y salir
 */
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject creditsPanel;
    [SerializeField] private string firstLevelScene = "Level1";

    void Start()
    {
        creditsPanel.SetActive(false);
    }

    public void Play()
    {
        SceneManager.LoadScene(firstLevelScene);
    }

    public void ShowCredits()
    {
        creditsPanel.SetActive(true);
    }

    public void HideCredits()
    {
        creditsPanel.SetActive(false);
    }

    public void Quit(){
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
    }
}