using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class ArduinoManager : MonoBehaviour
{
    public VelocityTracker velocityScript;
    public TextUpdate TextUpdateScript;
    public int vibe=0;

    //�ø��� ��Ʈ
    SerialPort serialVibe;
    SerialPort serialImpact;

    // Start is called before the first frame update
    void Start()
    {
        serialVibe = new SerialPort("COM6", 9600);
        serialImpact = new SerialPort("COM8", 9600);
        serialVibe.Open();
        serialImpact.Open();


        if (serialVibe.IsOpen)
        {
            Debug.Log("serialVibe Open");
        }

        if (serialImpact.IsOpen)
        {
            Debug.Log("serialImpact Open");
        }
    }

    void OnDestroy()
    {
        serialVibe.Close();
        serialImpact.Close();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Alpha1))
        {
            Debug.Log("Send 1key");
            //�Ƶ��̳����� 1�� ������.
            //Debug.Log(velocityScript.sendVelocity());

            serialVibe.Write("1 85\n");
            serialImpact.Write("2 5\n");
        }
        if (Input.GetKey(KeyCode.Alpha2))
        {
            Debug.Log("Send 2key");
            //�Ƶ��̳����� 2�� ������.
            serialVibe.Write("2 5\n");
            serialImpact.Write("1 85\n");
        }
    }

    public void TriggerWall()
    {
        Debug.Log("Velocity PunchWallTrigger");

        Vector3 velocity = velocityScript.sendVelocity();
        float speed = Mathf.Sqrt(velocity.x * velocity.x + velocity.y * velocity.y + velocity.z * velocity.z);
        Debug.Log("Vector3 : " + velocity + " Velocity Speed: " + speed);

    }

    public void Punch()
    {
        Debug.Log("Punch!");

        //������
        if (TextUpdateScript.currentIndex == 6)
        {
            Debug.Log("Index6!");
            serialVibe.Write("1 85\n"); // ���� ��ȣ ������
        }
        if (TextUpdateScript.currentIndex == 7)
        {
            Debug.Log("Index7!");
            serialVibe.Write("1 85\n"); // ���� ��ȣ ������
        }
        if (TextUpdateScript.currentIndex == 23)
        {
            Debug.Log("Index23!");
            serialVibe.Write("1 85\n"); // ���� ��ȣ ������
        }
        if (TextUpdateScript.currentIndex == 24)
        {
            Debug.Log("Index24!");
            serialVibe.Write("1 85\n"); // ���� ��ȣ ������
        }

        // ����Ʈ��
        if (TextUpdateScript.currentIndex == 13 || TextUpdateScript.currentIndex == 14 || TextUpdateScript.currentIndex == 16 || TextUpdateScript.currentIndex == 17)
        {
            Debug.Log("Impact!");
            serialImpact.Write("1 85\n");
        }

    }

}
