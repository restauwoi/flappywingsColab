using UnityEngine;

public class scoring : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.instance.IncreaseScore(); // Mengakses GameManager untuk meningkatkan skor
            Destroy(gameObject); // Menghancurkan objek yang bertabrakan dengan pemain
        }
    }
}
