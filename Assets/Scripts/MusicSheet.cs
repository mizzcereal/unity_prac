using UnityEngine;
using System.Xml;
using System.Collections.Generic;

public class MusicSheet : MonoBehaviour
{
    public float moveInterval = 1.0f; // 이동 간격 (초)
    private float elapsedTime = 0.0f;
    private float moveSpeed = 20.0f;

    void Update()
    {
        elapsedTime += Time.deltaTime;

        if (elapsedTime >= moveInterval)
        {
            // 일정 시간이 지났을 때 이미지를 이동
            transform.position += Vector3.up * moveSpeed;
            elapsedTime = 0.0f; // 시간을 재설정
        }

        // 이미지가 화면 아래로 벗어날 때 초기 위치로 이동
        if (transform.position.y < -10)
        {
            transform.position += new Vector3(0, 20f, 0);
        }
    }
}
