using UnityEngine;

public class Bomb : MonoBehaviour
{
    public Sprite explosionSprite1;
    public Sprite explosionSprite2;
    public int damage = 1;

    public float baseMoveSpeed = 2f; // Kecepatan awal gerak koin
    public float maxMoveSpeed = 8f; // Batas maksimal kecepatan koin
    public float speedIncreaseRate = 0.01f; // Tingkat peningkatan kecepatan per detik
    private float currentMoveSpeed;

    private bool exploded = false;

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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !exploded)
        {
            HealthManagerLogic healthManager = collision.GetComponent<HealthManagerLogic>(); // Mengubah tipe variabel menjadi HealthManagerLogic
            if (healthManager != null)
            {
                healthManager.TakeDamage(damage);
                // Memainkan suara
                GameObject.Find ("bomsound").GetComponent<AudioSource> ().Play ();
            }
            Explode();
        }
    }

    private void Explode()
    {
        exploded = true;
        gameObject.SetActive(false); // Menghilangkan GameObject bomb yang sudah meledak
        
        // Membuat GameObject baru untuk menampung ledakan
        GameObject explosion1 = new GameObject("Explosion1");
        GameObject explosion2 = new GameObject("Explosion2");

        // Menambahkan komponen SpriteRenderer ke GameObject ledakan
        SpriteRenderer explosionSpriteRenderer1 = explosion1.AddComponent<SpriteRenderer>();
        SpriteRenderer explosionSpriteRenderer2 = explosion2.AddComponent<SpriteRenderer>();

        // Menetapkan sprite ledakan ke komponen SpriteRenderer
        explosionSpriteRenderer1.sprite = explosionSprite1;
        explosionSpriteRenderer2.sprite = explosionSprite2;

        // Menetapkan posisi ledakan ke posisi bom
        explosion1.transform.position = transform.position;
        explosion2.transform.position = transform.position;

        // Setelah Anda selesai dengan ledakan, Anda bisa menghapusnya dari memori
        Destroy(explosion1, 1f); // Menghapus ledakan pertama setelah 1 detik
        Destroy(explosion2, 1f); // Menghapus ledakan kedua setelah 1 detik
    }
}
