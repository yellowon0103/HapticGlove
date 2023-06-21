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
        "Trigger 버튼을 눌러 다음으로 넘어가세요.",

        "Mode 0. Punch 시뮬레이션", // 1
        "앞의 흰색 벽을 향해 주먹을 날리세요.\n주먹이 벽에 부딪히면 벽이 빨간색으로 변합니다.",
        "# Test the Punch\n지금부터 안내에 #이 나올 때만 벽과 부딪히세요.\n충분히 테스트했다면 Trigger 버튼을 눌러 계속 진행합니다.", // 3 


        "Mode 1. Vibration", // 4
        "이 실험에서는 주먹이 벽에 부딪히면 진동이 발생합니다.\n오른쪽에 지나가는 주먹 이동 가이드를 보며 같은 속도로 벽을 치세요.", // 5
        "# A 진동\n흰색 벽을 향해 주먹을 날리세요.", // 6 Go -- A
        "# B 진동\n흰색 벽을 향해 주먹을 날리세요.", // 7 Go -- B
        "# Trial 1\n흰색 벽을 향해 주먹을 날리세요.\nA와 B 중 어떤 진동입니까?\n\n1. 얼마나 사실적으로 느꼈습니까? 1 ~ 5?\n2. 얼마나 비사실적으로 느꼈습니까? 1 ~ 5?\n\n1 매우 아니다 ~ 5 매우 그렇다", // A 8
        "# Trial 2\n흰색 벽을 향해 주먹을 날리세요.\nA와 B 중 어떤 진동입니까?\n\n1. 얼마나 사실적으로 느꼈습니까? 1 ~ 5?\n2. 얼마나 비사실적으로 느꼈습니까? 1 ~ 5?\n\n1 매우 아니다 ~ 5 매우 그렇다", // B 9 
        "# Trial 3\n흰색 벽을 향해 주먹을 날리세요.\nA와 B 중 어떤 진동입니까?\n\n1. 얼마나 사실적으로 느꼈습니까? 1 ~ 5?\n2. 얼마나 비사실적으로 느꼈습니까? 1 ~ 5?\n\n1 매우 아니다 ~ 5 매우 그렇다", // A 10 
        "# Trial 4\n흰색 벽을 향해 주먹을 날리세요.\nA와 B 중 어떤 진동입니까?\n\n1. 얼마나 사실적으로 느꼈습니까? 1 ~ 5?\n2. 얼마나 비사실적으로 느꼈습니까? 1 ~ 5?\n\n1 매우 아니다 ~ 5 매우 그렇다", // B 11


        "Mode 2. Impact", // 12
        "이 실험에서는 주먹이 벽에 얼마나 세게 부딪히는지에 따라 충돌의 힘이 달라집니다.\n오른쪽에 지나가는 주먹 이동 가이드를 보며 같은 속도로 벽을 치세요.", // 13
        "# C 임팩트\n흰색 벽을 향해 주먹을 날리세요.", // 14 Go -- C
        "# D 임팩트\n흰색 벽을 향해 주먹을 날리세요.", // 15 Go -- D
        "# Trial 1\n흰색 벽을 향해 주먹을 날리세요.\nC와 D 중 어떤 임팩트입니까?\n\n1. 얼마나 사실적으로 느꼈습니까? 1 ~ 5?\n2. 얼마나 비사실적으로 느꼈습니까? 1 ~ 5?\n\n1 매우 아니다 ~ 5 매우 그렇다", // 16 Go -- C
        "# Trial 2\n흰색 벽을 향해 주먹을 날리세요.\nC와 D 중 어떤 임팩트입니까?\n\n1. 얼마나 사실적으로 느꼈습니까? 1 ~ 5?\n2. 얼마나 비사실적으로 느꼈습니까? 1 ~ 5?\n\n1 매우 아니다 ~ 5 매우 그렇다", // 17 D
        "# Trial 3\n흰색 벽을 향해 주먹을 날리세요.\nC와 D 중 어떤 임팩트입니까?\n\n1. 얼마나 사실적으로 느꼈습니까? 1 ~ 5?\n2. 얼마나 비사실적으로 느꼈습니까? 1 ~ 5?\n\n1 매우 아니다 ~ 5 매우 그렇다", // 18 C
        "# Trial 4\n흰색 벽을 향해 주먹을 날리세요.\nC와 D 중 어떤 임팩트입니까?\n\n1. 얼마나 사실적으로 느꼈습니까? 1 ~ 5?\n2. 얼마나 비사실적으로 느꼈습니까? 1 ~ 5?\n\n1 매우 아니다 ~ 5 매우 그렇다", // 19 D


        "Mode 3. Vibration & Impact", // 20
        "이 실험에서는 주먹이 벽에 부딪힐 때 진동과 충격이 모두 느껴집니다.\n오른쪽에 지나가는 주먹 이동 가이드를 보며 같은 속도로 벽을 치세요.", // 21
        "# E 반응\n흰색 벽을 향해 주먹을 날리세요.", // 22 Go -- E
        "# F 반응\n흰색 벽을 향해 주먹을 날리세요.", // 23 Go -- F
        "# Trial 1\n흰색 벽을 향해 주먹을 날리세요.\nE와 F 중 어떤 반응입니까?\n\n1. 얼마나 사실적으로 느꼈습니까? 1 ~ 5?\n2. 얼마나 비사실적으로 느꼈습니까? 1 ~ 5?\n\n1 매우 아니다 ~ 5 매우 그렇다", // 24 E
        "# Trial 2\n흰색 벽을 향해 주먹을 날리세요.\nE와 F 중 어떤 반응입니까?\n\n1. 얼마나 사실적으로 느꼈습니까? 1 ~ 5?\n2. 얼마나 비사실적으로 느꼈습니까? 1 ~ 5?\n\n1 매우 아니다 ~ 5 매우 그렇다", // 25 F
        "# Trial 3\n흰색 벽을 향해 주먹을 날리세요.\nE와 F 중 어떤 반응입니까?\n\n1. 얼마나 사실적으로 느꼈습니까? 1 ~ 5?\n2. 얼마나 비사실적으로 느꼈습니까? 1 ~ 5?\n\n1 매우 아니다 ~ 5 매우 그렇다", // 26 E
        "# Trial 4\n흰색 벽을 향해 주먹을 날리세요.\nE와 F 중 어떤 반응입니까?\n\n1. 얼마나 사실적으로 느꼈습니까? 1 ~ 5?\n2. 얼마나 비사실적으로 느꼈습니까? 1 ~ 5?\n\n1 매우 아니다 ~ 5 매우 그렇다", // 27 F

        "실험이 종료되었습니다.\n감사합니다." // 28
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