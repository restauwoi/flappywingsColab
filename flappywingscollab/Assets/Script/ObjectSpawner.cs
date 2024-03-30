using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject[] objectsToSpawn; // Array objek yang bisa di-spawn
    public float[] spawnWeights; // Bobot peluang untuk setiap objek
    private float totalWeight; // Total bobot peluang
    public float minY = -1f; // Batas bawah rentang spawn pada sumbu y
    public float maxY = 2f; // Batas atas rentang spawn pada sumbu y

    void Start()
    {
        // Menghitung total bobot peluang
        foreach (float weight in spawnWeights)
        {
            totalWeight += weight;
        }

        // Memanggil fungsi untuk melakukan spawn objek secara berbobot
        SpawnWeightedObject();
    }

    void SpawnWeightedObject()
    {
        // Menghasilkan nilai acak antara 0 dan total bobot peluang
        float randomWeight = Random.Range(0f, totalWeight);

        // Memilih objek berdasarkan bobot peluang
        float cumulativeWeight = 0f;
        GameObject objectToSpawn = null;

        for (int i = 0; i < objectsToSpawn.Length; i++)
        {
            cumulativeWeight += spawnWeights[i];

            // Jika nilai acak lebih kecil dari jumlah bobot kumulatif, pilih objek tersebut
            if (randomWeight <= cumulativeWeight)
            {
                objectToSpawn = objectsToSpawn[i];
                break;
            }
        }

        // Spawn objek di posisi spawner
        Instantiate(objectToSpawn, transform.position, Quaternion.identity);
    }
}
