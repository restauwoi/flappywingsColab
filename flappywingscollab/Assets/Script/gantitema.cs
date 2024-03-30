using UnityEngine;

public class gantitema : MonoBehaviour
{
    public Sprite[] newSprites; // Array of new sprites to use
    public float changeTime = 5f; // Time when sprites will be changed

    private bool hasChanged = false;

    void Start()
    {
        Invoke("ChangeSprites", changeTime); // Call ChangeSprites function after specified time
    }

    void ChangeSprites()
    {
        if (!hasChanged && newSprites.Length > 0)
        {
            SpriteRenderer[] spriteRenderers = FindObjectsOfType<SpriteRenderer>(); // Find all objects with SpriteRenderer component

            foreach (SpriteRenderer spriteRenderer in spriteRenderers)
            {
                int randomIndex = Random.Range(0, newSprites.Length); // Select a random index from the array of new sprites
                Sprite newSprite = newSprites[randomIndex]; // Get the new sprite from the array

                spriteRenderer.sprite = newSprite; // Change the sprite of the object
            }

            hasChanged = true; // Mark that sprites have been changed
        }
    }
}