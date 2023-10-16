using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;


    [SerializeField] GameObject[] goGameUI = null;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // 게임 오브젝트가 다른 씬으로 넘어갈 때 파괴되지 않도록 설정
        }
        else
        {
            Destroy(gameObject); // 이미 인스턴스가 있는 경우 중복된 것을 파괴
        }
    }

    // Start is called before the first frame update
    public void GameStart()
    {
        for(int i = 0; i < goGameUI.Length; i++)
        {
            goGameUI[i].SetActive(true);
        }
    }
}
