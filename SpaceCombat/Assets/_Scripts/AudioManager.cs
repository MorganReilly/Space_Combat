using UnityEngine;

/**
Adapted from: https://youtu.be/HhFKtiRd0qI

This script handles all of the audio in the game
*/

[System.Serializable]
public class Sound
{
    public string name; // name of sound -- use for referral
    public AudioClip clip; // Associate an audio file

    // Restrict Volume and Pitch-- Do this with Slider
    [Range(0f, 1f)] // Clamps volume between 0 and 1
    public float volume = 0.8f;
    [Range(0f, 1.5f)] // Clamps volume between 0 and 1
    public float pitch = 1.0f;

    [Range(0f, 0.5f)]
    public float volumeRand = 0.1f; // This is a multiplyer
    [Range(0f, 0.5f)]
    public float pitchRand = 0.01f;

    // Want a reference to object in game to play clip
    private AudioSource source;

    public void SetSource(AudioSource _source)
    {
        source = _source;
        source.clip = clip;
    }

    public void Play()
    {
        source.volume = volume * (1 + Random.Range(-volumeRand / 2f, volumeRand / 2f));
        source.pitch = pitch * (1 + Random.Range(-pitchRand / 2f, pitchRand / 2f));
        // Play associated clip
        source.Play();
    }
}
public class AudioManager : MonoBehaviour
{
    public static AudioManager amInstance;

    [SerializeField] Sound[] sounds;

    void Awake()
    {
        amInstance = this;

        // Check for multiple intances of AudioManager
        if (amInstance != null)
        {
            Debug.Log("Too many AudioManagers for Scene");
        }
        else
        {
            amInstance = this;
        }
    }

    void Start()
    {
        // Loop through each object -- Find correct sound and check if settings have been applied
        for (int i = 0; i < sounds.Length; i++)
        {
            GameObject _go = new GameObject("Sound_ " + i + "_" + sounds[i].name);

            sounds[i].SetSource(_go.AddComponent<AudioSource>()); // Doesn't store anything -- Ignored by garbage collection
        }

        // Testing
        PlaySound("Menu");
    }

    // Play sound -- Take in name of sound
    // Loop through all of sounds
    public void PlaySound(string _name)
    {
        for (int i = 0; i < sounds.Length; i++)
        {
            if (sounds[i].name == _name)
            {
                // Found correct sound
                // Skip multiple -- Don't duplicate names
                sounds[i].Play();
                return;
            }
        }

        // No sound found
        Debug.LogWarning("Sound not found! Check AudioManager -- SoundArray: " + _name);
    }
}
