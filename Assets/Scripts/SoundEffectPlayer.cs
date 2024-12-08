using UnityEngine;

public class SoundEffectPlayer : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip flapSound, scoreSound, gameOverSound;

    public void PlayFlapSound()
    {
        Debug.Log("Flap sound played");
        audioSource.clip = flapSound;
        audioSource.Play();
    }

    public void PlayScoreSound()
    {
        audioSource.clip = scoreSound;
        audioSource.Play();
    }

    public void PlayGameOverSound()
    {
        audioSource.clip = gameOverSound;
        audioSource.Play();
    }
}
