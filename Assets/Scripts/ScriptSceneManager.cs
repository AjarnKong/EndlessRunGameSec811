using UnityEngine;
using UnityEngine.SceneManagement;

public class ScriptSceneManager : MonoBehaviour
{
    public const string MainMenuScene = "MainMenu";
    public const string GameScene = "Game";

    public void LoadScene(string sceneName)
    {
        Time.timeScale = 1f; // Reset time scale to normal
        SceneManager.LoadScene(sceneName);
    }

    public void PlayGame() => LoadScene(GameScene);

    public void GoToMainMenu() => LoadScene(MainMenuScene);

    public void RestartGame()
    {
        Time.timeScale = 1f; // Reset time scale to normal
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitGame()
    {
        Debug.Log("Quitting the game...");
        Application.Quit();
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
