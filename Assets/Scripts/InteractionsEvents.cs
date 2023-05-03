using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InteractionEvents : MonoBehaviour
{
    public ButtonEventsInteraction buttonEvents;
    public TextMeshPro textMesH;

    public GameObject mainSlate;
    public GameObject navigationMenu;
    private int caseScenerio = 0;
    public GameObject gazeCube;

    //Color white = new Color(0f, 0f, 0f, 0f);
    Color red = new Color(255f, 0f, 40f, 0.8f);
    Color blue = new Color(0f, 66f, 255f, 0.8f);
    Color green = new Color(8f, 255f, 0f, 0.8f);


    void Awake()
    {
        textMesH = mainSlate.GetComponent<TextMeshPro>();
        buttonEvents = navigationMenu.GetComponent<ButtonEventsInteraction>();
    }

    /*public void goWhite()
    {
        var cubeRenderer = gazeCube.GetComponent<Renderer>();
        cubeRenderer.material.SetColor("_Color", white);
    }*/
    public void updateColor()
    {
        var cubeRenderer = gazeCube.GetComponent<Renderer>();
        cubeRenderer.material.SetColor("_Color", red);
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
