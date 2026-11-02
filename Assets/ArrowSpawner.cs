using UnityEngine;

public class ArrowSpawner : MonoBehaviour
{
    public GameObject arrowPrefab; // The arrow prefab
    public int arrowCount = 5; // Number of arrows
    public float spacing = 2f; // Spacing between arrows
    public float arrowSpeed = 5f; // Speed of arrows

    private GameObject[] arrows;

    void Start()
    {
        arrows = new GameObject[arrowCount];
        for (int i = 0; i < arrowCount; i++)
        {
            Vector3 spawnPosition = transform.position + new Vector3(i * spacing, 0, 0);
            arrows[i] = Instantiate(arrowPrefab, spawnPosition, Quaternion.Euler(0, 0, 90)); // Spawn facing left
            arrows[i].layer = LayerMask.NameToLayer("Deadly");

            Arrow arrowScript = arrows[i].GetComponent<Arrow>();
            if (arrowScript != null)
            {
                arrowScript.SetSpawner(this);
                arrowScript.SetSpeed(arrowSpeed);
            }
        }
    }

    public void RespawnArrow(GameObject arrow)
    {
        arrow.transform.position = transform.position; // Reset position
        arrow.transform.rotation = Quaternion.Euler(0, 0, 90); // Ensure it faces left
        arrow.SetActive(true); // Reactivate arrow
        arrow.layer = LayerMask.NameToLayer("Deadly");
    }
}
