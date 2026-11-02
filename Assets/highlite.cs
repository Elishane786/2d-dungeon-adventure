using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightOnProximity : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Color originalColor;
    public Color highlightColor = Color.yellow; // Set your desired highlight color

    void Start()
    {
        // Get the SpriteRenderer of the object
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            originalColor = spriteRenderer.color; // Store the original color
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the player entered the trigger zone
        if (other.CompareTag("Player") && spriteRenderer != null)
        {
            spriteRenderer.color = highlightColor; // Change color to highlight
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        // Check if the player exited the trigger zone
        if (other.CompareTag("Player") && spriteRenderer != null)
        {
            spriteRenderer.color = originalColor; // Revert to original color
        }
    }
}
