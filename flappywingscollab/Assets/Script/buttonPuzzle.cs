using UnityEngine;
using UnityEngine.SceneManagement;

public class buttonPuzzle : MonoBehaviour
{
    public void pindah(string puzzle)
    {
        GameObject.Find ("klik").GetComponent<AudioSource> ().Play ();
        SceneManager.LoadScene("puzzle");
    }
}
