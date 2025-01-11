using System.Collections;
using UnityEngine;

public class CorpseScript : MonoBehaviour
{
    public float TimeToDestroy = 20f;
    public float TimeBeforeFall = 2f;
    public LogicScript logic;
    Rigidbody2D myRigidbody;
    SpriteRenderer mySpriteRenderer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myRigidbody.bodyType = RigidbodyType2D.Static;
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        StartCoroutine(FallAfterTime(TimeBeforeFall)); // Start the coroutine
        StartCoroutine(DestroyAfterTime(TimeToDestroy)); // Start the coroutine
    }
    private IEnumerator FallAfterTime(float time)
    {
        yield return new WaitForSeconds(time); // Wait for the specified time
        myRigidbody.bodyType = RigidbodyType2D.Dynamic; // Change the body type to Dynamic
    }
    private IEnumerator DestroyAfterTime(float time)
    {
        yield return new WaitForSeconds(time); // Wait for the specified time
        Destroy(gameObject); // Destroy the GameObject
    }
}
