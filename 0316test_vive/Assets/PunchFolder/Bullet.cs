using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float speed = 1.25f; // �Ѿ� �̵� �ӷ�
    private Rigidbody bulletRigidbody; // �̵��� ����� ������ٵ� ������Ʈ

    public TextUpdate TextUpdateScript;

    void Start()
    {
        // ���� ������Ʈ���� Rigidbody ������Ʈ�� ã�� bulletRigidbody�� �Ҵ�
        bulletRigidbody = GetComponent<Rigidbody>();
        // ������ٵ��� �ӵ� = ���� ���� * �̵� �ӷ�
        bulletRigidbody.velocity = transform.forward * speed;

        GameObject textUpdateObject = GameObject.FindGameObjectWithTag("TextUpdate");
        TextUpdateScript = textUpdateObject.GetComponent<TextUpdate>();

        //Debug.Log("Bullet velocity" + bulletRigidbody.velocity);

        // 5�� �ڿ� �ڽ��� ���� ������Ʈ �ı�
        //Destroy(gameObject, 5f);
    }

    void Update()
    {
        //���� A��
        if (TextUpdateScript.currentIndex == 6 || TextUpdateScript.currentIndex == 10 || TextUpdateScript.currentIndex == 12)
        {
            speed = 0.5f;
        }
        //���� B��
        if (TextUpdateScript.currentIndex == 7 || TextUpdateScript.currentIndex == 8 || TextUpdateScript.currentIndex == 9 || TextUpdateScript.currentIndex == 11)
        {
            speed = 2.5f;
        }


        // ����Ʈ C��
        if (TextUpdateScript.currentIndex == 17 || TextUpdateScript.currentIndex == 19 || TextUpdateScript.currentIndex == 21 || TextUpdateScript.currentIndex == 22)
        {
            speed = 0.5f;
        }
        // ����Ʈ D��
        if (TextUpdateScript.currentIndex == 18 || TextUpdateScript.currentIndex == 20 || TextUpdateScript.currentIndex == 23)
        {
            speed = 2.5f;
        }


        // ������ ����Ʈ E
        if (TextUpdateScript.currentIndex == 28 || TextUpdateScript.currentIndex == 30 || TextUpdateScript.currentIndex == 31 || TextUpdateScript.currentIndex == 33)
        {
            speed = 0.5f;
        }
        // ������ ����Ʈ F
        if (TextUpdateScript.currentIndex == 29 || TextUpdateScript.currentIndex == 32 || TextUpdateScript.currentIndex == 34)
        {
            speed = 2.5f;
        }

    }

    
    // Ʈ���� �浹 �� �ڵ����� ����Ǵ� �޼���
    void OnTriggerEnter(Collider other)
    {
        // �浹�� ���� ���� ������Ʈ�� Player �±׸� ���� ���
        if (other.tag == "PunchWall")
        {
            //Debug.Log("Punch!");
            Destroy(gameObject);
        }
    }
    
}
