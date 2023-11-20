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
    public void PlayBGM(string p_bgmName){
    for(int i = 0; i < bgm.Length; i++){
        if(p_bgmName == bgm[i].name)  // Use '==' for comparison
            {
                bgmPlayer.clip = bgm[i].clip;
                bgmPlayer.Play();
                return;  // Return after playing the clip
            }
        }
    }

    public void PlaySFX(string p_sfxName){
        for(int i = 0; i < sfx.Length; i++){  // Fix the loop condition to use 'sfx' array
            if(p_sfxName == sfx[i].name)  // Use '==' for comparison
            {
                for(int x = 0; x < sfxPlayer.Length; x++){
                    if(!sfxPlayer[x].isPlaying){
                        sfxPlayer[x].clip = sfx[i].clip;
                        sfxPlayer[x].Play();
                        return;
                    }
                }
                Debug.Log("모든 오디오플레이어가 재생 중입니다.");
                return;
            }
        }
    Debug.Log(p_sfxName + " 이름의 효과음이 없습니다.");
    }

    public void StopBGM()
    {
        bgmPlayer.Stop();
    }
}