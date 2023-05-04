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

    public GameObject mainSlate;
    public GameObject navigationMenu;
    private int caseScenerio = 0;
    public GameObject gazeCube;
    private GameObject rayCube;

    Color black = new Color(0f, 0f, 0f, 0f);
    Color red = new Color(255f, 0f, 40f, 0.8f);
    Color blue = new Color(0f, 66f, 255f, 0.8f);
    Color green = new Color(8f, 255f, 0f, 0.8f);


    void Awake()
    {
        textMesH = mainSlate.GetComponent<TextMeshPro>();
        buttonEvents = navigationMenu.GetComponent<ButtonEventsInteraction>();
        cubeRendererGaze = gazeCube.GetComponent<Renderer>();
        cubeRendererRay = gazeCube.GetComponent<Renderer>();
    }

    public void resetColorGaze()
    {
        cubeRendererGaze.material.SetColor("_Color", black);
    }

    public void updateColorGaze()
    {
        cubeRendererGaze.material.SetColor("_Color", red);
    }

    public void resetColorRay()
    {
        cubeRendererRay.material.SetColor("_Color", black);
    }

    public void updateColorRay()
    {
        cubeRendererRay.material.SetColor("_Color", red);
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
                textMesH.text = "Start Scene";
                break;
        }
    }


}
