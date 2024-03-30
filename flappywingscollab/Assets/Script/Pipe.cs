using UnityEngine;

public class Pipe : MonoBehaviour
{
    public float baseSpeed = 2f; // Kecepatan awal gerak pipa
    public float maxSpeed = 8f; // Batas maksimal kecepatan pipa
    public float speedIncreaseRate = 0.01f; // Tingkat peningkatan kecepatan per detik
    private float currentSpeed;

    private float leftEdge;

    private void Start()
    {
        leftEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 1f;
        currentSpeed = baseSpeed;
    }

    private void Update()
    {
        // Meningkatkan kecepatan pipa seiring waktu
        currentSpeed += speedIncreaseRate * Time.deltaTime;
        currentSpeed = Mathf.Min(currentSpeed, maxSpeed); // Memastikan tidak melebihi batas maksimal

        transform.position += Vector3.left * currentSpeed * Time.deltaTime;

        if (transform.position.x < leftEdge)
        {
            Destroy(gameObject); // Menghancurkan GameObject ini (pipa)
        }
    }
}
