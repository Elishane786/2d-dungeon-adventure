using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObeliskActivator : MonoBehaviour
{
    private Animator animator; // Reference to Animator
    private bool isPlayerNearby = false; // Track if player is near
[SerializeField] private GameObject objectToMove;
    void Start()
    {
        // Get Animator component
        animator = GetComponent<Animator>();
        if (animator == null)
        {
            Debug.LogError("Animator component missing from Obelisk!");
        }

         if (objectToMove == null)
        {
            Debug.LogError("No object assigned to 'Object To Move' field in the Inspector!");
        }
    }

    void Update()
    {
        // Check for player input when nearby
        if (isPlayerNearby && Input.GetKeyDown(KeyCode.E))
        {
            ActivateObelisk();
        }
    }

    
     private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // Detect if player leaves trigger area
        if (collision.CompareTag("Player"))
        {
            isPlayerNearby = false;
            
        }
    }

    private void ActivateObelisk()
    {
        
        
        // Trigger "Activate" parameter in Animator
        if (animator != null)
        {
            animator.SetTrigger("Activate");
        }
        gameObject.tag = "Respawn";
         if (objectToMove != null)
        {
            objectToMove.transform.position = transform.position;
            Debug.Log($"{objectToMove.name} moved to obelisk position!");
        }
    }
}

