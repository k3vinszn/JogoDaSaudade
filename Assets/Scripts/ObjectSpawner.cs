using UnityEngine;
using System.Collections.Generic;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject[] objectsToSpawn; // Array of GameObject prefabs to be spawned
    public int poolSize = 10;           // Number of objects to be pooled
    public float spawnInterval = 2f;    // Time interval between spawns in seconds
    public bool goLeft;

    private List<GameObject> objectPool;

    void Start()
    {
        // Initialize the object pool
        objectPool = new List<GameObject>();
        foreach (GameObject prefab in objectsToSpawn)
        {
            for (int i = 0; i < poolSize; i++)
            {
                GameObject obj = Instantiate(prefab);
                obj.SetActive(false);
                objectPool.Add(obj);
            }
        }

        // Call the SpawnObject method every spawnInterval seconds, starting from 0 seconds
        InvokeRepeating("SpawnObject", 0f, spawnInterval);
    }

    void SpawnObject()
    {
        // Get an inactive object from the pool
        GameObject spawnedObject = GetInactiveObject();

        // Set the position of the spawned object
        spawnedObject.transform.position = transform.position;
        spawnedObject.SetActive(true);

        // Attach the LeftMovingObject script to the spawned object (for automatic left movement)
        LeftMovingObject leftMovement = spawnedObject.GetComponent<LeftMovingObject>();

        // Check if the spawned object has the LeftMovingObject script
        if (leftMovement != null)
        {
            leftMovement.moveLeft = goLeft;
        }
        else
        {
            Debug.LogError("Spawned object does not have the LeftMovingObject script!");
        }
    }

    GameObject GetInactiveObject()
    {
        // Get a random inactive object from the pool
        List<GameObject> inactiveObjects = objectPool.FindAll(obj => !obj.activeSelf);
        if (inactiveObjects.Count > 0)
        {
            int randomIndex = Random.Range(0, inactiveObjects.Count);
            return inactiveObjects[randomIndex];
        }

        // If no inactive objects are found, return null (this should not happen if poolSize is set correctly)
        return null;
    }

    void Update()
    {
        // Check if any active objects have moved out of the camera's view and deactivate them
        foreach (GameObject obj in objectPool)
        {
            if (obj.activeSelf && !IsVisible(obj.GetComponent<Renderer>()))
            {
                obj.SetActive(false);
            }
        }
    }

    bool IsVisible(Renderer renderer)
    {
        // Check if the object is visible from the main camera's perspective
        return renderer.isVisible;
    }
}
