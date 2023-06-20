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
        serialVibe = new SerialPort("COM15", 9600);
        serialImpact = new SerialPort("COM4", 115200);
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
        Vector3 velocity = velocityScript.sendVelocity();
        float speed = Mathf.Sqrt(velocity.x * velocity.x + velocity.y * velocity.y + velocity.z * velocity.z); // �ӵ�
        string ArduinoSpeed = "";

        if (speed <= 0.375) // 15�� ����
        {
            ArduinoSpeed = "0";
        }
        else if (speed > 0.375 && speed <0.75) // 15�� �ʰ� 30�� �̸�
        {
            ArduinoSpeed = "30";
        }
        else if (speed >= 0.75 && speed <= 2.5) // 30�� �̻� 100�� ����
        {
            ArduinoSpeed = (speed / 2.5 * 100).ToString();
            ArduinoSpeed = ArduinoSpeed.Substring(0, 2);
        }
        else // 100�� �̻�
        {
            ArduinoSpeed = "100";
        }


        Debug.Log("Punch!");

        //���� A��
        if (TextUpdateScript.currentIndex == 6 || TextUpdateScript.currentIndex == 10 || TextUpdateScript.currentIndex == 12)
        {
            Debug.Log("Vibe A!" + ArduinoSpeed);
            serialVibe.Write("1\n"); // ���� ��ȣ ������
        }
        //���� B��
        if (TextUpdateScript.currentIndex == 7 || TextUpdateScript.currentIndex == 8 || TextUpdateScript.currentIndex == 9 || TextUpdateScript.currentIndex == 11)
        {
            Debug.Log("Vibe B!" + ArduinoSpeed);
            serialVibe.Write("2\n"); // ���� ��ȣ ������
        }


        // ����Ʈ C��
        if (TextUpdateScript.currentIndex == 17 || TextUpdateScript.currentIndex == 19 || TextUpdateScript.currentIndex == 21 || TextUpdateScript.currentIndex == 22)
        {
            Debug.Log("Impact C! " + ArduinoSpeed);
            serialImpact.Write("1 " + ArduinoSpeed + "\n");
        }
        // ����Ʈ D��
        if (TextUpdateScript.currentIndex == 18 || TextUpdateScript.currentIndex == 20 || TextUpdateScript.currentIndex == 23)
        {
            Debug.Log("Impact D! " + ArduinoSpeed);
            serialImpact.Write("2 " + ArduinoSpeed + "\n");
        }


        // ������ ����Ʈ E
        if (TextUpdateScript.currentIndex == 28 || TextUpdateScript.currentIndex == 30 || TextUpdateScript.currentIndex == 31 || TextUpdateScript.currentIndex == 33)
        {
            Debug.Log("Both E! " + ArduinoSpeed);
            serialVibe.Write("1\n"); 
            serialImpact.Write("1 " + ArduinoSpeed + "\n");
        }
        // ������ ����Ʈ F
        if (TextUpdateScript.currentIndex == 29 || TextUpdateScript.currentIndex == 32 || TextUpdateScript.currentIndex == 34)
        {
            Debug.Log("Both F! " + ArduinoSpeed);
            serialVibe.Write("2\n");
            serialImpact.Write("2 " + ArduinoSpeed + "\n");
        }

    }

}
