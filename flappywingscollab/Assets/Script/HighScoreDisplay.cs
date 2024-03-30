using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HighScoreDisplay : MonoBehaviour
{
    public Text highScoreText;
    private int highScore;

    void Start()
    {
        // Mengambil skor tertinggi dari penyimpanan (misalnya: PlayerPrefs)
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        
        // Menampilkan skor tertinggi pada UI Text
        UpdateHighScoreText();
    }

    void UpdateHighScoreText()
    {
        highScoreText.text = "Skor Tertinggi: " + highScore.ToString();
    }

    // Metode ini bisa dipanggil dari skrip lain untuk memperbarui skor tertinggi
    public void UpdateHighScore(int newScore)
    {
        if (newScore > highScore)
        {
            highScore = newScore;
            // Simpan skor tertinggi di penyimpanan (misalnya: PlayerPrefs)
            PlayerPrefs.SetInt("HighScore", highScore);
            PlayerPrefs.Save(); // Simpan perubahan
            UpdateHighScoreText(); // Perbarui tampilan UI Text
        }
    }
}
