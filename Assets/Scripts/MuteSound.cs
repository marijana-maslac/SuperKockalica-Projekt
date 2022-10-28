using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuteSound : MonoBehaviour
{
    public GameObject audioOnIcon;
    public GameObject audioOffIcon;
    
    public void ToggleSound()
    {
        if (PlayerPrefs.GetInt("Muted", 0) == 0)
        {
            PlayerPrefs.SetInt("Muted", 1);
        }
        else
        {
            PlayerPrefs.SetInt("Muted", 0);
        }
        SetSoundState();
    }

    private void SetSoundState()
    {
        if (PlayerPrefs.GetInt("Muted", 0) == 0)
        {
            AudioListener.volume = 1;
            audioOnIcon.SetActive(false);
            audioOffIcon.SetActive(true);
        }
        else
        {
            AudioListener.volume = 0;
            audioOnIcon.SetActive(true);
            audioOffIcon.SetActive(false);
        }
    }
}
