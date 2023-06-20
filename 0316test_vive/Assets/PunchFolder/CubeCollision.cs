using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeCollision : MonoBehaviour
{
    private Color originalColor;
    private Renderer cubeRenderer;

    public ArduinoManager ArduinoManagerScript;

    public GameObject transparentPunchWallImpact;
    public GameObject transparentPunchWallVibration;


    private void Start()
    {
        // 초기 색상 저장
        cubeRenderer = GetComponent<Renderer>();
        originalColor = cubeRenderer.material.color;
        GameObject transparentPunchWallImpact = GameObject.FindGameObjectWithTag("transparentPunchWall");
        GameObject transparentPunchWallVibration = GameObject.FindGameObjectWithTag("VibrationTransparentPunchWall");
        //Debug.Log("Start");
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("OnTriggerEnter");

        

        // 충돌한 오브젝트가 Vive Tracker인지 확인
        if (other.CompareTag("ViveTracker"))
        {
            if (this.CompareTag("transparentPunchWall"))
            {
                //ArduinoManagerScript.TriggerWall();
                ArduinoManagerScript.Punch(1);
            }

            else if (this.CompareTag("VibrationTransparentPunchWall"))
            {
                //ArduinoManagerScript.TriggerWall();
                ArduinoManagerScript.Punch(2);
            }

            else
            {
                if (transparentPunchWallImpact.activeSelf)
                {
                    // 색상 변경
                    cubeRenderer.material.color = Color.red;
                    transparentPunchWallImpact.SetActive(false);
                }
                else if (transparentPunchWallVibration.activeSelf)
                {
                    // 색상 변경
                    cubeRenderer.material.color = Color.red;
                    transparentPunchWallVibration.SetActive(false);
                }
                else
                {
                    cubeRenderer.material.color = Color.blue;
                }
            } 
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //Debug.Log("OnTriggerExit");

        // 충돌이 끝난 경우, 원래 색상으로 복원
        if (other.CompareTag("ViveTracker"))
        {
            //Debug.Log("CompareTag");

            cubeRenderer.material.color = originalColor;
        }
    }
}



/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeCollision : MonoBehaviour
{
    private Color originalColor;
    private Renderer cubeRenderer;

    private void Start()
    {
        // 초기 색상 저장
        cubeRenderer = GetComponent<Renderer>();
        originalColor = cubeRenderer.material.color;

        Debug.Log("start");
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("OnCollisionEnter");

        // 충돌한 오브젝트가 Vive Tracker인지 확인
        if (collision.gameObject.CompareTag("ViveTracker"))
        {
            Debug.Log("CompareTag");

            // 색상 변경
            cubeRenderer.material.color = Color.red;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        Debug.Log("OnCollisionExit");

        // 충돌이 끝난 경우, 원래 색상으로 복원
        if (collision.gameObject.CompareTag("ViveTracker"))
        {
            Debug.Log("CompareTag");

            cubeRenderer.material.color = originalColor;
        }
    }
}
*/