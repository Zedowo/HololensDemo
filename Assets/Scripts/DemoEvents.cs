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

    public AudioSource ring;
    private int caseScenerio = 0;

   /* Vector3 originalPosition = new Vector3(0f, 0f, 0f);
    Vector3 originalFlagPosition = new Vector3(0.49f, 1.57f, 1.418f);
    Vector3 originalMoveCubePosition = new Vector3(0.916f, 2.755f, 3.128f);
    Vector3 objectStorage = new Vector3(10f, 10f, 10f);
    Vector3 originalRotateCubePosition = new Vector3(-0.0071f, 1.504f, 1.2195f);
    Vector3 originalMoveCubeHorizontalPosition = new Vector3(-0.497f, 1.54f, 1.092f);*/

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
                textMesH.text = "When interacting with MRTK options, the user has a choice to perform three interactions, whether simultaneously or at once. For the sake of these basics, " +
                    "a few constraints have been placed on the objects to ensure you only perform the intended interaction. These interactions include:\r\n\r\n- Moving (Along any axis)\r\n- " +
                    "Rotation (Along any axis)\r\n- Scaling \r\n";
                break;

            case (1):
                textMesH.text = "First, let's try simply moving the cube from left to right. Grab the cube with one of your hands and simply slide it across your screen.";
                break;

            case (2):
                textMesH.text = "Try to move the red cube on the top right. In order to do so, hover your hand over the box. You should see a dotted line originating from your pointer. Hold down your hand. The line should turn solid, and you should see the box highlighted." +
                                "\r\n\r\nDrag the box in the highlighted area by pulling the cube closer to you.";
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
                moveCubeHorizontal.SetActive(false);
                break;

            case (1):
                moveCubeHorizontal.SetActive(true);
                flagPole.SetActive(false);
                moveCube.SetActive(false);
                break;

            case (2):
                moveCubeHorizontal.SetActive(false);
                flagPole.SetActive(true);
                moveCube.SetActive(true);
                rotateCube.SetActive(false);
                break;

            case (3):
                flagPole.SetActive(false);
                moveCube.SetActive(false);
                rotateCube.SetActive(true);
                scaleCube.SetActive(false);
                break;

            case (4):
                scaleCube.SetActive(true);
                rotateCube.SetActive(false);
                break;
        }
    }

    void Update()
    {
        if (caseScenerio == 1){ 
            if (moveCubeHorizontal.transform.position.x > .4)
            {
                caseScenerio++;
                ring.Play();
                this.updateText(caseScenerio);
                buttonEvents.updateCounterNeutral();
            }    
        }
        else if (caseScenerio == 2)
        {
            if (moveCube.transform.position.x <= 0.51 && moveCube.transform.position.z <= 1.5)
            {
                caseScenerio++;
                ring.Play();
                this.updateText(caseScenerio);
                buttonEvents.updateCounterNeutral();
            }
        }
        else if (caseScenerio == 3)
        {
            if (rotateCube.transform.rotation.y >= 0.9982956)
            {
                caseScenerio++;
                ring.Play();
                this.updateText(caseScenerio);
                buttonEvents.updateCounterNeutral();  
            }
        }
        else if (caseScenerio == 4)
        {
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
                ring.Play();
                this.updateText(caseScenerio);
                buttonEvents.updateCounterNeutral();

            }
        }
        
    }
}