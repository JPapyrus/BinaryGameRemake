using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SongLoop : MonoBehaviour
{
    public AudioSource musicSource;
    public AudioClip easySong;
    public AudioClip mediumSong;
    public AudioClip hardSong;

    // floats are for the seconds
    float timeLoopStart;
    float timeLoopEnd;

    void Start()
    {
        // Crescent Moon
        if (PlayerPrefs.GetString("Difficulty") == "Easy")
        {
            musicSource.clip = easySong;
            timeLoopStart = 9.3f;
            timeLoopEnd = 140.2f;
        }

        // Morning Routine
        else if (PlayerPrefs.GetString("Difficulty") == "Medium")
        {
            musicSource.clip = mediumSong;
            timeLoopStart = 0.0f;
            timeLoopEnd = 276.924f;
        }

        // Memories of Spring
        else if (PlayerPrefs.GetString("Difficulty") == "Hard")
        {
            musicSource.clip = hardSong;
            timeLoopStart = 0.0f;
            timeLoopEnd = 237.7f;
        }
        musicSource.Play();
    }

    void Update()
    {
        if (musicSource.time > timeLoopEnd)
            musicSource.time = timeLoopStart;

    }

}
