using UnityEngine;
using UnityEngine.UI;

public class storytelling : MonoBehaviour
{
    public RectTransform content; // The RectTransform of your Content object
    public float scrollSpeed = 50f; // Speed of scrolling

    private float startY;

    void Start()
    {
        // Store initial position
        startY = content.anchoredPosition.y;
    }

    void Update()
    {
        // Scroll content upwards
        Vector2 position = content.anchoredPosition;
        position.y += scrollSpeed * Time.deltaTime;
        content.anchoredPosition = position;

        // Stop scrolling when all text is off-screen
        if (content.anchoredPosition.y >= startY + content.rect.height)
        {
            enabled = false; // Disable script after scrolling finishes
        }
    }
}
