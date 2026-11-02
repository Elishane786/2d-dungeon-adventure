using UnityEngine;
using UnityEngine.SceneManagement; // Required for scene loading
using System.Collections;

public class BlueDoorInteraction : MonoBehaviour
{
    public Animator doorAnimator; // Reference to the Animator controlling the door
    public Transform player; // Reference to the player's Transform
    public float interactionDistance = 3f; // Distance at which player can interact
    public KeyCode interactKey = KeyCode.E; // Key to interact with the door
    public FadeEffect fadeEffect; // Reference to the FadeEffect script
    public string nextSceneName; // The name of the next scene to load

    private bool isDoorOpen = false; // Tracks if the door has been opened

    private void Update()
    {
        // Check the distance between the player and the door
        if (Vector3.Distance(player.position, transform.position) <= interactionDistance)
        {
            // Check if the door is at Z = 0
            if (Mathf.Approximately(transform.position.z, 0f))
            {
                // Check for interaction key press
                if (Input.GetKeyDown(interactKey) && !isDoorOpen)
                {
                    OpenDoor();
                }
            }
        }
    }

    private void OpenDoor()
    {
        // Trigger the "IsOpened" parameter in the Animator to play the animation
        if (doorAnimator != null)
        {
            doorAnimator.SetBool("IsOpened", true);
            isDoorOpen = true;

            // Start the fading effect and load the next scene
            StartCoroutine(LoadNextScene());
        }
        else
        {
            Debug.LogError("Door Animator is not assigned in the Inspector!");
        }
    }

    private IEnumerator LoadNextScene()
    {
        // Start the fade-out effect
        if (fadeEffect != null)
        {
            fadeEffect.StartFadeOut();
            yield return new WaitForSeconds(fadeEffect.fadeDuration); // Wait for the fade to complete
        }
        else
        {
            Debug.LogError("FadeEffect is not assigned in the Inspector!");
        }

        // Load the next scene
        if (!string.IsNullOrEmpty(nextSceneName))
        {
            SceneManager.LoadScene(nextSceneName);
        }
        else
        {
            Debug.LogError("Next scene name is not set!");
        }
    }
}
