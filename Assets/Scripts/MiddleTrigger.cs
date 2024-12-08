using UnityEngine;

public class MiddleTrigger : MonoBehaviour
{
    public LogicScript logic;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Find the LogicScript component on the object with the "Logic" tag and assign it to the logic variable
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // If the object that collided with the trigger has the "Player" tag, call the addScore method on the logic component
        if (collision.gameObject.layer == 3 && logic.isGameOver == false)
        {
            logic.addScore(1);
            Debug.Log("Score added");
        }
    }

}
