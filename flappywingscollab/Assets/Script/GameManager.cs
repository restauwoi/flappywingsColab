using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int score = 0;
    public Text scoreText;

    public int highScore = 0;
    public Text highScoreText;
    public Text coinText;
    public int Coins = 0;

    private const string highScorePlayerPrefKey = "HighScore";
    private const string coinPlayerPrefKey = "Coins";
    public const string IncomePlayerPrefKey = "Income";
    private static Dictionary<string, bool> scenePauseStatus = new Dictionary<string, bool>();

    public void IncreaseScore()
    {
        score++;
        UpdateScoreText();
        if (score > highScore)
        {
            highScore = score;
            SaveHighScore();
            UpdateHighScoreText();
        }
    }

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        if (scoreText == null)
        {
            GameObject scoreTextObject = GameObject.Find("ScoreText");
            if (scoreTextObject != null)
                scoreText = scoreTextObject.GetComponent<Text>();
        }

        LoadHighScore();
        LoadCoins();
    }
    
    void UpdateScoreText()
    {
        if (scoreText != null)
            scoreText.text = "" + score.ToString();
    }

    void UpdateHighScoreText()
    {
        if (highScoreText != null)
            highScoreText.text = "Score    Tertinggi: " + highScore.ToString();
    }

    void SaveHighScore()
    {
        PlayerPrefs.SetInt(highScorePlayerPrefKey, highScore);
        PlayerPrefs.Save();
    }

    void LoadHighScore()
    {
        if (PlayerPrefs.HasKey(highScorePlayerPrefKey))
        {
            highScore = PlayerPrefs.GetInt(highScorePlayerPrefKey);
            UpdateHighScoreText();
        }
    }

    public void AddCoin(int amount)
    {
        Coins += amount;
        UpdateCoinText();
        SaveCoins();
    }

    public int GetCoins()
    {
        return Coins;
    }

    public int Highscore
    {
        get { return highScore; }
    }

    void UpdateCoinText()
    {
        if (coinText != null)
            coinText.text = "" + Coins.ToString();
    }

    void SaveCoins()
    {
        PlayerPrefs.SetInt(coinPlayerPrefKey, Coins);
        PlayerPrefs.Save();
    }

    void LoadCoins()
    {
        if (PlayerPrefs.HasKey(coinPlayerPrefKey))
        {
            Coins = PlayerPrefs.GetInt(coinPlayerPrefKey);
            UpdateCoinText();
        }
    }

    public int GetScore()
    {
        return score;
    }

    public int GetHighscore()
    {
        return highScore;
    }
}
