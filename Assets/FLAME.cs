using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class FLAME : MonoBehaviour
{
    [Tooltip("Time interval to check and sync the colors, in seconds.")]
    public float syncInterval = 0.1f;

    private GameObject[] yLights;
    private GameObject[] yFlames;
    void Start()
    {
        // Initialize y-light and y-flame objects
        yLights = GameObject.FindGameObjectsWithTag("y-light");
        yFlames = GameObject.FindGameObjectsWithTag("y-flame");

        // Start the color synchronization loop
        InvokeRepeating(nameof(SyncColors), 0f, syncInterval);
    }

    private void SyncColors()
    {
        foreach (GameObject lightObj in yLights)
        {
            // Get the Light component
            Light lightComp = lightObj.GetComponent<Light>();
            if (lightComp == null)
            {
                Debug.LogError($"Light component missing on {lightObj.name}");
                continue;
            }

            // Find the closest y-flame object
            GameObject closestFlame = FindClosestFlame(lightObj, yFlames);
            if (closestFlame != null)
            {
                // Update the Particle System's Start Color
                ParticleSystem particleSystem = closestFlame.GetComponent<ParticleSystem>();
                if (particleSystem != null)
                {
                    // Update the start color of the flame
                    var main = particleSystem.main;
                    main.startColor = lightComp.color;
                }
                else
                {
                    Debug.LogError($"ParticleSystem component missing on {closestFlame.name}");
                }
            }
        }
    }

    private GameObject FindClosestFlame(GameObject lightObj, GameObject[] flames)
    {
        float minDistance = float.MaxValue;
        GameObject closestFlame = null;

        foreach (GameObject flame in flames)
        {
            float distance = Vector3.Distance(lightObj.transform.position, flame.transform.position);
            if (distance < minDistance)
            {
                minDistance = distance;
                closestFlame = flame;
            }
        }

        return closestFlame;
    }
}
