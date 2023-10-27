using UnityEngine;

public class Anzol : MonoBehaviour
{
    public float moveSpeed = 2.0f;
    public float maxY = 4.0f;
    public float minY = -4.0f;
    private Transform fishTransform;

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
            collision.transform.SetParent(transform.Find("AttachmentPoint"));
            collision.gameObject.GetComponent<LeftMovingObject>().moveSpeed = 0;
        }
    }
}

