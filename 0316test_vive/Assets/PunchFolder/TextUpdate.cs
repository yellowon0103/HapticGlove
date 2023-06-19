using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextUpdate : MonoBehaviour
{
    public TextMeshProUGUI ScriptText;
    private string[] textArray = { "1. vibration", "2. impact", "3. vibration & impact" };
    private int currentIndex = -1;

    // Start is called before the first frame update
    void Start()
    {
        ScriptText.text = "Start!";
    }

    public void Plus()
    {
        currentIndex++;

        if (currentIndex >= textArray.Length)
        {
            currentIndex = textArray.Length - 1;
        }

        ScriptText.text = textArray[currentIndex];
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