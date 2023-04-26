using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DemoEvents : MonoBehaviour
{
    public TextMeshPro textMesH;
    public GameObject allCube;
    public GameObject mainSlate;
    public GameObject moveCube;

    private int caseScenerio = 0;

    Vector3 originalPosition = new Vector3(0f, 0f, 0f);

    void Awake()
    {
        textMesH = mainSlate.GetComponent<TextMeshPro>();
    }

    public void updateText(int counter)
    {
        caseScenerio = counter;
        //each case is the next iteration for the next part of the tutorial. Strings combined downwards for readability.
        switch (counter)
        {
            case (0):
                textMesH.text = "The Hololens 2 has many options for user interaction. While there is the standard \"walk up and interact\", there are a myraid of options that allow for ease of use." +
                        "\r\n\r\nSome of these include:\r\n\r\n     " +
                        "- Gaze and Pinch\r\n     - Eye Tracking\r\n     - Speech Recognition\r\n";
                break;

            case (1):
                textMesH.text = "Try to move the red cube on the top right. In order to put do, hover your hand over the box. You should see a dotted line originating from your pointer. Hold down your hand. The line should turn solid, and you should see the box highlighted." +
                                "\r\n\r\nDrag the box in the hightlighted area by pulling the cube closer to you.";
                break;

        }
    }

}