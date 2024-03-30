using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip gameOverSound; // Suara game over
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Fungsi untuk memainkan suara game over
    public void PlayGameOverSound()
    {
        if (gameOverSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(gameOverSound);
        }
    }
}
