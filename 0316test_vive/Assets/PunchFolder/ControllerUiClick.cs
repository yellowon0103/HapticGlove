using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI; // 추가: Button을 사용하기 위한 네임스페이스

public class ControllerUiClick : MonoBehaviour
{
    // 크로스헤어 변수
    public Transform crosshair;

    void Update()
    {
        // 크로스헤어 그리기
        ARAVRInput.DrawCrosshair(crosshair);

        // 1) VR 컨트롤러의 발사 버튼을 누르면
        if (ARAVRInput.Get(ARAVRInput.Button.One))
        {
            // 2) 컨트롤러가 향하는 방향으로 시선 만들기
            Ray ray = new Ray(ARAVRInput.LHandPosition, ARAVRInput.LHandDirection);
            RaycastHit hitInfo;

            // 2. 마우스의 위치가 바닥 위에 위치해 있다면
            if (Physics.Raycast(ray, out hitInfo))
            {
                // 3) Raycast로 검출된 객체가 UI 버튼인지 확인
                if (hitInfo.collider.GetComponent<Button>())
                {
                    // 4) UI 버튼에 클릭 이벤트 전달
                    ExecuteEvents.Execute(hitInfo.collider.gameObject, new PointerEventData(EventSystem.current), ExecuteEvents.pointerClickHandler);
                }
            }
        }
    }
}
