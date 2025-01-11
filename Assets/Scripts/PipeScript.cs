using UnityEngine;

public class PipeScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Randomly rotate the pipe
        int RandomRotation = Random.Range(-2, 2);
        transform.Rotate(0, 0, RandomRotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
