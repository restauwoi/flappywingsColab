using UnityEngine;
using UnityEngine.UI;

public class Keluar : MonoBehaviour
{
    // Method untuk keluar dari aplikasi
    public void QuitApplication()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}
