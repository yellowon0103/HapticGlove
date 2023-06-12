using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionRestriction : MonoBehaviour
{
    private Vector3 startPosition;

    private void Start()
    {
        // 초기 위치 저장
        startPosition = transform.position;
    }

    private void Update()
    {
        // 위치 고정
        transform.position = startPosition;
    }
}
