using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicSheet : MonoBehaviour
{
    [SerializeField] private SelectMenu selectMenu;

    [SerializeField] Text txtSongName = null;
    [SerializeField] Text txtComposerName = null;

    [SerializeField] Image backgroundSongImage = null;
    [SerializeField] Image musicSheetImage = null;

    public void ShowMusicSheetSongInfo(Song song)
    {
        // gameObject.SetActive(true);
        txtSongName.text = song.name;
        txtComposerName.text = song.composer;
    }

}
