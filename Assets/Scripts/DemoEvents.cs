using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DemoEvents : MonoBehaviour
{
    public TextMeshPro textMesH;
    public GameObject allCube;
    public GameObject mainSlate;

    void Awake()
    {
        textMesH = mainSlate.GetComponent<TextMeshPro>();
    }

    public void updateText(int counter)
    {
        //each case is the next iteration for the next part of the tutorial. Strings combined downwards for readability.
        switch (counter)
        {
            case (0):
                textMesH.text = "The Hololens 2 has many options for user interaction. While there is the standard \"walk up and interact\", there are a myraid of options that allow for ease of use." +
                        "\r\n\r\nSome of these include:\r\n\r\n     " +
                        "- Gaze and Pinch\r\n     - Eye Tracking\r\n     - Speech Recognition\r\n";
                break;

            case (1):
                textMesH.text = "Try to input";
                break;

        }
    }

}