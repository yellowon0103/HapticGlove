
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// 사용자가 마우스를 클릭한 지점에 복셀을 1개 만들고 싶다.
// 필요 속성: 복셀 공장

public class VoxelMaker : MonoBehaviour
{

    // 추가
    Vector3 originScale = Vector3.one * 0.005f;
    // 추가

    // 복셀 공장
    public GameObject voxelFactory;
    // 오브젝트 풀의 크기
    public int voxelPoolSize = 20;
    // 오브젝트 풀
    public static List<GameObject> voxelPool = new List<GameObject>();
    // 생성 시간
    public float createTime = 0.1f;
    // 경과 시간
    float currentTime = 0;
    // 크로스헤어 변수
    public Transform crosshair;

    // 추가 LineRenderer
    public LineRenderer lineRenderer;
    // 추가

    void Start()
    {
        // 오브젝트 풀에 비활성화된 복셀을 담고 싶다.
        for (int i = 0; i < voxelPoolSize; i++)
        {
            // 1. 복셀 공장에서 복셀 생성하기
            GameObject voxel = Instantiate(voxelFactory);
            // 2. 복셀 비활성화하기
            voxel.SetActive(false);
            // 3. 복셀을 오브젝트 풀에 담고 싶다.
            voxelPool.Add(voxel);
        }

        // 추가
        lineRenderer.positionCount = 2;
        lineRenderer.startWidth = 0.02f;
        lineRenderer.endWidth = 0.02f;
        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
        // 추가
    }

    void Update()
    {
        // 크로스헤어 그리기
        ARAVRInput.DrawCrosshair(crosshair);

        // 1) VR 컨트롤러의 발사 버튼을 누르면
        if (ARAVRInput.Get(ARAVRInput.Button.One))
        {
            // 일정 시간마다 복셀을 만들고 싶다.
            // 1. 경과 시간이 흐른다.
            currentTime += Time.deltaTime;

            // 2. 경과 시간이 생성 시간을 초과했다면
            if (currentTime > createTime)
            {
                // Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                // 2) 컨트롤러가 향하는 방향으로 시선 만들기
                Ray ray = new Ray(ARAVRInput.LHandPosition, ARAVRInput.LHandDirection);
                RaycastHit hitInfo = new RaycastHit();

                // 2. 마우스의 위치가 바닥 위에 위치해 있다면
                if (Physics.Raycast(ray, out hitInfo))
                {
                    // 복셀 오브젝트 풀 이용하기
                    // 1. 만약 오브젝트 풀에 복셀이 있다면
                    if (voxelPool.Count > 0)
                    {
                        // 복셀을 생성했을 때만 경과 시간을 초기화해준다.
                        currentTime = 0;
                        // 2. 오브젝트 풀에서 복셀을 하나 가져온다.
                        GameObject voxel = voxelPool[0];
                        // 3. 복셀을 활성화한다.
                        voxel.SetActive(true);
                        // 4. 복셀을 배치하고 싶다.
                        voxel.transform.position = hitInfo.point;
                        // 5. 오브젝트 풀에서 복셀을 제거한다.
                        voxelPool.RemoveAt(0);
                    }

                    //추가
                    if (Physics.Raycast(ray, out hitInfo))
                    {
                        crosshair.position = hitInfo.point;
                        crosshair.forward = -Camera.main.transform.forward;
                        crosshair.localScale = originScale * Mathf.Max(1, hitInfo.distance);

                        lineRenderer.SetPosition(0, ray.origin);
                        lineRenderer.SetPosition(1, hitInfo.point);
                        lineRenderer.enabled = true;
                    }
                    else
                    {
                        lineRenderer.enabled = false;
                    }

                    //추가


                }
            }
        }
        //
        // 선택한 객체를 저장할 변수
        GameObject selectedObject = null;
        Vector3 distanceToSelectedObject = Vector3.zero; // 추가: 컨트롤러와 선택한 객체 사이의 거리
        Rigidbody selectedObjectRigidbody = null; // 추가: 선택된 객체의 Rigidbody 컴포넌트

        // 1) VR 컨트롤러의 트랙패드 버튼을 누르면
        if (ARAVRInput.Get(ARAVRInput.Button.Two))
        {
            // 컨트롤러 Ray 생성
            Ray ray = new Ray(ARAVRInput.LHandPosition, ARAVRInput.LHandDirection);
            RaycastHit hitInfo;
            // 2. 마우스의 위치가 바닥 위에 위치해 있다면
            if (Physics.Raycast(ray, out hitInfo))
            {
                // 충돌한 객체의 Collider 가져오기
                Collider collider = hitInfo.collider;

                // 바닥 위의 객체에 충돌했을 경우
                if (collider.CompareTag("FloorObject"))
                {
                    // 컨트롤러로 선택한 객체를 움직이기 위해 저장
                    selectedObject = collider.gameObject;

                    // 추가: 컨트롤러와 선택한 객체 사이의 거리 계산
                    distanceToSelectedObject = selectedObject.transform.position - ARAVRInput.LHandPosition;

                    // Rigidbody 컴포넌트 가져오기
                    selectedObjectRigidbody = selectedObject.GetComponent<Rigidbody>();

                    // Rigidbody가 없다면 추가
                    if (selectedObjectRigidbody == null)
                    {
                        selectedObjectRigidbody = selectedObject.AddComponent<Rigidbody>();
                    }

                    // 물리 영향을 받도록 설정
                    selectedObjectRigidbody.isKinematic = false;

                }
            }
        }
        // 2) VR 컨트롤러의 발사 버튼을 놓으면
        if (ARAVRInput.GetUp(ARAVRInput.Button.Two))
        {
            // 선택한 객체 해제
            selectedObject = null;
        }

        // 선택한 객체가 있을 경우, 컨트롤러의 위치와 방향으로 객체 이동
        if (selectedObject != null)
        {
            // 거리를 유지하면서 객체 이동
            Vector3 targetPosition = ARAVRInput.LHandPosition + distanceToSelectedObject;
            selectedObjectRigidbody.MovePosition(targetPosition);
            selectedObject.transform.rotation = Quaternion.LookRotation(ARAVRInput.LHandDirection);
        }
        //
        //


    }
}

