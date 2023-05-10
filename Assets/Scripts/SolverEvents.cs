using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Microsoft.MixedReality.Toolkit.Utilities.Solvers;
using UnityEngine.SceneManagement;

public class SolverEvents : MonoBehaviour
{
    public TextMeshPro textMesH;
    public ButtonEventsSolver buttonEvents;

    public GameObject magnetCube;
    public GameObject magnetSurface;
    public GameObject followCube;
    public Follow followCubeScript;
    public GameObject followNearMenu;

    public GameObject mainSlate;
    public GameObject navigationMenu;

    private int caseScenerio = 0;

    Vector3 objectStorage = new Vector3(10f, 10f, 10f);

    void Awake()
    {
        textMesH = mainSlate.GetComponent<TextMeshPro>();
        buttonEvents = navigationMenu.GetComponent<ButtonEventsSolver>();
        followCubeScript = followCube.GetComponent<Follow>();
    }

    public void updateText(int counter)
    {
        caseScenerio = counter;

        switch (caseScenerio)
        {
            case 0:
                textMesH.text = "A special subset of scripts that allow for \"smart\" interactions are known as Solvers. These essentially allow unique interactions that react relative to the user. ";
                followNearMenu.SetActive(false);
                break;

            case 1:
                textMesH.text = "The most common Solver you will most likely use is the Follow solver. This is what the \"Toggle (x)\" " +
                    "on your Near Menu uses. As the name implies, this Solver, when active, allows an object to follow the tracked object. " +
                    "In this example, the cube will be attached to you and follow you around. Access your Near Menu for customization settings to further manipulate this interaction.";
                followNearMenu.SetActive(true);
                break;
        }


    }
}
