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
}
