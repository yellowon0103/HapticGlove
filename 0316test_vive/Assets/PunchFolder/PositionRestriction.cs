using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionRestriction : MonoBehaviour
{
    private Vector3 startPosition;

    private void Start()
    {
        // �ʱ� ��ġ ����
        startPosition = transform.position;
    }

    private void Update()
    {
        // ��ġ ����
        transform.position = startPosition;
    }
}
