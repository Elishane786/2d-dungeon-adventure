using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTrigger : MonoBehaviour
{
    public GameObject dialogPanel; // Reference to the Panel containing your text

    private void Start()
    {
        if (dialogPanel != null)
        {
            dialogPanel.SetActive(false); // Hide the panel by default
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) // Check if the player entered the trigger
        {
            if (dialogPanel != null)
            {
                dialogPanel.SetActive(true); // Show the panel
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) // Check if the player exited the trigger
        {
            if (dialogPanel != null)
            {
                dialogPanel.SetActive(false); // Hide the panel
            }
        }
    }
}
