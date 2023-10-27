using UnityEngine;

public class ObjectSpawnerLeft : MonoBehaviour
{
    public GameObject[] objectsToSpawn; // Array of GameObject prefabs to be spawned
    public float spawnInterval = 2f;    // Time interval between spawns in seconds

    void Start()
    {
        // Call the SpawnObject method every spawnInterval seconds, starting from 0 seconds
        InvokeRepeating("SpawnObject", 0f, spawnInterval);
    }

    void SpawnObject()
    {
        // Generate a random index to select a prefab from the objectsToSpawn array
        int randomIndex = Random.Range(0, objectsToSpawn.Length);

        // Instantiate the randomly selected prefab at the spawner's position with its rotation
        GameObject spawnedObject = Instantiate(objectsToSpawn[randomIndex], transform.position, Quaternion.identity);

        // Flip the object's transform scale along the X-axis to invert its X direction
        spawnedObject.transform.localScale = new Vector3(-spawnedObject.transform.localScale.x, spawnedObject.transform.localScale.y, spawnedObject.transform.localScale.z);

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
