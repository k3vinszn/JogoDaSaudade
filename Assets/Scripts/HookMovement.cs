using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullingObject : MonoBehaviour
{
    public float moveSpeed = 2.0f;
    public float pullSpeed = 5.0f;

    private bool isPulling = false;
    private GameObject objectToPull;

    void Update()
    {
        // Move the object up and down based on player input
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 moveDirection = new Vector3(0, verticalInput, 0);
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);

        if (isPulling && objectToPull != null)
        {
            // Pull the object
            Vector3 direction = (transform.position - objectToPull.transform.position).normalized;
            objectToPull.transform.Translate(direction * pullSpeed * Time.deltaTime);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // Check if the object collided with another object
        if (other.CompareTag("PullableObject"))
        {
            isPulling = true;
            objectToPull = other.gameObject;
        }
    }

    void OnTriggerExit(Collider other)
    {
       

        // Check if the object stopped colliding with another object
        if (other.CompareTag("PullableObject"))
        {
            isPulling = false;
            objectToPull = null;
        }

    }
}
