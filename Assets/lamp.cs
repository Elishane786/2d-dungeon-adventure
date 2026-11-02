using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamp : MonoBehaviour
{
    public Transform player; // Reference to the player's transform
    public float floatSpeed = 0.5f; // Speed at which the lantern floats
    public float floatAmount = 0.2f; // The amount of float (up/down movement)

    public Vector3 offset = new Vector3(0, 2, 0); // Offset for the lantern
    public Color glowColor1 = new Color(1f, 0.69f, 0.37f); // Initial glow color (FFB05D)
    public Color glowColor2 = new Color(0.37f, 1f, 0.91f); // New glow color (5EFFE9)

    private Light lanternLight; // Reference to the Light component
    private bool isGlowChanged = false; // Track glow state
    private bool isActivated = false; // Track if the lamp is activated

    void Start()
    {
        // Find and assign the player's transform dynamically if not set
        if (player == null)
        {
            GameObject playerObj = GameObject.FindWithTag("Player");
            if (playerObj != null)
            {
                player = playerObj.transform;
            }
            else
            {
                Debug.LogError("Player reference is missing! Ensure the player is tagged as 'Player'.");
            }
        }

        // Get the Light component
        lanternLight = GetComponentInChildren<Light>();
        if (lanternLight == null)
        {
            Debug.LogError("No Light component found under the Lamp prefab. Ensure the Light object has a Light component.");
        }
    }

    void Update()
    {
        // Only execute if the lamp has been activated
        if (isActivated && player != null)
        {
            // Follow the player with floating movement
            Vector3 targetPosition = player.position + offset + new Vector3(0, Mathf.Sin(Time.time * floatSpeed) * floatAmount, 0);
            transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * floatSpeed);
        }

        // Toggle glow color on pressing "R" (only works when activated)
        if (isActivated && Input.GetKeyDown(KeyCode.R) && lanternLight != null)
        {
            isGlowChanged = !isGlowChanged;
            lanternLight.color = isGlowChanged ? glowColor2 : glowColor1;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Activate the lamp when the player touches it
        if (!isActivated && collision.CompareTag("Player"))
        {
            isActivated = true; // Activate the lamp script
            Debug.Log("Lamp activated!");
        }
    }
}
