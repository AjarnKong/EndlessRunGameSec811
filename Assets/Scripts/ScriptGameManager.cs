using UnityEngine;
using UnityEngine.Rendering;

public class ScriptGameManager : MonoBehaviour
{
    public static ScriptGameManager Instance { get; private set; }

    public enum GameState
    {
        MainMenu,
        Playing,
        Paused,
        GameOver
    }

    public GameState State { get; private set; } = GameState.Playing;

    public int startingHp = 3;
    public int maxHp = 9;

    public int CurrentHp { get; private set; }

    public int coinsPerExtraHP = 100;

    public int TotalCoins { get; private set; }
    private int coinProgress;

    public bool IsPlaying => State == GameState.Playing;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    private void Start() => StartGame();

    public void StartGame()
    {
        CurrentHp = startingHp;
        TotalCoins = 0;
        coinProgress = 0;
        State = GameState.Playing;
        Time.timeScale = 1f;
        //ScriptUIManager.Instance?.Refresh();
    }

    public void TakeDamage(int amount)
    {
        if (!IsPlaying) return;

        CurrentHp -= amount; // CurrentHp = CurrentHp - amount;

        //ScriptUIManager.Instance?.UpdateHP(CurrentHp);

        if (CurrentHp <= 0)
        {
            CurrentHp = 0;
            GameOver();
        }
    }

    public void AddCoin()
    {
        TotalCoins++;
        coinProgress++;
        if (coinProgress >= coinsPerExtraHP)
        {
            coinProgress -= coinsPerExtraHP;
            AddHP(1);
        }
        //ScriptUIManager.Instance?.UpdateCoins(TotalCoins, coinProgress);
    }
    
    public void AddHP(int amount)
    {
        CurrentHp = Mathf.Min(CurrentHp + amount, maxHp);
        //ScriptUIManager.Instance?.UpdateHP(CurrentHP);
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        State = GameState.GameOver;
        //ScriptUIManager.Instance?ShowGameOver(TotalCoins);
    }

    public void SetPaused(bool paused)
    {
        State = paused ? GameState.Paused : GameState.Playing;
    }
}
