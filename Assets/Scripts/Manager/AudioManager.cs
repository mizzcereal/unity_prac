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

    [SerializeField] private Sound[] sfx = null;
    [SerializeField] private Sound[] bgm = null;

    [SerializeField] private AudioSource bgmPlayer = null;
    [SerializeField] private AudioSource[] sfxPlayer = null;

    private AudioClip currentBGM;

    void Start()
    {
        instance = this;
    }

    public void PlaySelectBGM(AudioClip clip)
    {
        StopBGM(); // 현재 재생 중인 BGM 중지
        bgmPlayer.clip = clip;
        currentBGM = clip; // 현재 재생 중인 BGM 갱신
        bgmPlayer.Play();
    }

    // public void PlayBGM(AudioClip clip)
    // {
    //     StopBGM();
    //     bgmPlayer.clip = clip;
    //     currentBGM = clip;
    //     bgmPlayer.Play();
    //     Debug.Log("BGM is playing: " + clip.name);
    // }

    public void StopBGM()
    {
        bgmPlayer.Stop();
    }

    public void ReplayCurrentBGM()
    {
        if (currentBGM != null)
        {
            PlaySelectBGM(currentBGM);
        }
    }

    public void RestartBGM()
    {
        if (currentBGM != null)
        {
            PlaySelectBGM(currentBGM);
        }
    }


    public void PauseBGM()
    {
        if (bgmPlayer.isPlaying)
        {
            bgmPlayer.Pause();
        }
        else
        {
            bgmPlayer.UnPause();
        }
    }
}
