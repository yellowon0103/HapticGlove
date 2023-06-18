using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class VelocityTracker : MonoBehaviour
{
    public Transform trackedObject; // Tracker를 가리키는 Transform

    private Vector3 previousPosition;

    public Vector3 currentVelocity;

    void Start()
    {
        // 초기 위치 설정
        previousPosition = trackedObject.position;
    }

    void Update()
    {
        // Tracker의 속도를 추정
        Vector3 velocity = (trackedObject.position - previousPosition) / Time.deltaTime;
        currentVelocity = velocity;
        /*
        // 1초마다 Tracker의 속도를 출력
        if (Time.time % 1f < Time.deltaTime)
        {
            Debug.Log("Tracker Velocity: " + velocity);
        }
        */

        // 이전 위치 갱신
        previousPosition = trackedObject.position;
    }

    public Vector3 sendVelocity()
    {
        return currentVelocity;
    }
}
