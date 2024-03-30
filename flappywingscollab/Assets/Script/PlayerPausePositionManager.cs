using UnityEngine;

public class PlayerPausePositionManager : MonoBehaviour
{
    public static PlayerPausePositionManager instance;
    public Vector3 pausePosition = new Vector3(1f, 1f, 1f); // Posisi saat game di-pause

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }
}
