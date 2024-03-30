using UnityEngine;
using UnityEngine.UI;

public class gantibg : MonoBehaviour
{
    public Sprite[] newSprites; // Array of new sprites to use
    public float changeTime = 5f; // Time when sprites will be changed

    private bool hasChanged = false;

    void Start()
    {
        Invoke("ChangeImages", changeTime); // Call ChangeImages function after specified time
    }

    void ChangeImages()
    {
        if (!hasChanged && newSprites != null && newSprites.Length > 0)
        {
            Image[] images = FindObjectsOfType<Image>(); // Find all objects with Image component

            foreach (Image image in images)
            {
                int randomIndex = Random.Range(0, newSprites.Length); // Select a random index from the array of new sprites
                Sprite newSprite = newSprites[randomIndex]; // Get the new sprite from the array

                image.sprite = newSprite; // Change the sprite of the Image component
            }

            hasChanged = true; // Mark that images have been changed
        }
    }
}
