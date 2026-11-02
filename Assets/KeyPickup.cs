using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPickup : MonoBehaviour
{
    private Transform player; // Reference to the player
    private bool isPickedUp = false; // Whether the key is picked up

    public Vector3 offset = new Vector3(0, 1, 0); // Offset above player's head
    public TimeFreezeManager timeFreezeManager; // Reference to TimeFreezeManager
    public GameObject cooldownText; // Reference to CooldownText UI object

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) // Check if player touches key
        {
            player = collision.transform; // Get player's transform
            isPickedUp = true; // Mark key as picked up

            Debug.Log("Key picked up!");
            timeFreezeManager.EnableFreeze(); // Enable freezing functionality

            cooldownText.SetActive(true); // Show cooldown text
            GetComponent<Collider2D>().enabled = false; // Disable further collisions with key
        }
    }

    private void Update()
    {
        if (isPickedUp && player != null)
        {
            // Make the key follow and float above player's head
            transform.position = player.position + offset;
        }
    }
}


