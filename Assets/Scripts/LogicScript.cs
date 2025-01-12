using UnityEngine;
using UnityEngine.UI;
public class LogicScript : MonoBehaviour
{
    public GameObject corpsePrefab;
    public SoundEffectPlayer sound;
    public GameObject GameOverScreen;
    public GameObject Checkmark;
    public Text scoreText;
    public GameObject Highscoremanager;
    public GameObject HardModeOption;
    public bool HardMode = false;
    public bool isGameOver = false;
    public bool UnlockedHardMode = false;
    public bool IsGameRunning = false; // For when the game starts, waiting for input.
    public int playerScore = 0;
    public void CheckMarkManager()
    {
        if (HardMode == true)
        {
            Checkmark.SetActive(true);
        }
        else if (HardMode == false)
        {
            Checkmark.SetActive(false);
        }
    }
    void Start()
    {
        HardMode = PlayerPrefs.GetInt("HardMode", 0) == 1; // Load the value of HardMode from the player's preferences.
        UnlockedHardMode = PlayerPrefs.GetInt("HardmodeUnlocked", 0) == 1; // Check whether hardmode is unlocked.
        Debug.Log("HardMode is currently " + HardMode);
        sound = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundEffectPlayer>();
        CheckMarkManager();
    }
    public void OnToggleChange() // hardmode toggle
    {
        HardMode = !HardMode; //SWAP TO THE OPPOSITE OF THE CURRENT VALUE.
        PlayerPrefs.SetInt("HardMode", HardMode ? 1 : 0); // Save HardMode preference
        PlayerPrefs.Save();
        Debug.Log("HardMode is now " + HardMode);
        CheckMarkManager();
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
        if (PlayerPrefs.GetInt("HardmodeUnlocked", 0) == 1)
        {
            HardModeOption.SetActive(true);
        }
        else
        {
            HardModeOption.SetActive(false);
        }
        isGameOver = true;

    }

    void Update()
    {
        if (isGameOver == true && Input.GetKeyDown(KeyCode.Space))
        {
            restartGame();
        }
    }
    public void ResetSave()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();
        Debug.Log("<color=red>PlayerPrefs have been reset</color>");
    }
}
