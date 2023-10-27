using UnityEngine;

public class Shark : MonoBehaviour
{
    public float moveSpeed = 5f; // Speed at which the object moves to the left
    private float elapsedTime = 0f;

    void Update()
    {
        // Move the object to the left
        transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);

        // Increment the elapsed time
        elapsedTime += Time.deltaTime;

        // Check if the object is outside the screen boundaries
        if (!IsVisible())
        {
            // Deactivate the object
            gameObject.SetActive(false);
        }

        // Respawn the object every 10 seconds
        if (elapsedTime >= 10f)
        {
            // Reset elapsed time
            elapsedTime = 0f;

            // Move the object back to its initial position (or any desired position)
            transform.position = new Vector2(10f, Random.Range(1f, 5f));

            // Activate the object
            gameObject.SetActive(true);
        }
    }

    bool IsVisible()
    {
        // Check if the object is within the camera's view
        Vector3 screenPoint = Camera.main.WorldToViewportPoint(transform.position);
        return screenPoint.x > 0 && screenPoint.x < 1 && screenPoint.y > 0 && screenPoint.y < 1;
    }
}
