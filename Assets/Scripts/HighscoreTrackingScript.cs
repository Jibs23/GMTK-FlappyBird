using UnityEngine;
using UnityEngine.UI;

public class HighscoreTrackingScript : MonoBehaviour
{
    public Text highscoreText;
    public Text currentScoreText;
    public LogicScript Logic;
    public bool UnlockedHardMode;
    
    void Start()
    {
        highscoreText.text = PlayerPrefs.GetInt("Highscore", 0).ToString();
        Logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }
    public void UpdateHighscore()
    {
        if (int.Parse(currentScoreText.text) > int.Parse(highscoreText.text)) // If the current score is greater than the highscore
        {
            PlayerPrefs.SetInt("Highscore", int.Parse(currentScoreText.text)); // Set the highscore to the current score
            highscoreText.text = currentScoreText.text;
            Debug.Log("Highscore updated");
        }
    }
}
