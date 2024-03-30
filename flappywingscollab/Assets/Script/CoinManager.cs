using UnityEngine;

public class CoinManager : MonoBehaviour
{
    private int coins = 0;
    private string coinsSaveKey = "Coins";

    void Start()
    {
        // Memuat jumlah koin yang disimpan
        coins = PlayerPrefs.GetInt(coinsSaveKey, 0);
    }

    void OnDestroy()
    {
        // Menyimpan jumlah koin sebelum aplikasi ditutup
        PlayerPrefs.SetInt(coinsSaveKey, coins);
        PlayerPrefs.Save();
    }

    public void AddCoins(int amount)
    {
        coins += amount;
    }

    public void SubtractCoins(int amount)
    {
        coins -= amount;
        if (coins < 0)
            coins = 0; // Pastikan jumlah koin tidak pernah negatif
    }
}
