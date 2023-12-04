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
        StartCoroutine(DisableMusicSheetAfterBGMEnds(clip.length));
    }

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
    }

    public void ResumeBGM()
    {
        bgmPlayer.UnPause(); // BGM 재개
    }
    
    private IEnumerator DisableMusicSheetAfterBGMEnds(float duration)
    {
        yield return new WaitForSeconds(duration);

        // BGM이 끝나면 MusicSheet를 비활성화
        // 여기에 MusicSheet 게임 오브젝트를 찾아서 비활성화하는 코드를 넣으세요.
        MusicSheet musicSheet = FindObjectOfType<MusicSheet>();
        if (musicSheet != null)
        {
            musicSheet.gameObject.SetActive(false);
        }
    }


}
