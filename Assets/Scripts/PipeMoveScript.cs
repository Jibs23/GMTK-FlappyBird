using UnityEngine;

public class PipeMoveScript : MonoBehaviour
{
    public float moveSpeed = 5;
    public float deadzone = -10;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime;
        
        // If the pipe is past the deadzone, destroy it
        if (transform.position.x < deadzone)
        {
            Debug.Log("Pipe destroyed");
            Destroy(gameObject);
        }
    }
}
