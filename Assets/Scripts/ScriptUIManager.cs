using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScriptUIManager : MonoBehaviour
{
    public static ScriptUIManager Instance { get; private set; }

    public TMP_Text coinText, hpText;
    public Image[] heartIcons;
    public GameObject gameOverPanel;

    public GameObject invincibleIcon, magnetIcon;
    public TMP_Text invincibleTimerText, magnetTimerText;
    public ScriptPlayerController player;
    public TMP_Text gameOverCoinText, gameOverScoreText;


    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
                
        Instance = this;      
    }

    void Update()
    {
        if (player == null) return;

        if (invincibleIcon != null) invincibleIcon.SetActive(player.IsInvincible);

        if (magnetIcon != null) magnetIcon.SetActive(player.IsMagnetActive);

        if (invincibleTimerText != null && player.IsInvincible)
        {
            invincibleTimerText.text = "Invicible: " + Mathf.CeilToInt(player.invincibleTimer).ToString() + "s";
        }
        else if (invincibleTimerText != null)
        {
            invincibleTimerText.text = "";
        }

        if (magnetTimerText != null && player.IsMagnetActive)
        {
            magnetTimerText.text = "Magnet: " + Mathf.CeilToInt(player.magnetTimer).ToString() + "s";
        }
        else if (magnetTimerText != null)
        {
            magnetTimerText.text = "";
        }
    }

    public void ShowGameOver(int coins)
    {
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
        }

        if (gameOverCoinText != null)
        {
            gameOverCoinText.text = "Coins: " + coins.ToString();
        }

        if (gameOverScoreText != null)
        {
            gameOverScoreText.text = "Score: " + coins * 100;
        }
    }

    public void UpdateHP(int hp)
    {
        if (hpText != null)
        {
            hpText.text = "HP: " + hp.ToString();
        }

        if (heartIcons != null)
        {
            for (int i = 0; i < heartIcons.Length; i++)
            {
                if (heartIcons[i] != null)
                {
                    heartIcons[i].enabled = i < hp;
                }
            }
        }
    }

    public void UpdateCoin(int total, int progress)
    {
        if (coinText != null)
        {
            coinText.text = "Coins: " + total.ToString() + " (" + progress.ToString() + "/100)";
        }
    }
}
