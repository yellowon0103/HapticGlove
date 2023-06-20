using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject bulletPrefabSlow; // 생성할 총알의 원본 프리팹
    public GameObject bulletPrefabFast;
    //public float spawnRateMin = 0.5f; // 최소 생성 주기
    //public float spawnRateMax = 3f; // 최대 생성 주기

    public TextUpdate TextUpdateScript;


    private Transform target; // 발사할 대상
    private float spawnRate; // 생성 주기
    private float timeAfterSpawn; // 최근 생성 시점에서 지난 시간

    public GameObject PunchWall; // 펀치 벽 설정

    void Start()
    {
        // 최근 생성 이후의 누적 시간을 0으로 초기화
        timeAfterSpawn = 0f;
        // 총알 생성 간격을 spawnRateMin과 spawnRateMax 사이에서 랜덤 지정 
        spawnRate = 0.5f;//Random.Range(spawnRateMin, spawnRateMax);
        // PlayerController 컴포넌트를 가진 게임 오브젝트를 찾아 조준 대상으로 설정
        target = PunchWall.transform;
    }

    void Update()
    {
        // timeAfterSpawn을 갱신
        timeAfterSpawn += Time.deltaTime;

        // 최근 생성 시점에서부터 누적된 시간이, 생성 주기보다 크거나 같다면
        if (timeAfterSpawn >= spawnRate)
        {
            // 누적된 시간을 리셋
            timeAfterSpawn = 0f;

            // bulletPrefab의 복제본을
            // transform.position 위치와 transform.rotation 회전으로 생성
            GameObject bulletSlow
                = Instantiate(bulletPrefabSlow, transform.position, transform.rotation);
            // 생성된 bullet 게임 오브젝트의 정면 방향이 target을 향하도록 회전
            bulletSlow.transform.LookAt(target);

            // bulletPrefab의 복제본을
            // transform.position 위치와 transform.rotation 회전으로 생성
            GameObject bulletFast
                = Instantiate(bulletPrefabFast, transform.position, transform.rotation);
            // 생성된 bullet 게임 오브젝트의 정면 방향이 target을 향하도록 회전
            bulletFast.transform.LookAt(target);

            if (TextUpdateScript.currentIndex == 6 || TextUpdateScript.currentIndex == 10 || TextUpdateScript.currentIndex == 12 || TextUpdateScript.currentIndex == 17 || TextUpdateScript.currentIndex == 19 || TextUpdateScript.currentIndex == 21 || TextUpdateScript.currentIndex == 22 | TextUpdateScript.currentIndex == 28 || TextUpdateScript.currentIndex == 30 || TextUpdateScript.currentIndex == 31 || TextUpdateScript.currentIndex == 33) // slow
            {
                /*
                // bulletPrefab의 복제본을
                // transform.position 위치와 transform.rotation 회전으로 생성
                GameObject bulletSlow
                    = Instantiate(bulletPrefabSlow, transform.position, transform.rotation);
                // 생성된 bullet 게임 오브젝트의 정면 방향이 target을 향하도록 회전
                bulletSlow.transform.LookAt(target);
                */
                Destroy(bulletFast);
            }

            else if (TextUpdateScript.currentIndex == 7 || TextUpdateScript.currentIndex == 8 || TextUpdateScript.currentIndex == 9 || TextUpdateScript.currentIndex == 11 || TextUpdateScript.currentIndex == 18 || TextUpdateScript.currentIndex == 20 || TextUpdateScript.currentIndex == 23 || TextUpdateScript.currentIndex == 29 || TextUpdateScript.currentIndex == 32 || TextUpdateScript.currentIndex == 34) // fast
            {
                /*
                // bulletPrefab의 복제본을
                // transform.position 위치와 transform.rotation 회전으로 생성
                GameObject bulletFast
                    = Instantiate(bulletPrefabFast, transform.position, transform.rotation);
                // 생성된 bullet 게임 오브젝트의 정면 방향이 target을 향하도록 회전
                bulletFast.transform.LookAt(target);
                */
                Destroy(bulletSlow);
            }

            else
            {
                Destroy(bulletFast);
                Destroy(bulletSlow);
            }

            // 다음번 생성 간격을 spawnRateMin, spawnRateMax 사이에서 랜덤 지정
            //spawnRate = Random.Range(spawnRateMin, spawnRateMax);
            spawnRate = 0.5f;
        }
    }
}