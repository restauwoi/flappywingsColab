using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthManagerLogic : MonoBehaviour
{
    public int maxHealth = 4;
    public int currentHealth;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthUI();
    }

    // Fungsi ini akan dipanggil dari tempat lain (misalnya: PlayerCollision) untuk mengurangi kesehatan
    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        GameObject.Find ("TakeDamage").GetComponent<AudioSource> ().Play ();

        UpdateHealthUI();

        if (currentHealth <= 0)
        {
            SceneManager.LoadScene("GameOverScene");
        }
    }

    // Fungsi ini akan dipanggil dari tempat lain (misalnya: PlayerCollision) untuk menambah kesehatan
    public void IncreaseHealth(int healAmount)
    {
        currentHealth += healAmount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        UpdateHealthUI();
    }

    // Fungsi untuk memperbarui tampilan UI kesehatan
    void UpdateHealthUI()
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
