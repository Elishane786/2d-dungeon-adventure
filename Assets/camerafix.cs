using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerafix : MonoBehaviour
{
    public Transform player;  // Reference to the player's Transform
    public Vector3 offset;    // Offset of the camera from the player
    public float panSpeed = 2f; // Speed at which the camera pans down
    public float panDuration = 2f; // Time required to hold S before panning

    private float holdTime = 0f; // Tracks how long S is held
    private bool isPanning = false; // Tracks if the camera is currently panning
    private float originalOffsetY; // Stores the original Y offset for resetting
    private const float minOffsetY = -4f; // Minimum Y offset limit for panning

    void Start()
    {
        // Store the original Y offset for resetting after panning
        originalOffsetY = offset.y;
    }

    void LateUpdate()
    {
        if (player != null)
        {
            // Default camera position following the player
            Vector3 targetPosition = new Vector3(player.position.x + offset.x, player.position.y + offset.y, offset.z);

            // Check if "S" is being held
            if (Input.GetKey(KeyCode.S))
            {
                holdTime += Time.deltaTime;

                // If "S" is held for the required duration, start panning down
                if (holdTime >= panDuration)
                {
                    isPanning = true;
                }
            }
            else
            {
                // Reset hold time and stop panning if "S" is released
                holdTime = 0f;
                isPanning = false;

                // Reset the offset to its original value when not panning
                offset.y = originalOffsetY;
            }

            // If panning, adjust the Y offset downward smoothly
            if (isPanning)
            {
                // Cap the downward panning at -4
                if (offset.y > minOffsetY)
                {
                    offset.y -= panSpeed * Time.deltaTime;
                }
            }

            // Apply the calculated position to the camera
            transform.position = targetPosition;
        }
    }
}
