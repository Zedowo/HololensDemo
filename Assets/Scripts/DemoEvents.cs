using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class DemoEvents : MonoBehaviour
{
    public TextMeshPro textMesH;
    public ButtonsEventsBasics buttonEvents;

    public GameObject moveCube;
    public GameObject moveCubeHorizontal;
    public GameObject rotateCube;
    public GameObject scaleCube;

    public GameObject mainSlate;
    public GameObject navigationMenu;
    public GameObject flagPole;

    private bool conditionOne = false;
    private bool conditionTwo = false;
    //conditions for min max scaling
    private int caseScenerio = 0;

    Vector3 originalPosition = new Vector3(0f, 0f, 0f);
    Vector3 originalFlagPosition = new Vector3(0.49f, 1.57f, 1.418f);
    Vector3 originalMoveCubePosition = new Vector3(0.916f, 2.755f, 3.128f);
    Vector3 objectStorage = new Vector3(10f, 10f, 10f);
    Vector3 originalRotateCubePosition = new Vector3(-0.0071f, 1.504f, 1.2195f);
    Vector3 originalMoveCubeHorizontalPosition = new Vector3(-0.497f, 1.54f, 1.092f);

    void Awake()
    {
        textMesH = mainSlate.GetComponent<TextMeshPro>();
        buttonEvents = navigationMenu.GetComponent<ButtonsEventsBasics>();
        //collision = navigationMenu.GetComponent<Collision>();
    }

/*    public void collisionRequirement()
    {
        this.updateText(2);
        buttonEvents.updateCounterNeutral();
    }*/

    public void resetCase()
    {
        this.updateText(caseScenerio);
    }

    public void updateText(int counter)
    {
        caseScenerio = counter;
        positionUpdate();

        //each case is the next iteration for the next part of the tutorial. Strings combined downwards for readability.
        switch (counter)
        {
            case (0):
                textMesH.text = "The Hololens 2 has many options for user interaction. While there is the standard \"walk up and interact\", there are a myraid of options that allow for ease of use." +
                        "\r\n\r\nSome of these include:\r\n\r\n     " +
                        "- Gaze and Pinch\r\n     - Eye Tracking\r\n     - Speech Recognition\r\n";
                break;

            case (1):
                textMesH.text = "First, let's try simply moving the cube from left to right. Grab the cube with one of your hands and simply slide it accross your screen.";
                break;

            case (2):
                textMesH.text = "Try to move the red cube on the top right. In order to put do, hover your hand over the box. You should see a dotted line originating from your pointer. Hold down your hand. The line should turn solid, and you should see the box highlighted." +
                                "\r\n\r\nDrag the box in the hightlighted area by pulling the cube closer to you.";
                break;

            case (3):
                textMesH.text = "Next, let's try rotating the cube. Using two hands, rotate the cube a full 180 degrees to the right (clockwise).";
                break;

            case (4):
                textMesH.text = "Now, try scaling this object upward and downward. Hold the object with both hands. Expand it outwards to grow it, and collapse it to shrink it.";
                break;

            case (5):
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                break;
        }
    }

    public void positionUpdate()
    {
        switch (caseScenerio)
        {
            case (0):
                moveCubeHorizontal.transform.position = objectStorage;
                break;

            case (1):
                moveCubeHorizontal.transform.position = originalMoveCubeHorizontalPosition;
                flagPole.transform.position = objectStorage;
                moveCube.transform.position = objectStorage;
                break;

            case (2):
                moveCubeHorizontal.transform.position = objectStorage;
                flagPole.transform.position = originalFlagPosition;
                moveCube.transform.position = originalMoveCubePosition;
                rotateCube.transform.position = objectStorage;
                break;

            case (3):
                flagPole.transform.position = objectStorage;
                moveCube.transform.position = objectStorage;
                scaleCube.transform.position = objectStorage;
                rotateCube.transform.position = originalRotateCubePosition;
                break;

            case (4):
                scaleCube.transform.position = originalRotateCubePosition;
                rotateCube.transform.position = objectStorage;
                break;
        }
    }

    void Update()
    {
        if (caseScenerio == 1){ 
            if (moveCubeHorizontal.transform.position.x > .4)
            {
                caseScenerio++;
                this.updateText(caseScenerio);
                buttonEvents.updateCounterNeutral();
            }    
        }
        else if (caseScenerio == 2)
        {
            moveCubeHorizontal.transform.position = objectStorage;
            if (moveCube.transform.position.x <= 0.51 && moveCube.transform.position.z <= 1.5)
            {
                caseScenerio++;
                this.updateText(caseScenerio);
                buttonEvents.updateCounterNeutral();
            }
        }
        else if (caseScenerio == 3)
        {
            moveCube.transform.position = objectStorage;
            if (rotateCube.transform.rotation.y >= 0.9982956)
            {
                caseScenerio++;
                this.updateText(caseScenerio);
                buttonEvents.updateCounterNeutral();  
            }
        }
        else if (caseScenerio == 4)
        {
            rotateCube.transform.position = objectStorage;
            if (scaleCube.transform.localScale.x >= 0.31)
            {
                conditionOne = true;
            }
            if (scaleCube.transform.localScale.x <= 0.177)
            {
                conditionTwo = true;
            }
            if (conditionOne && conditionTwo)
            {
                caseScenerio++;
                this.updateText(caseScenerio);
                buttonEvents.updateCounterNeutral();

            }
        }
        
    }
}