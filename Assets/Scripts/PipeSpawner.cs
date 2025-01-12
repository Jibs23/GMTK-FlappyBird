using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PipeSpawner : MonoBehaviour
{
    public GameObject pipePrefab;
    public LogicScript logic;
    public Text currentScoreText;
    private float timer = 0;
    public float heightOffset = 1;
    public float spawnRate = 2;
    public float Deficulty1 = 1.45f;
    public float Deficulty2 = 1.25f;
    public float Deficulty3 = 0.95f;
    void UpdateSpawnRate() // Update the pipe spawn rate based on the player's score.
    {
        if (logic.HardMode == false)
        {
            if (logic.playerScore == 10f)
            {
                spawnRate = Deficulty1;
                Debug.Log($"10 reached. Spawn rate is now {Deficulty1}");
            }
            else if (logic.playerScore < 10f)
            {
                return;
            }
            if (logic.playerScore == 25f)
            {
                spawnRate = Deficulty2;
                Debug.Log($"25 reached. Spawn rate is now {Deficulty2}");
            }
            else if (logic.playerScore < 25f)
            {
                return;
            }
            if (logic.playerScore == 50f)
            {
                spawnRate = Deficulty3;
                Debug.Log($"50 reached. Spawn rate is now {Deficulty3}");
            }
        }
    }
    void SpawnPipe()
    {
        // Calculate the lowest and highest points for the y value of the pipe
        float lowestPoint = transform.position.y - heightOffset;
        float highestPoint = transform.position.y + heightOffset;

        // Instantiate a new pipe at the spawner's position with a random y value between the lowest and highest points
        Instantiate(pipePrefab, new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), 0), transform.rotation);

        // Update the spawn rate if the player's score is high enough.
        UpdateSpawnRate();
    }
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        if (logic.HardMode == true)
        {
            spawnRate = Deficulty3;
        }
        SpawnPipe();
    }

    // Update is called once per frame
    void Update()
    {
        // If the timer is less than the spawn rate, increment the timer
        if (logic.isGameOver == true || logic.IsGameRunning == false) return;
        
        if (timer < spawnRate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            SpawnPipe();
            timer = 0;
        }
    }
}
