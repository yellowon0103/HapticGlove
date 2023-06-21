using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowingCanvas : MonoBehaviour
{
    public GameObject[] images; // Image1, Image2, Image3�� ������� ������ �迭
    private int currentIndex = 0; // ���� Ȱ��ȭ�� �̹����� �ε���

    // Update �޼��忡�� Ű �Է��� �����ϰ� ó���մϴ�.
    void Update()
    {
        // Ű���� ���� 8�� ������ Image1 ��Ȱ��ȭ, Image2 Ȱ��ȭ
        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            Debug.Log(8);
            DeactivateImage(currentIndex); // ���� Ȱ��ȭ�� �̹��� ��Ȱ��ȭ
            currentIndex = 1; // Image2 �ε����� ����
            ActivateImage(currentIndex); // Image2 Ȱ��ȭ
        }
        // Ű���� ���� 9�� ������ Image2 ��Ȱ��ȭ, Image3 Ȱ��ȭ
        else if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            DeactivateImage(currentIndex); // ���� Ȱ��ȭ�� �̹��� ��Ȱ��ȭ
            currentIndex = 2; // Image3 �ε����� ����
            ActivateImage(currentIndex); // Image3 Ȱ��ȭ
        }
        // Ű���� ���� 0�� ������ Image3 ��Ȱ��ȭ, Canvas ��Ȱ��ȭ
        else if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            DeactivateImage(currentIndex); // ���� Ȱ��ȭ�� �̹��� ��Ȱ��ȭ
            DeactivateCanvas(); // Canvas ��Ȱ��ȭ
        }
    }

    // �̹����� Ȱ��ȭ�ϴ� �Լ�
    private void ActivateImage(int index)
    {
        images[index].SetActive(true);
    }

    // �̹����� ��Ȱ��ȭ�ϴ� �Լ�
    private void DeactivateImage(int index)
    {
        images[index].SetActive(false);
    }

    // ĵ������ ��Ȱ��ȭ�ϴ� �Լ�
    private void DeactivateCanvas()
    {
        gameObject.SetActive(false);
    }

}
