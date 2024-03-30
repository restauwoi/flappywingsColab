using UnityEngine;
using UnityEngine.UI;

public class HealthManagerUI : MonoBehaviour
{
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    // Fungsi ini akan dipanggil dari HealthManagerLogic untuk memperbarui tampilan UI kesehatan
    public void UpdateHealthUI(int currentHealth)
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < currentHealth)
                hearts[i].sprite = fullHeart;
            else
                hearts[i].sprite = emptyHeart;
        }
    }
}
