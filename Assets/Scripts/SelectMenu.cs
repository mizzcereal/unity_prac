using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Song
{
    public string name;
    public string composer;

    public int bpm;

    public Sprite sprite;
}
public class SelectMenu : MonoBehaviour
{
    [SerializeField] Song[] songList = null;
    [SerializeField] Text txtSongName = null;
    [SerializeField] Text txtSongComposer = null;
    [SerializeField] Image imgDisk = null;
    [SerializeField] Image imgBackground = null;

    [SerializeField] GameObject TitleMenu = null;

    int currentSong = 0;

    void Start()
    {
        SettingSong();
    }

    public void BtnNext()
    {
        if (++currentSong > songList.Length - 1)
        {
            currentSong = 0;
            
        }
        SettingSong();
    }

    public void BtnPrior()
    {
        if (--currentSong < 0)
        {
            currentSong = songList.Length - 1;
        }
        SettingSong();
    }

    void SettingSong()
    {
        txtSongName.text = songList[currentSong].name;
        txtSongComposer.text = songList[currentSong].composer;
        imgDisk.sprite = songList[currentSong].sprite;
        imgBackground.sprite = songList[currentSong].sprite;

        AudioManager.instance.PlayBGM("BGM" + currentSong);
    }
    public void BtnBack()
    {
        TitleMenu.SetActive(true);
        this.gameObject.SetActive(false);
    }

    public void BtnPlay()
    {
        this.gameObject.SetActive(false);
    }
}
