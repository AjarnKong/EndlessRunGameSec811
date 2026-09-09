using UnityEngine;

public class ScriptPauseManager : MonoBehaviour
{
    public GameObject pauseMenuUI;
    
    void Start()
    {
        if (pauseMenuUI != null)
        {
            pauseMenuUI.SetActive(false); // Ensure the pause menu is hidden at the start
        }
    }

    void Update()
    {
        if (!Input.GetKeyDown(KeyCode.Escape)) return;

        if (ScriptGameManager.Instance == null) return;

        if (ScriptGameManager.Instance.State == ScriptGameManager.GameState.Playing)
        {
            Pause();
        }
        else if (ScriptGameManager.Instance.State == ScriptGameManager.GameState.Paused)
        {
            Resume();
        }
    }

    public void Pause()
    {
        Time.timeScale = 0f; // Freeze the game
        ScriptGameManager.Instance.SetPaused(true);
        if (pauseMenuUI != null)
        {
            pauseMenuUI.SetActive(true); // Show the pause menu
        }
    }

    public void Resume()
    {
        Time.timeScale = 1f; // Resume the game
        ScriptGameManager.Instance.SetPaused(false);
        if (pauseMenuUI != null)
        {
            pauseMenuUI.SetActive(false); // Hide the pause menu
        }
    }
}
