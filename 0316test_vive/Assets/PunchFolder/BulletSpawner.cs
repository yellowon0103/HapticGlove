using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject bulletPrefabSlow; // ������ �Ѿ��� ���� ������
    public GameObject bulletPrefabFast;
    //public float spawnRateMin = 0.5f; // �ּ� ���� �ֱ�
    //public float spawnRateMax = 3f; // �ִ� ���� �ֱ�

    public TextUpdate TextUpdateScript;


    private Transform target; // �߻��� ���
    private float spawnRate; // ���� �ֱ�
    private float timeAfterSpawn; // �ֱ� ���� �������� ���� �ð�

    public GameObject PunchWall; // ��ġ �� ����

    void Start()
    {
        // �ֱ� ���� ������ ���� �ð��� 0���� �ʱ�ȭ
        timeAfterSpawn = 0f;
        // �Ѿ� ���� ������ spawnRateMin�� spawnRateMax ���̿��� ���� ���� 
        spawnRate = 0.5f;//Random.Range(spawnRateMin, spawnRateMax);
        // PlayerController ������Ʈ�� ���� ���� ������Ʈ�� ã�� ���� ������� ����
        target = PunchWall.transform;
    }

    void Update()
    {
        // timeAfterSpawn�� ����
        timeAfterSpawn += Time.deltaTime;

        // �ֱ� ���� ������������ ������ �ð���, ���� �ֱ⺸�� ũ�ų� ���ٸ�
        if (timeAfterSpawn >= spawnRate)
        {
            // ������ �ð��� ����
            timeAfterSpawn = 0f;

            // bulletPrefab�� ��������
            // transform.position ��ġ�� transform.rotation ȸ������ ����
            GameObject bulletSlow
                = Instantiate(bulletPrefabSlow, transform.position, transform.rotation);
            // ������ bullet ���� ������Ʈ�� ���� ������ target�� ���ϵ��� ȸ��
            bulletSlow.transform.LookAt(target);

            // bulletPrefab�� ��������
            // transform.position ��ġ�� transform.rotation ȸ������ ����
            GameObject bulletFast
                = Instantiate(bulletPrefabFast, transform.position, transform.rotation);
            // ������ bullet ���� ������Ʈ�� ���� ������ target�� ���ϵ��� ȸ��
            bulletFast.transform.LookAt(target);

            if (TextUpdateScript.currentIndex == 6 || TextUpdateScript.currentIndex == 8 || TextUpdateScript.currentIndex == 10 || TextUpdateScript.currentIndex == 14 || TextUpdateScript.currentIndex == 16 || TextUpdateScript.currentIndex == 18 || TextUpdateScript.currentIndex == 22 | TextUpdateScript.currentIndex == 24 || TextUpdateScript.currentIndex == 26) // slow
            {
                /*
                // bulletPrefab�� ��������
                // transform.position ��ġ�� transform.rotation ȸ������ ����
                GameObject bulletSlow
                    = Instantiate(bulletPrefabSlow, transform.position, transform.rotation);
                // ������ bullet ���� ������Ʈ�� ���� ������ target�� ���ϵ��� ȸ��
                bulletSlow.transform.LookAt(target);
                */
                Destroy(bulletFast);
            }

            else if (TextUpdateScript.currentIndex == 7 || TextUpdateScript.currentIndex == 9 || TextUpdateScript.currentIndex == 11 || TextUpdateScript.currentIndex == 15 || TextUpdateScript.currentIndex == 17 || TextUpdateScript.currentIndex == 19 || TextUpdateScript.currentIndex == 23 || TextUpdateScript.currentIndex == 25 || TextUpdateScript.currentIndex == 27) // fast
            {
                /*
                // bulletPrefab�� ��������
                // transform.position ��ġ�� transform.rotation ȸ������ ����
                GameObject bulletFast
                    = Instantiate(bulletPrefabFast, transform.position, transform.rotation);
                // ������ bullet ���� ������Ʈ�� ���� ������ target�� ���ϵ��� ȸ��
                bulletFast.transform.LookAt(target);
                */
                Destroy(bulletSlow);
            }

            else
            {
                Destroy(bulletFast);
                Destroy(bulletSlow);
            }

            // ������ ���� ������ spawnRateMin, spawnRateMax ���̿��� ���� ����
            //spawnRate = Random.Range(spawnRateMin, spawnRateMax);
            spawnRate = 0.5f;
        }
    }
}