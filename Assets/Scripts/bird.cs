using UnityEngine;
using System.Collections;

public class bird : MonoBehaviour
{
    public Animator birdAnimator;
    public Rigidbody2D myRigidbody;
    public LogicScript logic;
    public SoundEffectPlayer sound;
    public float flap_strenght = 7;
    public bool isDead = false;
    public bool offScreen = false;
    private Coroutine flapCoroutine;
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
        // Find the game objects with the tag "Logic" and "SoundManager" and get their components.
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        sound = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundEffectPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) == true && isDead == false)
        {
            if (flapCoroutine != null) /* If the bird is already flapping, stop the current flap coroutine and start a new one. */
            {
                StopCoroutine(flapCoroutine); /* Stop the current flap coroutine */ /*! doesen't really work, but whatever */
            }
            flapCoroutine = StartCoroutine(FlapCoroutine()); /* Start the flap coroutine */
            sound.PlayFlapSound();
            myRigidbody.linearVelocity = Vector2.up * flap_strenght;
            Debug.Log("Flap");
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
        private IEnumerator FlapCoroutine() /* This method is called when the bird flaps its wings. It plays the flap animation and resets the trigger after the animation is done. */
    {
        birdAnimator.SetTrigger("flap");
        yield return new WaitForSeconds(birdAnimator.GetCurrentAnimatorStateInfo(0).length); /* Wait an amount of time equal to the lenght of the animation at animation layer 0 */
        birdAnimator.ResetTrigger("flap");
        flapCoroutine = null; // Reset the coroutine reference when done
    }
    private void OnCollisionEnter2D(Collision2D collision)  // COLLISION DETECTION
    {
        Die();
    }
}
