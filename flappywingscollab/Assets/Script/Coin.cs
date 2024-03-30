using UnityEngine;

public class Coin : MonoBehaviour
{
    public float baseMoveSpeed = 2f; // Kecepatan awal gerak koin
    public float maxMoveSpeed = 8f; // Batas maksimal kecepatan koin
    public float speedIncreaseRate = 0.01f; // Tingkat peningkatan kecepatan per detik
    private float currentMoveSpeed;

    public int coinValue = 1;

    private void Start()
    {
        currentMoveSpeed = baseMoveSpeed;
    }

    private void Update()
    {
        // Meningkatkan kecepatan koin seiring waktu
        currentMoveSpeed += speedIncreaseRate * Time.deltaTime;
        currentMoveSpeed = Mathf.Min(currentMoveSpeed, maxMoveSpeed); // Memastikan tidak melebihi batas maksimal

        // Menggerakkan koin ke kiri dengan kecepatan yang diupdate
        transform.Translate(Vector3.left * currentMoveSpeed * Time.deltaTime);

        // Menghapus koin jika posisinya kurang dari -4 pada sumbu x
        if (transform.position.x < -4)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.instance.AddCoin(coinValue);
            GameObject.Find ("coinsound").GetComponent<AudioSource> ().Play ();
            Destroy(gameObject);
        }
    }
}
