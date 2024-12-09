using UnityEngine;

public class SoundEffectPlayer : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip flapSound, scoreSound, gameOverSound;

    public void PlayFlapSound()
    {
        audioSource.PlayOneShot(flapSound);
    }

    public void PlayScoreSound()
    {
        audioSource.PlayOneShot(scoreSound);
    }

    public void PlayGameOverSound()
    {
        audioSource.PlayOneShot(gameOverSound);
    }
}
