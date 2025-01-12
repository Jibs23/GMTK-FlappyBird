using UnityEngine;

public class PipeMoveScript : MonoBehaviour
{
    public LogicScript logic;
    public float moveSpeed = 8;
    public float deadzone = -16;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < deadzone)
        {
            Destroy(gameObject);
        }
        if (logic.isGameOver == true || logic.IsGameRunning == false) return;

        transform.position += Vector3.left * moveSpeed * Time.deltaTime;

    }
}
