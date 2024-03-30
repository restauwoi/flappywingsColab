using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public HealthManagerLogic healthManager;
    public SpriteRenderer playerRenderer;
    public Color damagedColor = Color.red;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Pipe")) // Perbaikan: Jika bersentuhan dengan Pipe atau Ground
        {
            healthManager.TakeDamage(1);
            playerRenderer.color = damagedColor;
        }
        if (other.CompareTag("Ground")) // Perbaikan: Jika bersentuhan dengan Pipe atau Ground
        {
            healthManager.TakeDamage(5);
            playerRenderer.color = damagedColor;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Pipe")) // Reset color hanya jika keluar dari Pipe
        {
            playerRenderer.color = Color.white;
        }
    }
}
