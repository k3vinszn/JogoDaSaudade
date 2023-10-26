using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject objectPrefab;
    public float moveSpeed = 5f;
    public float spawnInterval = 3f;

    void Start()
    {
        // Start spawning objects every spawnInterval seconds
        InvokeRepeating("SpawnObject", 0f, spawnInterval);
    }

    void SpawnObject()
    {
        // Instantiate the object and set its initial position
        GameObject newObject = Instantiate(objectPrefab, transform.position, Quaternion.identity);

        // Get the object's rigidbody component to control its movement
        Rigidbody2D rb = newObject.GetComponent<Rigidbody2D>();

        // Ensure the object doesn't rotate
        rb.freezeRotation = true;

        // Set the object's initial velocity to move left
        rb.velocity = new Vector2(-moveSpeed, 0f);
    }
}
