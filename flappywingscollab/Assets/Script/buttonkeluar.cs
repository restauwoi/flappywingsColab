using UnityEngine;
using UnityEngine.SceneManagement;

public class buttonkeluar : MonoBehaviour
{
    public void pindah(string menu)
    {
        GameObject.Find ("klik").GetComponent<AudioSource> ().Play ();
        SceneManager.LoadScene("menu");
    }
}