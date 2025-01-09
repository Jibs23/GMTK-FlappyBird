using System.Collections;
using UnityEngine;

public class CorpseScript : MonoBehaviour
{
    public float TimeToDestroy = 20;
    public LogicScript logic;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        StartCoroutine(DestroyAfterTime(TimeToDestroy)); // Start the coroutine
    }

    private IEnumerator DestroyAfterTime(float time)
    {
        yield return new WaitForSeconds(time); // Wait for the specified time
        Destroy(gameObject); // Destroy the GameObject
    }
}
