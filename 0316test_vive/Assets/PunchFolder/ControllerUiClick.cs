using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections.Generic;

public class ControllerUiClick : MonoBehaviour
{
    public Transform crosshair;
    public GraphicRaycaster raycaster;

    void Update()
    {
        ARAVRInput.DrawCrosshair(crosshair);

        if (ARAVRInput.Get(ARAVRInput.Button.One))
        {
            Debug.Log("Trigger!");

            Ray ray = new Ray(ARAVRInput.LHandPosition, ARAVRInput.LHandDirection);
            //RaycastHit hitInfo;

            // GraphicRaycaster를 사용하여 UI 요소와 충돌 감지
            PointerEventData pointerEventData = new PointerEventData(EventSystem.current);
            pointerEventData.position = new Vector2(Screen.width / 2f, Screen.height / 2f); // 화면 중앙으로 설정
            List<RaycastResult> results = new List<RaycastResult>();
            raycaster.Raycast(pointerEventData, results);

            if (results.Count > 0)
            {
                Debug.Log("Hit!");
            }
        }
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