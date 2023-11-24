using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Xml;

[System.Serializable]
// 곡 정보를 저장(이름,작곡가,곡대표이미지, 악보이미지)
public class Song
{
    public string name;
    public string composer;

    public TextAsset musicXMLFile;

    public Sprite sprite;

    public Sprite musicSheetSprite;
}
public class SelectMenu : MonoBehaviour
{
    // Song class를 songList로 만들고 곡 정보를 직접 넣을 수 있음
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
    }

    //시작 버튼
    public void BtnPlay()
    {
        GoMusicSheet.SetActive(true);
    }

    public void ShowSelectedSongInfo(Song selectedSong)
    {
        txtSongName.text = selectedSong.name;
        txtSongComposer.text = selectedSong.composer;
        imgDisk.sprite = selectedSong.sprite;
        imgBackground.sprite = selectedSong.sprite;

        AudioManager.instance.PlayBGM("BGM" + currentSong);

        // AudioManager 등을 이용하여 추가 작업 수행
    }

    
}
