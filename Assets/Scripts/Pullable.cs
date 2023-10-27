using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullableObject : MonoBehaviour
{
    private bool isStuck = false;
    private Transform pullingObject;

    void Update()
    {
        if (isStuck && pullingObject != null)
        {
            // Set the position of the pullable object to be the same as the pulling object
            transform.position = pullingObject.position;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // Check if the object is in contact with a pulling object
        if (other.CompareTag("PullingObject"))
        {
            isStuck = true;
            pullingObject = other.transform;
        }
    }
}
