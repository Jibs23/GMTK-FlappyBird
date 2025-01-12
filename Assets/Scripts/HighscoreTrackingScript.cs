using UnityEngine;
using UnityEngine.UI;

public class HighscoreTrackingScript : MonoBehaviour
{
    public Text highscoreText;
    public Text currentScoreText;
    public LogicScript Logic;
    
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

            if (PlayerPrefs.GetInt("Highscore", 0) > 10 && PlayerPrefs.GetInt("hardmodeUnlocked", 0) == 0) // If the highscore is greater than or equal to 10 and hardmode is not unlocked
            {
                // Retrieve the current value
                bool isHardModeUnlocked = PlayerPrefs.GetInt("HardmodeUnlocked", 0) == 1;

                // Toggle the value
                isHardModeUnlocked = !isHardModeUnlocked;

                // Save the new value
                PlayerPrefs.SetInt("HardmodeUnlocked", isHardModeUnlocked ? 1 : 0);
                PlayerPrefs.Save();

                Debug.Log("HardmodeUnlocked is now " + isHardModeUnlocked);
            }
        }
    }
}
