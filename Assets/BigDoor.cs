using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BigDoor : MonoBehaviour
{
    public FadeEffect fadeEffect; // Reference to FadeEffect script
    public GameObject fadeMessage; // Reference to FadeMessage UI object
    public float interactionDistance = 2f; // Distance within which player can interact
    public Transform player; // Reference to player's Transform

    private bool isPlayerNearby = false;

    void Update()
    {
        // Check if player is within interaction distance
        if (Vector3.Distance(transform.position, player.position) <= interactionDistance)
        {
            isPlayerNearby = true;

            // Check if player presses 'E'
            if (Input.GetKeyDown(KeyCode.E))
            {
                StartCoroutine(HandleDoorInteraction());
            }
        }
        else
        {
            isPlayerNearby = false;
        }
    }

    IEnumerator HandleDoorInteraction()
    {
        fadeEffect.StartFadeOut(); // Trigger fade-out effect
        yield return new WaitForSeconds(fadeEffect.fadeDuration); // Wait for fade-out to complete

        fadeMessage.SetActive(true); // Show the message after fade-out

        yield return new WaitForSeconds(5f); // Wait for 5 seconds before hiding message (optional)

        fadeMessage.SetActive(false); // Hide message if you want it to disappear after some time
    }
}
