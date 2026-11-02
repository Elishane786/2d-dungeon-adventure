using TMPro;
using UnityEngine;

public class typeeffect : MonoBehaviour
{
    [SerializeField] private TMP_Text dialogText; // Reference to TextMeshPro text

    public void DisplayText(string text)
    {
        // Check if dialogText is assigned
        if (dialogText == null)
        {
            Debug.LogError("Dialog Text (TMP_Text) is not assigned!");
            return;
        }

        // Display the full text instantly
        dialogText.text = text;
    }
}
