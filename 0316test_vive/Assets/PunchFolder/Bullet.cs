using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float speed = 1.25f; // 총알 이동 속력
    private Rigidbody bulletRigidbody; // 이동에 사용할 리지드바디 컴포넌트

    public TextUpdate TextUpdateScript;

    void Start()
    {
        // 게임 오브젝트에서 Rigidbody 컴포넌트를 찾아 bulletRigidbody에 할당
        bulletRigidbody = GetComponent<Rigidbody>();
        // 리지드바디의 속도 = 앞쪽 방향 * 이동 속력
        bulletRigidbody.velocity = transform.forward * speed;

        GameObject textUpdateObject = GameObject.FindGameObjectWithTag("TextUpdate");
        TextUpdateScript = textUpdateObject.GetComponent<TextUpdate>();

        //Debug.Log("Bullet velocity" + bulletRigidbody.velocity);

        // 5초 뒤에 자신의 게임 오브젝트 파괴
        //Destroy(gameObject, 5f);
    }

    void Update()
    {
        //진동 A만
        if (TextUpdateScript.currentIndex == 6 || TextUpdateScript.currentIndex == 10 || TextUpdateScript.currentIndex == 12)
        {
            speed = 0.5f;
        }
        //진동 B만
        if (TextUpdateScript.currentIndex == 7 || TextUpdateScript.currentIndex == 8 || TextUpdateScript.currentIndex == 9 || TextUpdateScript.currentIndex == 11)
        {
            speed = 2.5f;
        }


        // 임팩트 C만
        if (TextUpdateScript.currentIndex == 17 || TextUpdateScript.currentIndex == 19 || TextUpdateScript.currentIndex == 21 || TextUpdateScript.currentIndex == 22)
        {
            speed = 0.5f;
        }
        // 임팩트 D만
        if (TextUpdateScript.currentIndex == 18 || TextUpdateScript.currentIndex == 20 || TextUpdateScript.currentIndex == 23)
        {
            speed = 2.5f;
        }


        // 진동과 임팩트 E
        if (TextUpdateScript.currentIndex == 28 || TextUpdateScript.currentIndex == 30 || TextUpdateScript.currentIndex == 31 || TextUpdateScript.currentIndex == 33)
        {
            speed = 0.5f;
        }
        // 진동과 임팩트 F
        if (TextUpdateScript.currentIndex == 29 || TextUpdateScript.currentIndex == 32 || TextUpdateScript.currentIndex == 34)
        {
            speed = 2.5f;
        }

    }

    
    // 트리거 충돌 시 자동으로 실행되는 메서드
    void OnTriggerEnter(Collider other)
    {
        // 충돌한 상대방 게임 오브젝트가 Player 태그를 가진 경우
        if (other.tag == "PunchWall")
        {
            //Debug.Log("Punch!");
            Destroy(gameObject);
        }
    }
    
}
