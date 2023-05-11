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
    private bool condition1;
    private bool condition2;
    private bool condition3;

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
        this.eventTrigger();

        switch (caseScenerio)
        {
            case 0:
                textMesH.text = "A special subset of scripts that allow for \"smart\" interactions are known as Solvers. These essentially allow unique interactions that react relative to the user. ";
                break;

            case 1:
                textMesH.text = "The most common Solver you will most likely use is the Follow solver. This is what the \"Toggle (x)\" " +
                    "on your Near Menu uses. As the name implies, this Solver, when active, allows an object to follow the tracked object. " +
                    "In this example, the cube will be attached to you and follow you around. Access your Near Menu for customization settings to further manipulate this interaction.";
                break;
            case 2:
                textMesH.text = "Another solver you may use is Surface Magnetism. As the name applies, any object with this script will magnetise" +
                    " to the surface it sees. In this demonstration example, try to hit all of the black points on the surface board WITHOUT moving. " +
                    "The cube should naturally track with your head. Other interaction types are also possible.";
                    break;
        }


    }

    void Update()
    {
        switch (caseScenerio)
        {
            default:
                break;
            case 2:
                if ((magnetCube.transform.position.x < -0.34 && magnetCube.transform.position.x > -0.36) && (magnetCube.transform.position.y < 0.27 && magnetCube.transform.position.y > .23))
                {
                    condition1 = true;
                }
                if (condition1 && condition2 && condition3)
                {
                    caseScenerio += 1;
                    buttonEvents.updateCounterNeutral();
                    updateText(caseScenerio);
                }
                break;
        }
    }

    public void eventTrigger()
    {
        switch (caseScenerio)
        {
            case 0:
                followNearMenu.SetActive(false);
                followCube.SetActive(false);
                break;
            case 1:
                followNearMenu.SetActive(true);
                followCube.SetActive(true);
                break;
            case 2:
                followNearMenu.SetActive(false);
                followCube.SetActive(false);
                break;
        }
    }
    //list of methods to be used for Follow adjustments

    public void addMin()
    {
        followCubeScript.minDistance += 0.1f;
    }

    public void subtractMin()
    {
        if (followCubeScript.minDistance < 0.11)
        {
            followCubeScript.minDistance = 0.1f;
            Debug.Log("Too Low!");
        }
        else
        {
            followCubeScript.minDistance -= 0.1f;
        }
    }

    public void addMax()
    {
        followCubeScript.maxDistance += 0.1f;
    }

    public void subtractMax()
    {
        if (followCubeScript.minDistance == 0.1f)
        {
            Debug.Log("Too Low!");
        }
        else
        {
            followCubeScript.minDistance -= 0.1f;
        }
    }

    public void addHorizontal()
    {
        followCubeScript.maxViewHorizontalDegrees += 10f;
    }

    public void subtractHorizontal()
    {
        if (followCubeScript.maxViewHorizontalDegrees < 11)
        {
            followCubeScript.maxViewHorizontalDegrees = 10f;
            Debug.Log("Too Low!");
        }
        else
        {
            followCubeScript.maxViewHorizontalDegrees -= 10f;
        }
    }

    public void addVertical()
    {
        followCubeScript.maxViewVerticalDegrees += 10f;
    }

    public void subtractVertical()
    {
        if (followCubeScript.maxViewVerticalDegrees < 11)
        {
            followCubeScript.maxViewVerticalDegrees = 10f;
            Debug.Log("Too Low!");
        }
        else
        {
            followCubeScript.maxViewVerticalDegrees -= 10f;
        }
    }
}
