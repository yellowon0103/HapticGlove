using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextUpdate : MonoBehaviour
{
    public ArduinoManager ArduinoManagerScript;
    //public CubeCollision CubeCollisionScript;

    public TextMeshProUGUI ScriptText;
    private string[] textArray = {
        "Trigger ��ư�� ���� �������� �Ѿ����.",

        "Mode 0. Punch �ùķ��̼�", // 1
        "���� ��� ���� ���� �ָ��� ��������.\n�ָ��� ���� �ε����� ���� ���������� ���մϴ�.",
        "# Test the Punch\n���ݺ��� �ȳ��� #�� ���� ���� ���� �ε�������.\n����� �׽�Ʈ�ߴٸ� Trigger ��ư�� ���� ��� �����մϴ�.", // 3 


        "Mode 1. Vibration", // 4
        "�� ���迡���� �ָ��� ���� �ε����� ������ �߻��մϴ�.\n�����ʿ� �������� �ָ� �̵� ���̵带 ���� ���� �ӵ��� ���� ġ����.", // 5
        "# A ����\n��� ���� ���� �ָ��� ��������.", // 6 Go -- A
        "# B ����\n��� ���� ���� �ָ��� ��������.", // 7 Go -- B
        "# Trial 1\n��� ���� ���� �ָ��� ��������.\nA�� B �� � �����Դϱ�?\n\n1. �󸶳� ��������� �������ϱ�? 1 ~ 5?\n2. �󸶳� ���������� �������ϱ�? 1 ~ 5?\n\n1 �ſ� �ƴϴ� ~ 5 �ſ� �׷���", // A 8
        "# Trial 2\n��� ���� ���� �ָ��� ��������.\nA�� B �� � �����Դϱ�?\n\n1. �󸶳� ��������� �������ϱ�? 1 ~ 5?\n2. �󸶳� ���������� �������ϱ�? 1 ~ 5?\n\n1 �ſ� �ƴϴ� ~ 5 �ſ� �׷���", // B 9 
        "# Trial 3\n��� ���� ���� �ָ��� ��������.\nA�� B �� � �����Դϱ�?\n\n1. �󸶳� ��������� �������ϱ�? 1 ~ 5?\n2. �󸶳� ���������� �������ϱ�? 1 ~ 5?\n\n1 �ſ� �ƴϴ� ~ 5 �ſ� �׷���", // A 10 
        "# Trial 4\n��� ���� ���� �ָ��� ��������.\nA�� B �� � �����Դϱ�?\n\n1. �󸶳� ��������� �������ϱ�? 1 ~ 5?\n2. �󸶳� ���������� �������ϱ�? 1 ~ 5?\n\n1 �ſ� �ƴϴ� ~ 5 �ſ� �׷���", // B 11


        "Mode 2. Impact", // 12
        "�� ���迡���� �ָ��� ���� �󸶳� ���� �ε��������� ���� �浹�� ���� �޶����ϴ�.\n�����ʿ� �������� �ָ� �̵� ���̵带 ���� ���� �ӵ��� ���� ġ����.", // 13
        "# C ����Ʈ\n��� ���� ���� �ָ��� ��������.", // 14 Go -- C
        "# D ����Ʈ\n��� ���� ���� �ָ��� ��������.", // 15 Go -- D
        "# Trial 1\n��� ���� ���� �ָ��� ��������.\nC�� D �� � ����Ʈ�Դϱ�?\n\n1. �󸶳� ��������� �������ϱ�? 1 ~ 5?\n2. �󸶳� ���������� �������ϱ�? 1 ~ 5?\n\n1 �ſ� �ƴϴ� ~ 5 �ſ� �׷���", // 16 Go -- C
        "# Trial 2\n��� ���� ���� �ָ��� ��������.\nC�� D �� � ����Ʈ�Դϱ�?\n\n1. �󸶳� ��������� �������ϱ�? 1 ~ 5?\n2. �󸶳� ���������� �������ϱ�? 1 ~ 5?\n\n1 �ſ� �ƴϴ� ~ 5 �ſ� �׷���", // 17 D
        "# Trial 3\n��� ���� ���� �ָ��� ��������.\nC�� D �� � ����Ʈ�Դϱ�?\n\n1. �󸶳� ��������� �������ϱ�? 1 ~ 5?\n2. �󸶳� ���������� �������ϱ�? 1 ~ 5?\n\n1 �ſ� �ƴϴ� ~ 5 �ſ� �׷���", // 18 C
        "# Trial 4\n��� ���� ���� �ָ��� ��������.\nC�� D �� � ����Ʈ�Դϱ�?\n\n1. �󸶳� ��������� �������ϱ�? 1 ~ 5?\n2. �󸶳� ���������� �������ϱ�? 1 ~ 5?\n\n1 �ſ� �ƴϴ� ~ 5 �ſ� �׷���", // 19 D


        "Mode 3. Vibration & Impact", // 20
        "�� ���迡���� �ָ��� ���� �ε��� �� ������ ����� ��� �������ϴ�.\n�����ʿ� �������� �ָ� �̵� ���̵带 ���� ���� �ӵ��� ���� ġ����.", // 21
        "# E ����\n��� ���� ���� �ָ��� ��������.", // 22 Go -- E
        "# F ����\n��� ���� ���� �ָ��� ��������.", // 23 Go -- F
        "# Trial 1\n��� ���� ���� �ָ��� ��������.\nE�� F �� � �����Դϱ�?\n\n1. �󸶳� ��������� �������ϱ�? 1 ~ 5?\n2. �󸶳� ���������� �������ϱ�? 1 ~ 5?\n\n1 �ſ� �ƴϴ� ~ 5 �ſ� �׷���", // 24 E
        "# Trial 2\n��� ���� ���� �ָ��� ��������.\nE�� F �� � �����Դϱ�?\n\n1. �󸶳� ��������� �������ϱ�? 1 ~ 5?\n2. �󸶳� ���������� �������ϱ�? 1 ~ 5?\n\n1 �ſ� �ƴϴ� ~ 5 �ſ� �׷���", // 25 F
        "# Trial 3\n��� ���� ���� �ָ��� ��������.\nE�� F �� � �����Դϱ�?\n\n1. �󸶳� ��������� �������ϱ�? 1 ~ 5?\n2. �󸶳� ���������� �������ϱ�? 1 ~ 5?\n\n1 �ſ� �ƴϴ� ~ 5 �ſ� �׷���", // 26 E
        "# Trial 4\n��� ���� ���� �ָ��� ��������.\nE�� F �� � �����Դϱ�?\n\n1. �󸶳� ��������� �������ϱ�? 1 ~ 5?\n2. �󸶳� ���������� �������ϱ�? 1 ~ 5?\n\n1 �ſ� �ƴϴ� ~ 5 �ſ� �׷���", // 27 F

        "������ ����Ǿ����ϴ�.\n�����մϴ�." // 28
    };

    public int currentIndex = -1;

    // Start is called before the first frame update
    void Start()
    {
        ScriptText.text = "Feeling the Hit:\nHaptic Impact for\nRealistic Virtual Punch";
        
    }

    public void Plus()
    {
        currentIndex++;

        if (currentIndex >= textArray.Length)
        {
            currentIndex = textArray.Length - 1;
        }

        ScriptText.text = textArray[currentIndex];

        /*
        if(currentIndex == 3)
        {
            //Debug.Log("Index3");
            //CubeCollisionScript.OnTriggerEnter
            ArduinoManagerScript.OnlyVibration();
        }

        if (currentIndex == 6)
        {

        }

        if (currentIndex == 13)
        {

        }

        if (currentIndex == 23)
        {

        }
        */
    }

    public void Minus()
    {
        currentIndex--;

        if (currentIndex < 0)
        {
            currentIndex = -1;
        }

        if (currentIndex >= 0)
        {
            ScriptText.text = textArray[currentIndex];
        }
    }
}


/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextUpdate : MonoBehaviour
{
    public TextMeshProUGUI ScriptText;

    // Start is called before the first frame update
    void Start()
    {
        ScriptText.text = "0";
    }

    public void Plus()
    {
        int number = int.Parse(ScriptText.text) + 1;
        ScriptText.text = number.ToString();
    }
}
*/