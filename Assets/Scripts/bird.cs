using UnityEngine;

public class bird : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public LogicScript logic;
    public SoundEffectPlayer sound;
    public float flap_strenght = 7;
    public bool isDead = false;
    public bool offScreen = false;
    private void Die() // This method is called when the bird dies
    {
        if (isDead) return;
        logic.gameOver();
        isDead = true;
        Debug.Log("Bird died");
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        sound = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundEffectPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) == true && isDead == false)
        {
            Debug.Log("Flap");
            myRigidbody.linearVelocity = Vector2.up * flap_strenght;
            sound.PlayFlapSound(); //? WHY IS THIS NOT CALLED?
        }

        if (transform.position.y > 8 || transform.position.y < -8) // If the bird is off screen
        {
            offScreen = true;
            if (isDead == false)
            {
                Debug.Log("Bird off screen");
            }
            Die();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)  // COLLISION DETECTION
    {
        Die();
    }
}
