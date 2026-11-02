using UnityEngine;

public class Arrow : MonoBehaviour
{
    private float speed;
    private ArrowSpawner spawner;

    public void SetSpeed(float newSpeed)
    {
        speed = newSpeed;
    }

    public void SetSpawner(ArrowSpawner spawnerReference)
    {
        spawner = spawnerReference;
    }

    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime); // Move left
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player hit by arrow!");
            // Destroy player or trigger death event
        }

        if (collision.gameObject.layer == LayerMask.NameToLayer("grounda"))
        {
            gameObject.SetActive(false); // Deactivate on collision with ground/wall
            if (spawner != null)
            {
                spawner.RespawnArrow(gameObject); // Respawn at start point
            }
        }
    }
}
