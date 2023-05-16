
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// ����ڰ� ���콺�� Ŭ���� ������ ������ 1�� ����� �ʹ�.
// �ʿ� �Ӽ�: ���� ����

public class VoxelMaker : MonoBehaviour
{

    // �߰�
    Vector3 originScale = Vector3.one * 0.005f;
    // �߰�

    // ���� ����
    public GameObject voxelFactory;
    // ������Ʈ Ǯ�� ũ��
    public int voxelPoolSize = 20;
    // ������Ʈ Ǯ
    public static List<GameObject> voxelPool = new List<GameObject>();
    // ���� �ð�
    public float createTime = 0.1f;
    // ��� �ð�
    float currentTime = 0;
    // ũ�ν���� ����
    public Transform crosshair;

    // �߰� LineRenderer
    public LineRenderer lineRenderer;
    // �߰�

    void Start()
    {
        // ������Ʈ Ǯ�� ��Ȱ��ȭ�� ������ ��� �ʹ�.
        for (int i = 0; i < voxelPoolSize; i++)
        {
            // 1. ���� ���忡�� ���� �����ϱ�
            GameObject voxel = Instantiate(voxelFactory);
            // 2. ���� ��Ȱ��ȭ�ϱ�
            voxel.SetActive(false);
            // 3. ������ ������Ʈ Ǯ�� ��� �ʹ�.
            voxelPool.Add(voxel);
        }

        // �߰�
        lineRenderer.positionCount = 2;
        lineRenderer.startWidth = 0.02f;
        lineRenderer.endWidth = 0.02f;
        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
        // �߰�
    }

