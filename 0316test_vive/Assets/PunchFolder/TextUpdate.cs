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
        "Press Trigger button to move next.",

        "Mode 0. Punch Simulation", // 1
        "Punch toward the white wall in front of you.\nFollow the speed of the fist shown on the right.\nWhen a fist collides with a wall, the wall turns red.\nThen, hold for 5 seconds with your arms outstretched.",
        "# Test the Punch\nIf you've tested enough, hit the Trigger button to move on.", // 3 


        "Mode 1. Vibration", // 4
        "In this experiment, if a fist collides with a wall, it will cause a vibration.",
        "# A\nPunch toward the white wall.", // 6 Go -- A
        "# B\nPunch toward the white wall.", // 7 Go -- B
        "# Trial 1\nPunch toward the white wall.\nIs it A or B?", // 8 Go -- B
        "# Trial 2\nPunch toward the white wall.\nIs it A or B?", // 9 Go -- B
        "# Trial 3\nPunch toward the white wall.\nIs it A or B?", // 10 Go -- A
        "# Trial 4\nPunch toward the white wall.\nIs it A or B?", // 11 Go -- B
        "# Trial 5\nPunch toward the white wall.\nIs it A or B?", // 12 Go -- A
        "1. How realistic did it feel?\n\n1 Not very realistic\n2 Not realistic\n3 Moderate\n4 Realistic\n5 Very realistic",
        "2. How fake did it feel?\n\n1 Not very fake\n2 Not fake\n3 Moderate\n4 fake\n5 Very fake",


        "Mode 2. Impact", // 15
        "In this experiment, the force of the collision will vary depending on how hard your fist collides with the wall.",
        "# C\nPunch toward the white wall.", // 17 Go -- C
        "# D\nPunch toward the white wall.", // 18 Go -- D
        "# Trial 1\nPunch toward the white wall.\nIs it C or D?", // 19 Go -- C
        "# Trial 2\nPunch toward the white wall.\nIs it C or D?", // 20 Go -- D
        "# Trial 3\nPunch toward the white wall.\nIs it C or D?", // 21 Go -- C
        "# Trial 4\nPunch toward the white wall.\nIs it C or D?", // 22 Go -- C
        "# Trial 5\nPunch toward the white wall.\nIs it C or D?", // 23 Go -- D
        "1. How realistic did it feel?\n\n1 Not very realistic\n2 Not realistic\n3 Moderate\n4 Realistic\n5 Very realistic",
        "2. How fake did it feel?\n\n1 Not very fake\n2 Not fake\n3 Moderate\n4 fake\n5 Very fake",


        "Mode 3. Vibration & Impact", // 26
        "In this experiment, both vibration and impact will be felt when the fist collides with the wall.",
        "# E\nPunch toward the white wall.", // 28 Go -- E
        "# F\nPunch toward the white wall.", // 29 Go -- F
        "# Trial 1\nPunch toward the white wall.\nIs it E or F?", // 30 Go -- E
        "# Trial 2\nPunch toward the white wall.\nIs it E or F?", // 31 Go -- E
        "# Trial 3\nPunch toward the white wall.\nIs it E or F?", // 32 Go -- F
        "# Trial 4\nPunch toward the white wall.\nIs it E or F?", // 33 Go -- E 
        "# Trial 5\nPunch toward the white wall.\nIs it E or F?", // 34 Go -- F
        "1. How realistic did it feel?\n\n1 Not very realistic\n2 Not realistic\n3 Moderate\n4 Realistic\n5 Very realistic",
        "2. How fake did it feel?\n\n1 Not very fake\n2 Not fake\n3 Moderate\n4 fake\n5 Very fake",

        "The experiment is finished.\nThank you." // 27
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