using UnityEngine;

public class BarCollision : MonoBehaviour
{
    private ScoreManager scoreManager; // Reference to the ScoreManager script.

    void Start()
    {
        // Find and store a reference to the ScoreManager script.
        scoreManager = FindObjectOfType<ScoreManager>();
    }

    // This function is called whenever a 2D collision occurs.
    private void OnTriggerEnter2D(Collider2D collision) // colisao do anzol
    {
        // Check if the colliding object has a specific tag (you can customize the tag as needed).
        if (collision.gameObject.CompareTag("Fish"))
        {
            // Optionally, you can increase the score using the ScoreManager's IncreaseScore function.
            // scoreManager.IncreaseScore(scorePoints);

            // Destroy the colliding object.
            Destroy(collision.gameObject);
        }
    }
}