    void Update()
    {
        // ũ�ν���� �׸���
        ARAVRInput.DrawCrosshair(crosshair);

        // 1) VR ��Ʈ�ѷ��� �߻� ��ư�� ������
        if (ARAVRInput.Get(ARAVRInput.Button.One))
        {
            // ���� �ð����� ������ ����� �ʹ�.
            // 1. ��� �ð��� �帥��.
            currentTime += Time.deltaTime;

            // 2. ��� �ð��� ���� �ð��� �ʰ��ߴٸ�
            if (currentTime > createTime)
            {
                // Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                // 2) ��Ʈ�ѷ��� ���ϴ� �������� �ü� �����
                Ray ray = new Ray(ARAVRInput.LHandPosition, ARAVRInput.LHandDirection);
                RaycastHit hitInfo = new RaycastHit();

                // 2. ���콺�� ��ġ�� �ٴ� ���� ��ġ�� �ִٸ�
                if (Physics.Raycast(ray, out hitInfo))
                {
                    // ���� ������Ʈ Ǯ �̿��ϱ�
                    // 1. ���� ������Ʈ Ǯ�� ������ �ִٸ�
                    if (voxelPool.Count > 0)
                    {
                        // ������ �������� ���� ��� �ð��� �ʱ�ȭ���ش�.
                        currentTime = 0;
                        // 2. ������Ʈ Ǯ���� ������ �ϳ� �����´�.
                        GameObject voxel = voxelPool[0];
                        // 3. ������ Ȱ��ȭ�Ѵ�.
                        voxel.SetActive(true);
                        // 4. ������ ��ġ�ϰ� �ʹ�.
                        voxel.transform.position = hitInfo.point;
                        // 5. ������Ʈ Ǯ���� ������ �����Ѵ�.
                        voxelPool.RemoveAt(0);
                    }

                    //�߰�
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

                    //�߰�


                }
            }
        }
        //
        // ������ ��ü�� ������ ����
        GameObject selectedObject = null;
        Vector3 distanceToSelectedObject = Vector3.zero; // �߰�: ��Ʈ�ѷ��� ������ ��ü ������ �Ÿ�
        Rigidbody selectedObjectRigidbody = null; // �߰�: ���õ� ��ü�� Rigidbody ������Ʈ

        // 1) VR ��Ʈ�ѷ��� Ʈ���е� ��ư�� ������
        if (ARAVRInput.Get(ARAVRInput.Button.Two))
        {
            // ��Ʈ�ѷ� Ray ����
            Ray ray = new Ray(ARAVRInput.LHandPosition, ARAVRInput.LHandDirection);
            RaycastHit hitInfo;
            // 2. ���콺�� ��ġ�� �ٴ� ���� ��ġ�� �ִٸ�
            if (Physics.Raycast(ray, out hitInfo))
            {
                // �浹�� ��ü�� Collider ��������
                Collider collider = hitInfo.collider;

                // �ٴ� ���� ��ü�� �浹���� ���
                if (collider.CompareTag("FloorObject"))
                {
                    // ��Ʈ�ѷ��� ������ ��ü�� �����̱� ���� ����
                    selectedObject = collider.gameObject;

                    // �߰�: ��Ʈ�ѷ��� ������ ��ü ������ �Ÿ� ���
                    distanceToSelectedObject = selectedObject.transform.position - ARAVRInput.LHandPosition;

                    // Rigidbody ������Ʈ ��������
                    selectedObjectRigidbody = selectedObject.GetComponent<Rigidbody>();

                    // Rigidbody�� ���ٸ� �߰�
                    if (selectedObjectRigidbody == null)
                    {
                        selectedObjectRigidbody = selectedObject.AddComponent<Rigidbody>();
                    }

                    // ���� ������ �޵��� ����
                    selectedObjectRigidbody.isKinematic = false;

                }
            }
        }
        // 2) VR ��Ʈ�ѷ��� �߻� ��ư�� ������
        if (ARAVRInput.GetUp(ARAVRInput.Button.Two))
        {
            // ������ ��ü ����
            selectedObject = null;
        }

        // ������ ��ü�� ���� ���, ��Ʈ�ѷ��� ��ġ�� �������� ��ü �̵�
        if (selectedObject != null)
        {
            // �Ÿ��� �����ϸ鼭 ��ü �̵�
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
// ����ڰ� ���콺�� Ŭ���� ������ ������ 1�� ����� �ʹ�.
// �ʿ� �Ӽ�: ���� ����
public class VoxelMaker : MonoBehaviour
{
    // ���� ����
    public GameObject voxelFactory;
    // ������Ʈ Ǯ�� ũ��
    public int voxelPoolSize = 20;
    // ������Ʈ Ǯ
    public static List<GameObject> voxelPool = new List<GameObject>();
    // ���� �ð�
    public float createTime = 0.1f;
    // ��� �ð�
    float currentTime = 0;
    // ũ�ν���� ����
    public Transform crosshair;

    void Start()
    {
        // ������Ʈ Ǯ�� ��Ȱ��ȭ�� ������ ��� �ʹ�.
        for (int i = 0; i < voxelPoolSize; i++)
        {
            // 1. ���� ���忡�� ���� �����ϱ�
            GameObject voxel = Instantiate(voxelFactory);
            // 2. ���� ��Ȱ��ȭ�ϱ�
            voxel.SetActive(false);
            // 3. ������ ������Ʈ Ǯ�� ��� �ʹ�.
            voxelPool.Add(voxel);
        }
    }

    void Update()
    {
        // ũ�ν���� �׸���
        ARAVRInput.DrawCrosshair(crosshair);

        // 1) VR ��Ʈ�ѷ��� �߻� ��ư�� ������
        if (ARAVRInput.Get(ARAVRInput.Button.One))
        {
            // ���� �ð����� ������ ����� �ʹ�.
            // 1. ��� �ð��� �帥��.
            currentTime += Time.deltaTime;

            // 2. ��� �ð��� ���� �ð��� �ʰ��ߴٸ�
            if (currentTime > createTime)
            {
                // Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                // 2) ��Ʈ�ѷ��� ���ϴ� �������� �ü� �����
                Ray ray = new Ray(ARAVRInput.RHandPosition, ARAVRInput.RHandDirection);
                RaycastHit hitInfo = new RaycastHit();

                // 2. ���콺�� ��ġ�� �ٴ� ���� ��ġ�� �ִٸ�
                if (Physics.Raycast(ray, out hitInfo))
                {
                    // ���� ������Ʈ Ǯ �̿��ϱ�
                    // 1. ���� ������Ʈ Ǯ�� ������ �ִٸ�
                    if (voxelPool.Count > 0)
                    {
                        // ������ �������� ���� ��� �ð��� �ʱ�ȭ���ش�.
                        currentTime = 0;
                        // 2. ������Ʈ Ǯ���� ������ �ϳ� �����´�.
                        GameObject voxel = voxelPool[0];
                        // 3. ������ Ȱ��ȭ�Ѵ�.
                        voxel.SetActive(true);
                        // 4. ������ ��ġ�ϰ� �ʹ�.
                        voxel.transform.position = hitInfo.point;
                        // 5. ������Ʈ Ǯ���� ������ �����Ѵ�.
                        voxelPool.RemoveAt(0);
                    }
                }
            }
        }
    }
}

*/