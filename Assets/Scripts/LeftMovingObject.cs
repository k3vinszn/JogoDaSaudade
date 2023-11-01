using UnityEngine;

public class LeftMovingObject : MonoBehaviour
{
    public float moveSpeed = 5f; // Speed at which the object moves to the left
    public float minY = 1.0f;    // Minimum Y position
    public float maxY = 4.0f;    // Maximum Y position

    private Vector2 spawnPosition;
    public bool moveLeft;

    void Start()
    {
        float randomY = Random.Range(minY, maxY);
        spawnPosition = new Vector2(transform.position.x, randomY);
        transform.position = spawnPosition;
    }

    void Update()
    {
        if (moveLeft)
        {
            transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the trigger object has a specific tag (you can customize the tag as needed).
        if (other.gameObject.CompareTag("scoresystem"))
        {
            Vector3 initialPosition = other.transform.position;

            gameObject.SetActive(false);

            other.transform.position = initialPosition;
            other.transform.SetParent(null);
            other.gameObject.GetComponent<LeftMovingObject>().moveSpeed = 5f;
        }
    }
}
