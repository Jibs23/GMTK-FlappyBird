using Unity.VisualScripting;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    private SoundEffectPlayer sound;

    public void OnButtonClick()
    {
        sound.PlayButtonClickSound();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sound = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundEffectPlayer>();
    }

}
