using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class TimeFreezeManager : MonoBehaviour
{
   public TMP_Text cooldownText; // UI Text for cooldown display
    public float freezeDuration = 3f; // Duration of freeze in seconds
    public float cooldownDuration = 5f; // Cooldown duration in seconds

    private bool canFreeze = false; // Whether freezing is allowed
    private bool isOnCooldown = false; // Whether freeze is on cooldown

    public void EnableFreeze() // Called when key is picked up
    {
        canFreeze = true;
        cooldownText.gameObject.SetActive(true); // Show cooldown UI
        UpdateCooldownText(0); // Set initial text to "Ready"
    }

    private void Update()
    {
        if (canFreeze && Input.GetKeyDown(KeyCode.F) && !isOnCooldown)
        {
            StartCoroutine(FreezeTime());
        }
    }

    private IEnumerator FreezeTime()
    {
        Debug.Log("Arrows frozen!");
        isOnCooldown = true;

        // Freeze all arrows by stopping their movement
        Arrow[] arrows = FindObjectsOfType<Arrow>();
        foreach (Arrow arrow in arrows)
        {
            arrow.enabled = false; // Disable arrow movement
        }

        UpdateCooldownText(freezeDuration); // Show countdown for freeze duration

        yield return new WaitForSecondsRealtime(freezeDuration); // Wait for freeze duration

        Debug.Log("Arrows unfrozen!");
        foreach (Arrow arrow in arrows)
        {
            arrow.enabled = true; // Re-enable arrow movement
        }

        StartCoroutine(Cooldown());
    }

    private IEnumerator Cooldown()
    {
        float remainingCooldown = cooldownDuration;
        
        while (remainingCooldown > 0)
        {
            UpdateCooldownText(remainingCooldown);
            yield return new WaitForSecondsRealtime(1f);
            remainingCooldown -= 1f;
        }

        UpdateCooldownText(0); // Set text to "Ready"
        isOnCooldown = false;
    }

    private void UpdateCooldownText(float timeLeft)
    {
        if (timeLeft <= 0)
            cooldownText.text = "Ready";
        else
            cooldownText.text = "Cooldown: " + Mathf.Ceil(timeLeft).ToString() + "s";
    }
}
