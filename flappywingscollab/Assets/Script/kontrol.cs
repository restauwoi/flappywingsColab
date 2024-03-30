using UnityEngine;

public class kontrol : MonoBehaviour
{
    public float jumpForce = 5.5f;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Jump();
        }

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                Jump();
            }
        }
    }

    private void Jump()
    {
        rb.velocity = Vector2.up * jumpForce;
        GameObject.Find ("jumpsound").GetComponent<AudioSource> ().Play ();
    }
}
