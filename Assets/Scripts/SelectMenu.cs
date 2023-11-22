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

    public Sprite musicSheetSprite;
}
public class SelectMenu : MonoBehaviour
{
    [SerializeField] public Song[] songList = null;
    [SerializeField] Text txtSongName = null;
    [SerializeField] Text txtSongComposer = null;
    [SerializeField] Image imgDisk = null;
    [SerializeField] Image imgBackground = null;

    [SerializeField] GameObject TitleMenu = null;

    [SerializeField] GameObject GoMusicSheet = null;

    [SerializeField] Image musicSheetImage = null;

    public static SelectMenu instance;

    int currentSong = 0;

    void Start()
    {
        instance = this;
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
        GoMusicSheet.SetActive(true);

    }

    // MusicSheet화면에 songText넘기는 함수
    public string GetSongName()
    {
        return songList[currentSong].name;
    }

    // MusicSheet화면에ComposerText넘기는 함수
    public string GetComposerName()
    {
        return songList[currentSong].composer;
    }

    public Sprite GetSprite()
    {
        return songList[currentSong].sprite;
    }

    public Sprite GetMusicSheetSprite()
    {
        return songList[currentSong].musicSheetSprite;
    }


}
