using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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
                break;
        }
    }


}
