using UnityEngine;

public class tanah : MonoBehaviour
{
    public float speed = 2f; // Kecepatan pergerakan platform
    public float resetPosition = -10f; // Posisi reset platform

    void Update()
    {
        // Menggerakkan platform secara horizontal
        transform.Translate(Vector3.left * speed * Time.deltaTime);

        // Jika platform telah mencapai posisi reset, atur ulang posisinya
        if (transform.position.x <= resetPosition)
        {
            RepositionPlatform();
        }
    }

    // Fungsi untuk mengatur ulang posisi platform
    void RepositionPlatform()
    {
        // Hitung posisi baru berdasarkan posisi awal
        Vector3 newPos = new Vector3(transform.position.x + Mathf.Abs(resetPosition), transform.position.y, transform.position.z);
        
        // Atur ulang posisi platform
        transform.position = newPos;
    }
}
