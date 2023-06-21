using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowingCanvas : MonoBehaviour
{
    public GameObject[] images; // Image1, Image2, Image3을 순서대로 저장한 배열
    private int currentIndex = 0; // 현재 활성화된 이미지의 인덱스

    // Update 메서드에서 키 입력을 감지하고 처리합니다.
    void Update()
    {
        // 키보드 숫자 8을 누르면 Image1 비활성화, Image2 활성화
        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            Debug.Log(8);
            DeactivateImage(currentIndex); // 현재 활성화된 이미지 비활성화
            currentIndex = 1; // Image2 인덱스로 변경
            ActivateImage(currentIndex); // Image2 활성화
        }
        // 키보드 숫자 9를 누르면 Image2 비활성화, Image3 활성화
        else if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            DeactivateImage(currentIndex); // 현재 활성화된 이미지 비활성화
            currentIndex = 2; // Image3 인덱스로 변경
            ActivateImage(currentIndex); // Image3 활성화
        }
        // 키보드 숫자 0을 누르면 Image3 비활성화, Canvas 비활성화
        else if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            DeactivateImage(currentIndex); // 현재 활성화된 이미지 비활성화
            DeactivateCanvas(); // Canvas 비활성화
        }
    }

    // 이미지를 활성화하는 함수
    private void ActivateImage(int index)
    {
        images[index].SetActive(true);
    }

    // 이미지를 비활성화하는 함수
    private void DeactivateImage(int index)
    {
        images[index].SetActive(false);
    }

    // 캔버스를 비활성화하는 함수
    private void DeactivateCanvas()
    {
        gameObject.SetActive(false);
    }

}
