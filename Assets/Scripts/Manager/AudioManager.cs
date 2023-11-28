using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Sound
{
    public string name;
    public AudioClip clip;
}

public class AudioManager : MonoBehaviour
{

    public static AudioManager instance;

    [SerializeField] Sound[] sfx = null;
    [SerializeField] Sound[] bgm = null;
    
    [SerializeField] AudioSource bgmPlayer = null;
    [SerializeField] AudioSource[] sfxPlayer = null;
    // Start is called before the first frame update
    

    void Start()
    {
        instance = this;
    }

    public void PlaySelectBGM(AudioClip clip)
    {
        // Stop any currently playing BGM
        StopBGM();

        // Play the selected BGM
        bgmPlayer.clip = clip;
        bgmPlayer.Play();
    }

    public void PlayBGM(AudioClip clip)
    {
        bgmPlayer.clip = clip;
        bgmPlayer.Play();
        Debug.Log("BGM is playing: " + clip.name);
    
    }

    public void StopBGM()
    {
        bgmPlayer.Stop();
    }
}
