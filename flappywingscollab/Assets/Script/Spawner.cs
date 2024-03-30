using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{
    public GameObject objectToSpawn; // Objek yang akan di-spawn
    public float minY = -2f; // Batas bawah rentang spawn pada sumbu y
    public float maxY = 2f; // Batas atas rentang spawn pada sumbu y
    private float spawnTimer = 4f; // Waktu awal antara setiap spawn
    public float minSpawnTime = 1f; // Waktu minimum antara setiap spawn
    public float decreaseAmount = 0.05f; // Jumlah pengurangan waktu setiap spawn

    void Start()
    {
        // Memulai spawning object secara periodik
        StartCoroutine(SpawnObject());
    }

    IEnumerator SpawnObject()
    {
        while (true)
        {
            // Menunggu sebelum melakukan spawn
            yield return new WaitForSeconds(spawnTimer);

            // Menentukan posisi spawn dengan nilai y yang random antara minY dan maxY
            Vector3 spawnPosition = transform.position + new Vector3(0f, Random.Range(minY, maxY), 0f);

            // Spawn object
            Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);

            // Mengurangi waktu spawn
            spawnTimer -= decreaseAmount;
            // Memastikan waktu spawn tidak kurang dari waktu minimum
            if (spawnTimer < minSpawnTime)
            {
                spawnTimer = minSpawnTime;
            }
        }
    }
}
