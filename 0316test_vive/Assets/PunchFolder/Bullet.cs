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
        Destroy(gameObject, 5f);
    }

    void Update()
    {

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
