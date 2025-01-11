using UnityEngine;
using UnityEngine.UI;
public class LogicScript : MonoBehaviour
{
    public GameObject corpsePrefab;
    public SoundEffectPlayer sound;
    public GameObject GameOverScreen;
    public GameObject Checkmark;
    public Text scoreText;
    public bool HardMode = false;
    public bool isGameOver = false;
    public bool IsGameRunning = false; // For when the game starts, waiting for input.
    public int playerScore = 0;
    void Start()
    {
        HardMode = PlayerPrefs.GetInt("HardMode", 0) == 1; // Load the value of HardMode from the player's preferences
        Debug.Log("HardMode is currently " + HardMode);
        sound = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundEffectPlayer>();
    }
    public void OnToggleChange() // hardmode toggle
    {
        //TODO: Implement the hardmode toggle, the save does not work propperly. And the checkmark is a bitch.
        HardMode = !HardMode; //SWAP TO THE OPPOSITE OF THE CURRENT VALUE.
        PlayerPrefs.SetInt("HardMode", HardMode ? 1 : 0); // Save HardMode preference
        PlayerPrefs.Save();
        Debug.Log("HardMode is now " + HardMode);

        if (HardMode == true)
        {
            Checkmark.SetActive(true);
        }
        else if (HardMode == false)
        {
            Checkmark.SetActive(false);
        }
    }

    [ContextMenu("Increase Score")] // This attribute adds a button to the inspector that calls the method when clicked
    public void addScore( int scoreToAdd) 
    {
        playerScore += scoreToAdd; // Increment playerScore by 1
        scoreText.text = playerScore.ToString(); // Update the scoreText to reflect the new score
        sound.PlayScoreSound();
    }
    public void restartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name); // Reload the current scene
    }
    public void gameOver()
    {
        GameOverScreen.SetActive(true); // Show the game over screen
        isGameOver = true;

    }

    void Update()
    {
        if (isGameOver == true && Input.GetKeyDown(KeyCode.Space))
        {
            restartGame();
        }
    }
}
