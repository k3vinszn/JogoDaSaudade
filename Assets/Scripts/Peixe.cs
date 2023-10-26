using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Peixe : MonoBehaviour
{
    [SerializeField] GameObject[] peixePrefab;
    [SerializeField] float secondSpawn = 0.5f;
<<<<<<< Updated upstream
    [SerializeField] float minTras;
    [SerializeField] float maxTras;
=======
    [SerializeField] float spawnXOffset = 1.0f; // Offset to spawn objects outside of the screen
>>>>>>> Stashed changes

    void Start()
    {
        StartCoroutine(PeixeSpawn());
    }

    IEnumerator PeixeSpawn()
    {
        while (true)
        {
<<<<<<< Updated upstream
            var wanted = Random.Range(minTras, maxTras);
            var position = new Vector3(-wanted, transform.position.y); // Update X-coordinate here
            GameObject gameObject = Instantiate(peixePrefab[Random.Range(0, peixePrefab.Length)]);
            gameObject.transform.position = position;
=======
            // Calculate the spawn position just outside of the screen on the right
            Vector3 spawnPosition = new Vector3(
                Camera.main.ViewportToWorldPoint(new Vector3(1, 0, 0)).x + spawnXOffset,
                transform.position.y,
                0
            );

            GameObject spawnedObject = Instantiate(peixePrefab[Random.Range(0, peixePrefab.Length)], spawnPosition, Quaternion.identity);

            // Add movement code here to move the object into the scene along the X-axis
            Rigidbody2D rb = spawnedObject.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                // Set the velocity to move the object along the X-axis to the left
                rb.velocity = new Vector2(-5.0f, 0.0f); // Adjust the speed as needed
            }

>>>>>>> Stashed changes
            yield return new WaitForSeconds(secondSpawn);
        }
    }
}
