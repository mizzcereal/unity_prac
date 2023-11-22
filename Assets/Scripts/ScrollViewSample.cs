using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollViewSample : MonoBehaviour
{
    [SerializeField] private RectTransform _content;
    [SerializeField] private GameObject _prefabListItem;

    [Space(10)]
    [Header("Scroll View Events")]
    [SerializeField] private ItemButtonEvent _eventItemClicked;
    [SerializeField] private ItemButtonEvent _eventItemOnSelect;
    [SerializeField] private ItemButtonEvent _eventItemOnSubmit;

    // SelectMenu 스크립트에서 가져온 songList 사용
    [SerializeField] private SelectMenu _selectMenu;

    [Space(10)]
    [Header("Default Selected Index")]
    [SerializeField] private int _defaultSelectedIndex = 0;

    [Space(10)]
    [Header("For Testing Only!")]
    [SerializeField] private int _testButtonCount = 1;

    // Start is called before the first frame update
    void Start()
    {
        // 런타임 시에만 실행되도록 에디터 코드 확인
        if (Application.isPlaying)
        {
            // _selectMenu를 초기화
            _selectMenu = FindObjectOfType<SelectMenu>();

            if (_testButtonCount > 0 && _selectMenu != null)
            {
                TestCreateItems(_testButtonCount);
            }
        }
    }

    private void TestCreateItems(int count)
    {
        // _selectMenu가 null이 아닌지 확인
        if (_selectMenu != null)
        {
            // SelectMenu의 songList를 순회하며
            for (int i = 0; i < count && i < _selectMenu.songList.Length; i++)
            {
                // SelectMenu의 songList에서 곡의 이름을 사용하여 스크롤 뷰에 아이템을 생성
                CreateItem(_selectMenu.songList[i].name);
            }
        }
        else
        {
            Debug.LogError("SelectMenu가 찾아지지 않았거나 songList가 null입니다.");
        }
    }

    private ItemButton CreateItem(string strName)
    {
        GameObject gObj = Instantiate(_prefabListItem, Vector3.zero, Quaternion.identity);

        if (gObj != null)
        {
            gObj.transform.SetParent(_content.transform);
            gObj.transform.localScale = Vector3.one;
            gObj.transform.localPosition = Vector3.zero;
            gObj.transform.localRotation = Quaternion.identity;
            gObj.name = strName;

            ItemButton item = gObj.GetComponent<ItemButton>();

            if (item != null)
            {
                item.ItemNameValue = strName;

                // 이벤트 핸들러 추가 전에 null 체크
                if (item.OnSelectEvent != null)
                    item.OnSelectEvent.AddListener((ItemButton) => { HandleEventItemOnSelect(item); });

                if (item.OnClickEvent != null)
                    item.OnClickEvent.AddListener((ItemButton) => { HandleEventItemOnClick(item); });

                if (item.OnSubmitEvent != null)
                    item.OnSubmitEvent.AddListener((ItemButton) => { HandleEventItemOnSubmit(item); });

                return item;
            }
            else
            {
                Debug.LogError("Prefab에서 ItemButton 컴포넌트를 찾을 수 없습니다.");
            }
        }
        else
        {
            Debug.LogError("Prefab이 인스턴스화되지 않았습니다.");
        }

        return null;
    }

    private void HandleEventItemOnClick(ItemButton item)
    {
        _eventItemClicked?.Invoke(item);
    }

    private void HandleEventItemOnSelect(ItemButton item)
    {
        _eventItemOnSelect?.Invoke(item);
    }

    private void HandleEventItemOnSubmit(ItemButton item)
    {
        _eventItemOnSubmit?.Invoke(item);
    }

    // Update is called once per frame
}