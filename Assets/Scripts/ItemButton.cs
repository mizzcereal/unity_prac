using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemButton : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Text _songName;
    [SerializeField] private Text _composerName;
    [SerializeField] private Image _songImage;
    [SerializeField] private ItemButtonEvent _onClickEvent;
    
    

    public ItemButtonEvent OnClickEvent
    {
        get => _onClickEvent;
        set => _onClickEvent = value;
    }

    public string songNameValue
    {
        get => _songName.text;
        set => _songName.text = value;
    }

    public string ComposerNameValue
    {
        get => _composerName.text;
        set => _composerName.text = value;
    }

    public Image SongImage
    {
        get => _songImage;
        set => _songImage = value;
    }


    public void OnPointerClick(PointerEventData eventData)
    {
        _onClickEvent.Invoke(this);
    }
}

[System.Serializable]
public class ItemButtonEvent : UnityEvent<ItemButton> { }