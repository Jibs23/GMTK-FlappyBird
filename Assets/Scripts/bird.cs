using UnityEngine;

public class bird : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float flap_strenght = 7;
    public LogicScript logic;
    public bool isDead = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) == true && isDead == false)
        {
            myRigidbody.linearVelocity = Vector2.up * flap_strenght;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        logic.gameOver();
        isDead = true;
    }
}
