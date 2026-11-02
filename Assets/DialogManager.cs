using UnityEngine;

public class DialogManager : MonoBehaviour
{
    [SerializeField] private TypewriterEffect typewriterEffect; // Reference to TypewriterEffect script
    [SerializeField] private string[] dialogLines; // Array of dialog lines
    private int currentLineIndex = 0;

    void Start()
    {
        ShowNextLine(); // Start with the first line
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) // Check for "E" key press
        {
            ShowNextLine();
        }
    }

    private void ShowNextLine()
    {
        if (currentLineIndex < dialogLines.Length)
        {
            typewriterEffect.StartTyping(dialogLines[currentLineIndex]); // Display current line
            currentLineIndex++;
        }
        else
        {
            Debug.Log("End of dialog.");
            // Optionally hide dialog box or reset index here.
        }
    }
}