/*

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// 사용자가 마우스를 클릭한 지점에 복셀을 1개 만들고 싶다.
// 필요 속성: 복셀 공장
public class VoxelMaker : MonoBehaviour
{
    // 복셀 공장
    public GameObject voxelFactory;
    // 오브젝트 풀의 크기
    public int voxelPoolSize = 20;
    // 오브젝트 풀
    public static List<GameObject> voxelPool = new List<GameObject>();
    // 생성 시간
    public float createTime = 0.1f;
    // 경과 시간
    float currentTime = 0;
    // 크로스헤어 변수
    public Transform crosshair;

    void Start()
    {
        // 오브젝트 풀에 비활성화된 복셀을 담고 싶다.
        for (int i = 0; i < voxelPoolSize; i++)
        {
            // 1. 복셀 공장에서 복셀 생성하기
            GameObject voxel = Instantiate(voxelFactory);
            // 2. 복셀 비활성화하기
            voxel.SetActive(false);
            // 3. 복셀을 오브젝트 풀에 담고 싶다.
            voxelPool.Add(voxel);
        }
    }

    void Update()
    {
        // 크로스헤어 그리기
        ARAVRInput.DrawCrosshair(crosshair);

        // 1) VR 컨트롤러의 발사 버튼을 누르면
        if (ARAVRInput.Get(ARAVRInput.Button.One))
        {
            // 일정 시간마다 복셀을 만들고 싶다.
            // 1. 경과 시간이 흐른다.
            currentTime += Time.deltaTime;

            // 2. 경과 시간이 생성 시간을 초과했다면
            if (currentTime > createTime)
            {
                // Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                // 2) 컨트롤러가 향하는 방향으로 시선 만들기
                Ray ray = new Ray(ARAVRInput.RHandPosition, ARAVRInput.RHandDirection);
                RaycastHit hitInfo = new RaycastHit();

                // 2. 마우스의 위치가 바닥 위에 위치해 있다면
                if (Physics.Raycast(ray, out hitInfo))
                {
                    // 복셀 오브젝트 풀 이용하기
                    // 1. 만약 오브젝트 풀에 복셀이 있다면
                    if (voxelPool.Count > 0)
                    {
                        // 복셀을 생성했을 때만 경과 시간을 초기화해준다.
                        currentTime = 0;
                        // 2. 오브젝트 풀에서 복셀을 하나 가져온다.
                        GameObject voxel = voxelPool[0];
                        // 3. 복셀을 활성화한다.
                        voxel.SetActive(true);
                        // 4. 복셀을 배치하고 싶다.
                        voxel.transform.position = hitInfo.point;
                        // 5. 오브젝트 풀에서 복셀을 제거한다.
                        voxelPool.RemoveAt(0);
                    }
                }
            }
        }
    }
}

*/