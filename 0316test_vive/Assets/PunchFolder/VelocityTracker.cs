using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class VelocityTracker : MonoBehaviour
{
    public Transform trackedObject; // Tracker�� ����Ű�� Transform

    private Vector3 previousPosition;

    public Vector3 currentVelocity;

    void Start()
    {
        // �ʱ� ��ġ ����
        previousPosition = trackedObject.position;
    }

    void Update()
    {
        // Tracker�� �ӵ��� ����
        Vector3 velocity = (trackedObject.position - previousPosition) / Time.deltaTime;
        currentVelocity = velocity;
        /*
        // 1�ʸ��� Tracker�� �ӵ��� ���
        if (Time.time % 1f < Time.deltaTime)
        {
            Debug.Log("Tracker Velocity: " + velocity);
        }
        */

        // ���� ��ġ ����
        previousPosition = trackedObject.position;
    }

    public Vector3 sendVelocity()
    {
        return currentVelocity;
    }
}
