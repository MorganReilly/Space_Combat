using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

/** Adapted from: https://youtu.be/YOaYQrN1oYQ */

public class SettingsMenu : MonoBehaviour
{
    // Need reference to volume mixer
    public AudioMixer audioMixer;

    public void SetVolume(float volume)
    {
        Debug.Log(volume);
        audioMixer.SetFloat("volume", volume);
    }
}
