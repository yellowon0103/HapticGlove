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

    /*
    public void Angle(float angle)
    {
        if (angle > 1)
        {
            Debug.Log(angle);
            serial.Write(angle.ToString());
        }
    }
    */

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Alpha1))
        {
            Debug.Log("Send one");
            //�Ƶ��̳����� 1�� ������.
            //Debug.Log(velocityScript.sendVelocity());

            serial.Write("1");
        }
        if (Input.GetKey(KeyCode.Alpha2))
        {
            Debug.Log("Send two");
            //�Ƶ��̳����� 2�� ������.
            serial.Write("2");
        }
    }

    public void TriggerWall()
    {
        Debug.Log("Velocity PunchWallTrigger");
        
        Debug.Log(velocityScript.sendVelocity());

        serial.Write("1");
    }
}
