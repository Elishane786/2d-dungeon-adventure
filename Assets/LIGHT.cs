using System.Collections.Generic;
using UnityEngine;

public class LightManager : MonoBehaviour
{
    public Color glowColor1 = new Color(1f, 0.64f, 0.36f); // Original color (FFA45D)
    public Color glowColor2 = new Color(0.37f, 1f, 0.91f); // New color (5EFFE8)

    private Dictionary<GameObject, Vector3> shadowOriginalPositions = new Dictionary<GameObject, Vector3>();
    private Dictionary<GameObject, Vector3> sunnerOriginalPositions = new Dictionary<GameObject, Vector3>();
    private Dictionary<Light, Color> lightOriginalColors = new Dictionary<Light, Color>();

    private bool isStateToggled = false;

    void Start()
    {
        // Gather all shadow objects
        GameObject[] shadowObjects = GameObject.FindGameObjectsWithTag("shadow");
        foreach (GameObject shadow in shadowObjects)
        {
            shadowOriginalPositions[shadow] = shadow.transform.position;
        }

        // Gather all sunner objects
        GameObject[] sunnerObjects = GameObject.FindGameObjectsWithTag("sunners");
        foreach (GameObject sunner in sunnerObjects)
        {
            sunnerOriginalPositions[sunner] = sunner.transform.position;
        }

        // Gather all y-light objects
        GameObject[] lightObjects = GameObject.FindGameObjectsWithTag("y-light");
        foreach (GameObject lightObj in lightObjects)
        {
            Light light = lightObj.GetComponent<Light>();
            if (light != null)
            {
                lightOriginalColors[light] = light.color;
            }
            else
            {
                Debug.LogError($"Light object {lightObj.name} is missing a Light component.");
            }
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            isStateToggled = !isStateToggled;

            if (isStateToggled)
            {
                ApplyToggledState();
            }
            else
            {
                RevertOriginalState();
            }
        }
    }

    private void ApplyToggledState()
    {
        // Move shadow objects to Z = 0
        foreach (var shadow in shadowOriginalPositions.Keys)
        {
            Vector3 newPos = shadowOriginalPositions[shadow];
            newPos.z = 0;
            shadow.transform.position = newPos;
        }

        // Move sunner objects to Z = 3
        foreach (var sunner in sunnerOriginalPositions.Keys)
        {
            Vector3 newPos = sunnerOriginalPositions[sunner];
            newPos.z = 3;
            sunner.transform.position = newPos;
        }

        // Change the color of y-light objects
        foreach (var light in lightOriginalColors.Keys)
        {
            light.color = glowColor2;
        }
    }

    private void RevertOriginalState()
    {
        // Revert shadow objects to their original positions
        foreach (var shadow in shadowOriginalPositions)
        {
            shadow.Key.transform.position = shadow.Value;
        }

        // Revert sunner objects to their original positions
        foreach (var sunner in sunnerOriginalPositions)
        {
            sunner.Key.transform.position = sunner.Value;
        }

        // Revert the color of y-light objects
        foreach (var light in lightOriginalColors.Keys)
        {
            light.color = lightOriginalColors[light];
        }
    }
}
