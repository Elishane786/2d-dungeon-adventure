using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cainos.PixelArtPlatformer_Dungeon;

using UnityEngine;

public class Simpledoor : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Animator animator; // Reference to Animator
    [SerializeField] private Collider2D physicalCollider; // Physical collider for blocking movement

    [Header("Settings")]
    [SerializeField] private string openParameter = "IsOpened"; // Animator parameter name
    private bool isOpened = false; // Tracks whether the door is open

    private bool isPlayerNearby = false; // Tracks if the player is near the door

    void Start()
    {
        // Ensure proper initial state
        UpdateDoorState();
    }

    void Update()
    {
        // Check for interaction input when the player is nearby
        if (isPlayerNearby && Input.GetKeyDown(KeyCode.E))
        {
            ToggleDoor();
        }
    }

    private void ToggleDoor()
    {
        isOpened = !isOpened; // Toggle door state
        UpdateDoorState(); // Update visuals and physics
    }
private IEnumerator DisableColliderWithDelay()
{
    yield return new WaitForEndOfFrame(); // Wait until end of frame
    if (physicalCollider != null)
    {
        physicalCollider.enabled = false;
        Debug.Log("Physical collider disabled after delay.");
    }
}
    private void UpdateDoorState()
    {
        // Update Animator parameter
        if (animator != null)
        {
            animator.SetBool(openParameter, isOpened);
        }

        // Enable/disable physical collider based on door state
        if (physicalCollider != null)
        {
            physicalCollider.enabled = !isOpened;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = true;
            Debug.Log("Player near door. Press E to interact.");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = false;
            Debug.Log("Player left door area.");
        }
    }
}
