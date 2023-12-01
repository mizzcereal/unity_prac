using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
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
        this.gameObject.SetActive(false); // 일단 PauseMenu 비활성화

        // 이어서 다른 기능을 호출하려면 MusicSheet 클래스의 해당 함수를 호출
        if (musicSheet != null)
        {
            musicSheet.ResumePlaying(); // 일시정지된 부분 다시 시작
        }
        else
        {
            Debug.LogError("MusicSheet가 연결되지 않았습니다.");
        }
    }
}
