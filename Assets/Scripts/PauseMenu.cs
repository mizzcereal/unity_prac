using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{

    [SerializeField] GameObject stopMusicSheet = null;
    [SerializeField] GameObject goSelectMenu = null;
    private bool isPaused = false;
    public MusicSheet musicSheet; // Inspector에서 MusicSheet를 연결해줘야 함

    public void RestartButton()
    {
        if (musicSheet != null)
        {
            musicSheet.Restart();
        }
        else
        {
            Debug.LogError("MusicSheet가 연결되지 않았습니다.");
        }
        this.gameObject.SetActive(false);
    }

    public void StartButton()
    {
        this.gameObject.SetActive(false); 

        if (musicSheet != null)
        {
            musicSheet.ResumePlaying(); // 일시정지된 부분 다시 시작
        }
        else
        {
            Debug.LogError("MusicSheet가 연결되지 않았습니다.");
        }
    }

    public void GoSelectButton()
    {
        this.gameObject.SetActive(false);
        stopMusicSheet.SetActive(false);
        goSelectMenu.SetActive(true);
        
       if (musicSheet != null)
        {
            musicSheet.GoSelect(); // 일시정지된 부분 다시 시작
        }
    }
}
