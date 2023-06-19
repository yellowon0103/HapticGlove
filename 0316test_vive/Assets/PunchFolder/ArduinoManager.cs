using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class ArduinoManager : MonoBehaviour
{
    public VelocityTracker velocityScript;

    //�ø��� ��Ʈ
    SerialPort serial;

    // Start is called before the first frame update
    void Start()
    {
        serial = new SerialPort("COM6", 9600);
        serial.Open();
        if (serial.IsOpen)
        {
            Debug.Log("Serial Open");
        }
    }

    void OnDestroy()
    {
        serial.Close();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Alpha1))
        {
            Debug.Log("Send 1 85\n");
            //�Ƶ��̳����� 1�� ������.
            //Debug.Log(velocityScript.sendVelocity());

            serial.Write("1 85\n");
        }
        if (Input.GetKey(KeyCode.Alpha2))
        {
            Debug.Log("Send 2 5");
            //�Ƶ��̳����� 2�� ������.
            serial.Write("2 5\n");
        }
    }

    public void TriggerWall()
    {
        Debug.Log("Velocity PunchWallTrigger");

        Vector3 velocity = velocityScript.sendVelocity();
        float speed = Mathf.Sqrt(velocity.x * velocity.x + velocity.y * velocity.y + velocity.z * velocity.z);
        Debug.Log("Vector3 : " + velocity + " Velocity Speed: " + speed);

        serial.Write("1 85\n");
    }
}
