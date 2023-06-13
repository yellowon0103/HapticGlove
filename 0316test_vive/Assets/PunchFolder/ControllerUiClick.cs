using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI; // �߰�: Button�� ����ϱ� ���� ���ӽ����̽�

public class ControllerUiClick : MonoBehaviour
{
    // ũ�ν���� ����
    public Transform crosshair;

    void Update()
    {
        // ũ�ν���� �׸���
        ARAVRInput.DrawCrosshair(crosshair);

        // 1) VR ��Ʈ�ѷ��� �߻� ��ư�� ������
        if (ARAVRInput.Get(ARAVRInput.Button.One))
        {
            // 2) ��Ʈ�ѷ��� ���ϴ� �������� �ü� �����
            Ray ray = new Ray(ARAVRInput.LHandPosition, ARAVRInput.LHandDirection);
            RaycastHit hitInfo;

            // 2. ���콺�� ��ġ�� �ٴ� ���� ��ġ�� �ִٸ�
            if (Physics.Raycast(ray, out hitInfo))
            {
                // 3) Raycast�� ����� ��ü�� UI ��ư���� Ȯ��
                if (hitInfo.collider.GetComponent<Button>())
                {
                    // 4) UI ��ư�� Ŭ�� �̺�Ʈ ����
                    ExecuteEvents.Execute(hitInfo.collider.gameObject, new PointerEventData(EventSystem.current), ExecuteEvents.pointerClickHandler);
                }
            }
        }
    }
}
