using UnityEngine;
using UnityEngine.UI;

public class CountGameOver : MonoBehaviour
{
    public Text scoreText;
    public Text coinsText;

    void Start()
    {
        // Menampilkan jumlah skor dan koin di layar
        scoreText.text = "Skor: " + GameManager.instance.score.ToString();
        coinsText.text = "Koin: " + GameManager.instance.GetCoins().ToString(); // Menggunakan GetCoins() untuk mengakses jumlah koin
    }
}
