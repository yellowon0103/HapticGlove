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

    public TextUpdate TextUpdateScript;

    private void Start()
    {
        // 초기 색상 저장
        cubeRenderer = GetComponent<Renderer>();
        originalColor = cubeRenderer.material.color;
        GameObject transparentPunchWallImpact = GameObject.FindGameObjectWithTag("transparentPunchWall");
        GameObject transparentPunchWallVibration = GameObject.FindGameObjectWithTag("VibrationTransparentPunchWall");
        //Debug.Log("Start");
    }


    public void Update()
    {
        if (TextUpdateScript.currentIndex == 6 ||
                TextUpdateScript.currentIndex == 7 || TextUpdateScript.currentIndex == 8 || TextUpdateScript.currentIndex == 9 || TextUpdateScript.currentIndex == 10 ||
                TextUpdateScript.currentIndex == 11 || TextUpdateScript.currentIndex == 12)
        {
            transparentPunchWallImpact.SetActive(false);
        }

        if (TextUpdateScript.currentIndex == 17 ||
                TextUpdateScript.currentIndex == 18 || TextUpdateScript.currentIndex == 19 || TextUpdateScript.currentIndex == 20 || TextUpdateScript.currentIndex == 21 ||
                TextUpdateScript.currentIndex == 22 || TextUpdateScript.currentIndex == 23)
        {
            transparentPunchWallVibration.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("OnTriggerEnter");
        


        // 충돌한 오브젝트가 Vive Tracker인지 확인
        if (other.CompareTag("ViveTracker"))
        {
            if (this.CompareTag("transparentPunchWall"))
            {
                Debug.Log("transparentPunchWall");
                //ArduinoManagerScript.TriggerWall();
                ArduinoManagerScript.Punch(1);
            }

            else if (this.CompareTag("VibrationTransparentPunchWall"))
            {
                Debug.Log("VibrationTransparentPunchWall");
                //ArduinoManagerScript.TriggerWall();
                ArduinoManagerScript.Punch(2);
            }

            else
            {
                Debug.Log("else");
                if (transparentPunchWallImpact.activeSelf)
                {
                    Debug.Log("transparentPunchWallImpact.activeSelf");
                    // 색상 변경
                    cubeRenderer.material.color = Color.red;
                    transparentPunchWallImpact.SetActive(false);
                }
                else if (transparentPunchWallVibration.activeSelf)
                {
                    Debug.Log("transparentPunchWallVibration.activeSelf");
                    // 색상 변경
                    cubeRenderer.material.color = Color.red;
                    transparentPunchWallVibration.SetActive(false);
                }
                else
                {
                    Debug.Log("else else");
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



    /*
     
    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("OnTriggerEnter");

        

        // 충돌한 오브젝트가 Vive Tracker인지 확인
        if (other.CompareTag("ViveTracker"))
        {
            if (this.CompareTag("transparentPunchWall") && (TextUpdateScript.currentIndex == 17 ||
                TextUpdateScript.currentIndex == 19 || TextUpdateScript.currentIndex == 21 || TextUpdateScript.currentIndex == 22 || TextUpdateScript.currentIndex == 28 ||
                TextUpdateScript.currentIndex == 30 || TextUpdateScript.currentIndex == 31 || TextUpdateScript.currentIndex == 33 || TextUpdateScript.currentIndex == 18 ||
                TextUpdateScript.currentIndex == 20 || TextUpdateScript.currentIndex == 23 || TextUpdateScript.currentIndex == 29 || TextUpdateScript.currentIndex == 32 ||
                TextUpdateScript.currentIndex == 34)) 

            {
                //ArduinoManagerScript.TriggerWall();
                Debug.Log("if (this.CompareTag(\"transparentPunchWall\"))");
                ArduinoManagerScript.Punch(1);
            }


            
            else if (this.CompareTag("VibrationTransparentPunchWall") && (TextUpdateScript.currentIndex == 6 || TextUpdateScript.currentIndex == 10 ||
                TextUpdateScript.currentIndex == 12 || TextUpdateScript.currentIndex == 28 || TextUpdateScript.currentIndex == 30 ||
                TextUpdateScript.currentIndex == 31 || TextUpdateScript.currentIndex == 33 || TextUpdateScript.currentIndex == 7 || TextUpdateScript.currentIndex == 8 ||
                TextUpdateScript.currentIndex == 9 || TextUpdateScript.currentIndex == 11 || TextUpdateScript.currentIndex == 29 || TextUpdateScript.currentIndex == 32 ||
                TextUpdateScript.currentIndex == 34))
  
{
    Debug.Log("else if (this.CompareTag(\"VibrationTransparentPunchWall\"))");
    ArduinoManagerScript.Punch(2);
}

else
{
    Debug.Log("else");
    if (transparentPunchWallImpact.activeSelf)
    {
        Debug.Log("if (transparentPunchWallImpact.activeSelf)");
        // 색상 변경
        cubeRenderer.material.color = Color.red;
        transparentPunchWallImpact.SetActive(false);
        transparentPunchWallVibration.SetActive(false);


    }
    else if (transparentPunchWallVibration.activeSelf)
    {
        Debug.Log("else if (transparentPunchWallVibration.activeSelf)");
        // 색상 변경
        cubeRenderer.material.color = Color.red;

        transparentPunchWallImpact.SetActive(false);
        transparentPunchWallVibration.SetActive(false);


    }
    else
    {
        Debug.Log("else else");

        cubeRenderer.material.color = Color.blue;
        transparentPunchWallImpact.SetActive(false);
        transparentPunchWallVibration.SetActive(false);
    }
} 
        }
    }
     */
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