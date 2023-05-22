using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Microsoft.MixedReality.Toolkit.Utilities.Solvers;
using UnityEngine.SceneManagement;


public class InteractionEvents : MonoBehaviour
{
    public ButtonEventsInteraction buttonEvents;
    public TextMeshPro textMesH;
    public Renderer cubeRendererGaze;
    public Renderer cubeRendererRay;
    public Renderer cubeRendererHold;

    public GameObject mainSlate;
    public GameObject navigationMenu;
    private int caseScenerio = 0;
    public GameObject gazeCube;
    public GameObject rayCube;
    public GameObject holdCube;

    public Follow followMeRay;
    public Follow followMeGaze;
    public Follow followMeHold;

    Color white = new Color(255f, 255f, 255f, 0.8f);
    Color red = new Color(255f, 0f, 40f, 0.8f);
    Color blue = new Color(0f, 66f, 255f, 0.8f);
    Color green = new Color(5f, 255f, 0f, 0.8f);

    Vector3 centerCubePosition = new Vector3(0.015f, 1.531f, 1.394f);
    Vector3 objectStorage = new Vector3(10f, 10f, 10f);

    void Awake()
    {
        textMesH = mainSlate.GetComponent<TextMeshPro>();
        buttonEvents = navigationMenu.GetComponent<ButtonEventsInteraction>();
        cubeRendererGaze = gazeCube.GetComponent<Renderer>();
        cubeRendererRay = rayCube.GetComponent<Renderer>();
        cubeRendererHold = holdCube.GetComponent<Renderer>();
        followMeRay = rayCube.GetComponent<Follow>();
        followMeHold = holdCube.GetComponent<Follow>();
        followMeGaze = gazeCube.GetComponent<Follow>();
    }

    public void resetColorGaze()
    {
        cubeRendererGaze.material.SetColor("_Color", white);
    }

    public void updateColorGaze()
    {
        cubeRendererGaze.material.SetColor("_Color", red);
    }

    public void resetColorRay()
    {
        cubeRendererRay.material.SetColor("_Color", white);
    }

    public void updateColorRay()
    {
        cubeRendererRay.material.SetColor("_Color", green);
    }

    public void resetColorHold()
    {
        cubeRendererHold.material.SetColor("_Color", white);
    }

    public void updateColorHold()
    {
        cubeRendererHold.material.SetColor("_Color", blue);
    }

    public void followTrigger()
    {
        switch (caseScenerio)
        {
            case 1:
                followMeHold.enabled = true;
                break;

            case 2:
                followMeRay.enabled = true;
                break;

            case 3:
                followMeGaze.enabled = true;
                break;
        }
    }

    public void deFollow()
    {
        switch (caseScenerio)
        {
            case 1:
                followMeHold.enabled = false;
                break;

            case 2:
                followMeRay.enabled = false;
                break;

            case 3:
                followMeGaze.enabled = false;
                break;
        }
    }

    /*public IEnumerator changeColors()
    {
        while (true)
        {
            switch (caseScenerio)
            {
                case 1:
            }
        }
    }*/

    public void updateText(int counter)
    {
        caseScenerio = counter;
        switch (counter)
        {
            case 0:
                textMesH.text = "MRTK is also able to detect certain interactions types from the user. The examples that will be demonstrated will be following:\r\n\r\n     - Eye Tracking\r\n" +
                    "     - Ray Pointing\r\n     - Hold Detection";
                followMeHold.enabled = false;
                holdCube.SetActive(false);
                break;
            case 1:
                textMesH.text = "First, Hold Interactions. When grabbing the object, you'll notice the cube will turn a different color. This \"event\" will stop whenever your hands are off the cube.";
                followMeRay.enabled = false;
                holdCube.SetActive(true);
                rayCube.SetActive(false);
                break;

            case 2:
                textMesH.text = "Next, we'll explore the ray interaction. Point your finger towards the cube and align the ray line with box. ";
                followMeHold.enabled = false;
                followMeGaze.enabled = false;
                holdCube.SetActive(false);
                rayCube.SetActive(true);
                gazeCube.SetActive(false);
                break;

            case 3:
                textMesH.text = "Finally, the gaze interaction. Focus the object on the center of your screen. It will light up whenever you look at it, but will not activate if your eyes are not tracking the object. " +
                    "You can notice this in your peripheral vision.";
                followMeRay.enabled = false;
                rayCube.SetActive(false);
                rayCube.SetActive(true);
                break;

            case 4:
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                break;
        }
    }


}
