using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class ArduinoManager : MonoBehaviour
{
    public VelocityTracker velocityScript;
    public TextUpdate TextUpdateScript;

    public CubeCollision CubeCollisionImpact;
    public CubeCollision CubeCollisionVibration;

    //�ø��� ��Ʈ
    public SerialPort serialVibe;
    public SerialPort serialImpact;

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
        if (Input.GetKey(KeyCode.Alpha1)) // ���Ż��
        {
            //Debug.Log("Send 1key");
            //�Ƶ��̳����� 1�� ������.
            //Debug.Log(velocityScript.sendVelocity());

            //serialVibe.Write("1 85\n");
            serialImpact.Write("0\n");
        }
        if (Input.GetKey(KeyCode.Alpha2)) // ���� �� �ٽ� �����
        {
            //Debug.Log("Send 2key");
            CubeCollisionImpact.transparentPunchWallImpact.SetActive(true);
            CubeCollisionVibration.transparentPunchWallVibration.SetActive(true);
        }


        if (Input.GetKey(KeyCode.Alpha3)) // �׽�Ʈ
        {
            Debug.Log("1 75");
            serialImpact.Write("1 75\n");
        }
    }

    public void TriggerWall()
    {
        Debug.Log("Velocity PunchWallTrigger");

        Vector3 velocity = velocityScript.sendVelocity();
        float speed = Mathf.Sqrt(velocity.x * velocity.x + velocity.y * velocity.y + velocity.z * velocity.z);
        Debug.Log("Vector3 : " + velocity + " Velocity Speed: " + speed);

    }

    public void Punch(int i)
    {
        Vector3 velocity = velocityScript.sendVelocity();
        float speed = Mathf.Sqrt(velocity.x * velocity.x + velocity.y * velocity.y + velocity.z * velocity.z); // �ӵ�
        string ArduinoSpeed = "";

        if (speed <= 0.55) // 22�� ����
        {
            ArduinoSpeed = "0";
        }
        else if (speed > 0.55 && speed <1.15) // 22�� �ʰ� 46�� �̸�
        {
            ArduinoSpeed = "46";
        }
        else if (speed >= 1.15 && speed <= 2.5) // 46�� �̻� 100�� ����
        {
            ArduinoSpeed = (speed / 2.5 * 100).ToString();
            ArduinoSpeed = ArduinoSpeed.Substring(0, 2);
        }
        else // 100�� �̻�
        {
            ArduinoSpeed = "100";
        }


        Debug.Log("Punch!" + i);

        if (i == 2) // ����
        {
            Debug.Log("2 vibe");

            //���� A��
            if (TextUpdateScript.currentIndex == 6 || TextUpdateScript.currentIndex == 10 || TextUpdateScript.currentIndex == 12 || TextUpdateScript.currentIndex == 28 || TextUpdateScript.currentIndex == 30 || TextUpdateScript.currentIndex == 31 || TextUpdateScript.currentIndex == 33)
            {
                //Debug.Log("Vibe A!" + ArduinoSpeed);
                //Debug.Log("Debug");
                serialVibe.Write("1\n"); // ���� ��ȣ ������
            }
            //���� B��
            if (TextUpdateScript.currentIndex == 7 || TextUpdateScript.currentIndex == 8 || TextUpdateScript.currentIndex == 9 || TextUpdateScript.currentIndex == 11 || TextUpdateScript.currentIndex == 29 || TextUpdateScript.currentIndex == 32 || TextUpdateScript.currentIndex == 34)
            {
                //Debug.Log("Vibe B!" + ArduinoSpeed);
                serialVibe.Write("2\n"); // ���� ��ȣ ������
            }
        }

        if (i == 1) // ����Ʈ
        {
            Debug.Log("1 impact");
            // ����Ʈ C��
            if (TextUpdateScript.currentIndex == 17 || TextUpdateScript.currentIndex == 19 || TextUpdateScript.currentIndex == 21 || TextUpdateScript.currentIndex == 22 || TextUpdateScript.currentIndex == 28 || TextUpdateScript.currentIndex == 30 || TextUpdateScript.currentIndex == 31 || TextUpdateScript.currentIndex == 33)
            {
                //Debug.Log("Impact C! " + ArduinoSpeed);
                serialImpact.Write("1 " + ArduinoSpeed + "\n");

                Debug.Log("1 " + ArduinoSpeed + "\n");
            }
            // ����Ʈ D��
            if (TextUpdateScript.currentIndex == 18 || TextUpdateScript.currentIndex == 20 || TextUpdateScript.currentIndex == 23 || TextUpdateScript.currentIndex == 29 || TextUpdateScript.currentIndex == 32 || TextUpdateScript.currentIndex == 34)
            {
                //Debug.Log("Impact D! " + ArduinoSpeed);
                serialImpact.Write("2 " + ArduinoSpeed + "\n");
            }
        }

       // CubeCollisionImpact.transparentPunchWallImpact.SetActive(false);
       // CubeCollisionVibration.transparentPunchWallVibration.SetActive(false);

        /*
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
        */
    }

}
