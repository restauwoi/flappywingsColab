using UnityEngine;

public class DisableSpecificAudio : MonoBehaviour
{
    public AudioSource audioToDisable;

    // Panggil metode ini ketika Anda ingin mematikan audio tertentu
    public void DisableAudio()
    {
        if (audioToDisable != null)
        {
            audioToDisable.enabled = false;
        }
        else
        {
            Debug.LogWarning("Audio Source belum diatur.");
        }
    }
}
