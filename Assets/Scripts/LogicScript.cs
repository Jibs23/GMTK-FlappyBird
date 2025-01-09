using UnityEngine;
using UnityEngine.UI;
public class LogicScript : MonoBehaviour
{
    public GameObject corpsePrefab;
    public SoundEffectPlayer sound;
    public GameObject GameOverScreen;
    public SceneManager SceneManager;
    public Text scoreText;
    public bool isGameOver = false;
    public bool IsGameRunning = false; // For when the game starts, waiting for input.
    public int playerScore = 0;
    [ContextMenu("Increase Score")] // This attribute adds a button to the inspector that calls the method when clicked
    public void addScore( int scoreToAdd) 
    {
        playerScore += scoreToAdd; // Increment playerScore by 1
        scoreText.text = playerScore.ToString(); // Update the scoreText to reflect the new score
        sound.PlayScoreSound();
    }
    public void restartGame()
    {
        SceneManager.ReloadCurrentScene(); // Reload the current scene
    }
    public void gameOver()
    {
        GameOverScreen.SetActive(true); // Show the game over screen
        isGameOver = true;
        sound.PlayGameOverSound();
    }
    void Start()
    {
        sound = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundEffectPlayer>();
    }
}
