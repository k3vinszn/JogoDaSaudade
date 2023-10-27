using UnityEngine;

public class LeftMovingObject : MonoBehaviour
{
    public float moveSpeed = 5f; // Speed at which the object moves to the left
    public float minY = 1.0f;    // Minimum Y position
    public float maxY = 4.0f;    // Maximum Y position
    public float destroyTime = 10f; // Time after which the object will be destroyed (in seconds)

    private Vector2 spawnPosition;
    private float elapsedTime = 0f;

    void Start()
    {
        // Initialize the object's spawn position randomly between minY and maxY
        float randomY = Random.Range(minY, maxY);
        spawnPosition = new Vector2(transform.position.x, randomY);
        transform.position = spawnPosition;
    }

    void Update()
    {
        // Move the object to the left
        transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);

        // Increment the elapsed time
        elapsedTime += Time.deltaTime;

        // Check if the elapsed time has exceeded the destroyTime
        if (elapsedTime >= destroyTime)
        {
            // Destroy the game object
            Destroy(gameObject);
        }
    }
}
