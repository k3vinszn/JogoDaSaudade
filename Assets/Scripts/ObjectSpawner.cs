using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject objectToSpawn; // The GameObject prefab to be spawned
    public float spawnInterval = 2f; // Time interval between spawns in seconds

    void Start()
    {
        // Call the SpawnObject method every spawnInterval seconds, starting from 0 seconds
        InvokeRepeating("SpawnObject", 0f, spawnInterval);
    }

    void SpawnObject()
    {
        // Instantiate the objectToSpawn prefab at the spawner's position with its rotation
        GameObject spawnedObject = Instantiate(objectToSpawn, transform.position, Quaternion.identity);

        // Attach the LeftMovingObject script to the spawned object (for automatic left movement)
        LeftMovingObject leftMovement = spawnedObject.GetComponent<LeftMovingObject>();

        // Check if the spawned object has the LeftMovingObject script
        if (leftMovement != null)
        {
            // Set the move speed for the spawned object (if needed)
            leftMovement.moveSpeed = 5f; // You can adjust the move speed here
        }
        else
        {
            Debug.LogError("Spawned object does not have the LeftMovingObject script!");
        }
    }
}
