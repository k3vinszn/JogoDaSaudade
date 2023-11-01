using UnityEngine;
using UnityEngine.UI;

public class Anzol : MonoBehaviour
{
    public float moveSpeed = 2.0f;
    public float maxY = 4.0f;
    public float minY = -4.0f;
    private Transform fishTransform;
    [SerializeField]
    Text textScore;
    int points = 0, counter = 0;

    private void Start()
    {
        textScore.text = ("score" + points);
    }


    void Update() //mouse input
    {
        float mouseY = Input.GetAxis("Mouse Y");
        float newPositionY = Mathf.Clamp(transform.position.y + mouseY * moveSpeed * Time.deltaTime, minY, maxY);
        transform.position = new Vector3(transform.position.x, newPositionY, transform.position.z);
    }


    private void OnTriggerEnter2D(Collider2D collision) // colisao do anzol
    {
        if (collision.gameObject.CompareTag("Fish"))
        {
            if (counter < 1)
            {
                // Store the initial position of the fish before deactivating it
                Vector3 initialPosition = collision.transform.position;

                // Deactivate the fish
                collision.gameObject.SetActive(false);

                // Reset the fish's position and state before reactivating it
                collision.transform.position = initialPosition;
                collision.transform.SetParent(null);
                collision.gameObject.GetComponent<LeftMovingObject>().moveSpeed = 5f; // Set the moveSpeed to the initial value
                counter++;
            }
        }
          
           

        if (collision.gameObject.CompareTag("scoresystem"))
        {
            points += counter;
            textScore.text = ("peixes:" + points);
            counter = 0;
        }
    }
}
