
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections.Generic;

public class ControllerUiClick : MonoBehaviour
{
    public GameObject PlusButton; // Ŭ�� ó���� ��ư ������Ʈ
    public GameObject MinusButton; // Ŭ�� ó���� ��ư ������Ʈ

    private bool buttonPressedPlus = false; // Plus ��ư�� ���ȴ��� ���θ� �����ϴ� ����
    private bool buttonPressedMinus = false; // Minus ��ư�� ���ȴ��� ���θ� �����ϴ� ����

    public CubeCollision CubeCollisionImpact;
    public CubeCollision CubeCollisionVibration;

    void Update()
    {
        bool currentButtonStatePlus = ARAVRInput.Get(ARAVRInput.Button.One); // ���� trigger ��ư ���� ��������
        bool currentButtonStateMinus = ARAVRInput.Get(ARAVRInput.Button.Thumbstick); // ���� �е� ��ư ���� ��������

        if (!currentButtonStatePlus && buttonPressedPlus)
        {
            //Debug.Log("Plus Trigger!");

            CubeCollisionImpact.transparentPunchWallImpact.SetActive(true);
            CubeCollisionVibration.transparentPunchWallVibration.SetActive(true);

            // ��ư ������Ʈ�� Ŭ�� ó��
            ExecuteEvents.Execute(PlusButton, new PointerEventData(EventSystem.current), ExecuteEvents.pointerClickHandler);
        }

        buttonPressedPlus = currentButtonStatePlus; // Minus ��ư ���� ������Ʈ

        if (!currentButtonStateMinus && buttonPressedMinus)
        {
            //Debug.Log("Minus Trigger!");

            CubeCollisionImpact.transparentPunchWallImpact.SetActive(true);
            CubeCollisionVibration.transparentPunchWallVibration.SetActive(true);

            // ��ư ������Ʈ�� Ŭ�� ó��
            ExecuteEvents.Execute(MinusButton, new PointerEventData(EventSystem.current), ExecuteEvents.pointerClickHandler);
        }

        buttonPressedMinus = currentButtonStateMinus; // Minus ��ư ���� ������Ʈ
    }

}





/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ControllerUiClick : MonoBehaviour
{
    public Transform crosshair;

    void Update()
    {
        ARAVRInput.DrawCrosshair(crosshair);

        if (ARAVRInput.Get(ARAVRInput.Button.One))
        {
            Debug.Log("Trigger!");

            Ray ray = new Ray(ARAVRInput.LHandPosition, ARAVRInput.LHandDirection);
            RaycastHit hitInfo;

            if (Physics.Raycast(ray, out hitInfo))
            {
                Debug.Log("Raycast!");
                if (hitInfo.collider.GetComponent<Button>())
                {
                    Debug.Log("Button!");
                    Button button = hitInfo.collider.GetComponent<Button>();
                    button.onClick.Invoke();
                }
            }
        }
    }
}
*/