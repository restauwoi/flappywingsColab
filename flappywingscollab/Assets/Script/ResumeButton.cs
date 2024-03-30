using UnityEngine;
using UnityEngine.UI;

public class ResumeButton : MonoBehaviour
{
    public Button resumeButton;

    void Start()
    {
        // Menghentikan permainan saat masuk ke scene pertama kali
        PauseGame();
        
        // Menambahkan listener untuk event klik tombol resume
        resumeButton.onClick.AddListener(ResumeGame);
    }

    void PauseGame()
    {
        Time.timeScale = 0f; // Menghentikan permainan
        resumeButton.gameObject.SetActive(true); // Menampilkan tombol resume
    }

    void ResumeGame()
    {
        Time.timeScale = 1f; // Melanjutkan permainan
        resumeButton.gameObject.SetActive(false); // Menyembunyikan tombol resume
    }
}
