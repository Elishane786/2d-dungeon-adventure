using System.Collections;
using System.Collections.Generic;
using System.Collections;
using TMPro;
using UnityEngine;

public class TypewriterEffect : MonoBehaviour
{
    [SerializeField] private TMP_Text dialogText; // Reference to TextMeshPro text
    [SerializeField] private float typingSpeed = 0.05f; // Speed of typing

    private Coroutine typingCoroutine;

    public void StartTyping(string text)
{
    // Ensure the GameObject is active
    if (!gameObject.activeSelf)
    {
        gameObject.SetActive(true);
    }

    if (typingCoroutine != null)
    {
        StopCoroutine(typingCoroutine); // Stop any ongoing typing
    }

    typingCoroutine = StartCoroutine(TypeText(text));
}

    private IEnumerator TypeText(string text)
{
    dialogText.text = ""; // Clear existing text

    foreach (char letter in text)
    {
        dialogText.text += letter; // Add one letter at a time
        yield return new WaitForSeconds(typingSpeed); // Wait before adding next letter
    }

    typingCoroutine = null; // Reset coroutine reference after completion
}


}
