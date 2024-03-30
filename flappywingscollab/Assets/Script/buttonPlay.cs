using UnityEngine;
using UnityEngine.SceneManagement;

public class buttonPlay : MonoBehaviour
{
    public void pindah(string menu)
    {
        GameObject.Find ("klik").GetComponent<AudioSource> ().Play ();
        SceneManager.LoadScene("main");
    }
}