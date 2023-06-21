
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections.Generic;

public class ControllerUiClick : MonoBehaviour
{
    public GameObject PlusButton; // 클릭 처리할 버튼 오브젝트
    public GameObject MinusButton; // 클릭 처리할 버튼 오브젝트

    private bool buttonPressedPlus = false; // Plus 버튼이 눌렸는지 여부를 저장하는 변수
    private bool buttonPressedMinus = false; // Minus 버튼이 눌렸는지 여부를 저장하는 변수

    public CubeCollision CubeCollisionImpact;
    public CubeCollision CubeCollisionVibration;

    void Update()
    {
        bool currentButtonStatePlus = ARAVRInput.Get(ARAVRInput.Button.One); // 현재 trigger 버튼 상태 가져오기
        bool currentButtonStateMinus = ARAVRInput.Get(ARAVRInput.Button.Thumbstick); // 현재 패드 버튼 상태 가져오기

        if (!currentButtonStatePlus && buttonPressedPlus)
        {
            //Debug.Log("Plus Trigger!");

            CubeCollisionImpact.transparentPunchWallImpact.SetActive(true);
            CubeCollisionVibration.transparentPunchWallVibration.SetActive(true);

            // 버튼 오브젝트를 클릭 처리
            ExecuteEvents.Execute(PlusButton, new PointerEventData(EventSystem.current), ExecuteEvents.pointerClickHandler);
        }

        buttonPressedPlus = currentButtonStatePlus; // Minus 버튼 상태 업데이트

        if (!currentButtonStateMinus && buttonPressedMinus)
        {
            //Debug.Log("Minus Trigger!");

            CubeCollisionImpact.transparentPunchWallImpact.SetActive(true);
            CubeCollisionVibration.transparentPunchWallVibration.SetActive(true);

            // 버튼 오브젝트를 클릭 처리
            ExecuteEvents.Execute(MinusButton, new PointerEventData(EventSystem.current), ExecuteEvents.pointerClickHandler);
        }

        buttonPressedMinus = currentButtonStateMinus; // Minus 버튼 상태 업데이트
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