using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class ArduinoManager : MonoBehaviour
{
    //시리얼 포트
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
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Debug.Log("Send one");
            //아두이노한테 1을 보낸다.
            serial.Write("1");
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Debug.Log("Send two");
            //아두이노한테 2을 보낸다.
            serial.Write("2");
        }
    }
}
