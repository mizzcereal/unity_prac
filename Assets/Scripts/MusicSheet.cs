using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicSheet : MonoBehaviour
{
    [SerializeField] Text txtSongName = null;
  
    public static MusicSheet instance;

    void Start()
    {
        instance = this;
        Debug.Log("MusicSheet 인스턴스가 초기화되었습니다.");
    }

    public void SongText(string s_name)
    {
        txtSongName.text = s_name;
        // Add any additional logic you need for setting up the music sheet
    }
}
