using UnityEngine;
using UnityEngine.SceneManagement;

public class buttonKuis : MonoBehaviour
{
    public void pindah(string kuis)
    {
        GameObject.Find ("klik").GetComponent<AudioSource> ().Play ();
        SceneManager.LoadScene("kuis");
    }
}
