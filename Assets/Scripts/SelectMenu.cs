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
    public AudioClip audioClip;
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

    void Start()
    {
        instance = this;
    }

    //시작 버튼
    public void BtnPlay()
    {
        GoMusicSheet.SetActive(true);
        this.gameObject.SetActive(false);
        AudioManager.instance.StopBGM(); 
        Invoke("PlaySelectedBGM", 3f); // 선택한 노래를 처음부터 재생
    }

    private void PlaySelectedBGM()
    {
        AudioManager.instance.ReplayCurrentBGM(); // 선택한 노래를 처음부터 재생
        FindObjectOfType<MusicSheet>().measureTime = 0f;
    }

    public void ShowSelectedSongInfo(Song selectedSong)
    {
        txtSongName.text = selectedSong.name;
        txtSongComposer.text = selectedSong.composer;
        imgDisk.sprite = selectedSong.sprite;
        imgBackground.sprite = selectedSong.sprite;
    }

    
}
