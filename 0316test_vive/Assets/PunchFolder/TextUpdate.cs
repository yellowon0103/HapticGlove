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
        "Test the Punch\nIf you've tested enough, hit the Trigger button to move on.", // 3 

        "Mode 1. Vibration", // 4
        "In this experiment, if a fist collides with a wall, it will cause a vibration.",
        "Punch toward the white wall.", // 6 Go
        "Try again.\nPunch toward the white wall.", // 7 Go
        "A. Did you feel the vibration in your hand?\nYes or No",

        "Mode 2. Impact", // 9
        "In this experiment, the force of the collision will vary depending on how hard your fist collides with the wall.",
        "You will be asked to rate intensity from 0 to 10.",
        "Follow the speed of the fist shown on the right.\nThe speed is random.",
        "For example, right now it's an impact of 5 out of 10.\nPunch toward the white wall.", // 13 Go
        "Try again.\nImpact of 5 out of 10.\nPunch toward the white wall.",

        "Now let's start the experiment.", // 15
        "Punch toward the white wall.\nThen, hold for 5 seconds with your arms outstretched.",
        "Try again.\nPunch toward the white wall.\nThen, hold for 5 seconds with your arms outstretched.",
        "B. How strong is the impact?\nFrom 0 to 10.",


        "Mode 3. Vibration & Impact", // 19
        "In this experiment, both vibration and impact will be felt when the fist collides with the wall.",
        "You will be asked if you felt the vibration and how strong the impact was from 0 to 10.",

        "Now let's start the experiment.", // 22
        "Punch toward the white wall.\nThen, hold for 5 seconds with your arms outstretched.", // 23 Go
        "Try again.\nPunch toward the white wall.\nThen, hold for 5 seconds with your arms outstretched.",
        "C. Did you feel the vibration in your hand?\nYes or No\nD. How strong is the impact?\nFrom 0 to 10.",

        "The experiment is finished.\nThank you." // 26
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