using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicSheet : MonoBehaviour
{
    [SerializeField] Text txtSongName = null;
    [SerializeField] Text txtComposerName = null;

    [SerializeField] Image backgroundSongImage = null;
    [SerializeField] Image musicSheetImage = null;

    void Start()
    {
        TextSong();
        SpriteSong();
    }

    void TextSong()
    {
        // SelectMenu에서 현재 노래의 정보를 가져옵니다.
        string songName = SelectMenu.instance.GetSongName();
        string composerName = SelectMenu.instance.GetComposerName();

        // 가져온 노래 정보를 UI에 할당합니다.
        txtSongName.text = songName;
        txtComposerName.text = composerName;
    }

    void SpriteSong()
    {
        // SelectMenu에서 현재 노래의 이미지를 가져옵니다.
        Sprite songSprite = SelectMenu.instance.GetSprite();
        Sprite musicSheetSprite = SelectMenu.instance.GetMusicSheetSprite();

        // 가져온 노래 이미지를 backgroundSongImage의 sprite 속성에 할당합니다.
        backgroundSongImage.sprite = songSprite;
        musicSheetImage.sprite = musicSheetSprite;

    }
}
