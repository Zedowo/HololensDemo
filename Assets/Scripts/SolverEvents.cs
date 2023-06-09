using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Microsoft.MixedReality.Toolkit.Utilities.Solvers;
using UnityEngine.SceneManagement;

public class SolverEvents : MonoBehaviour
{
    //ERROR: Back counter does not work AFTER the second case is completed. It works normally skipping through, but not when the user completes the event to move on from case 2.
    private TextMeshPro textMesH;
    private ButtonEventsSolver buttonEvents;

    public GameObject magnetCube;
    public GameObject magnetSurface;
    public GameObject followCube;
    private Follow followCubeScript;
    public GameObject followNearMenu;

    public GameObject inBetweenCubes;

    public GameObject mainSlate;
    public GameObject mainText;
    public GameObject navigationMenu;

    private int caseScenerio = 0;
    private bool condition1;
    private bool condition2;
    private bool condition3;

    public GameObject cubeLeft;
    public GameObject cubeMiddle;
    public GameObject cubeRight;
    private Renderer cubeRendererLeft;
    private Renderer cubeRendererMiddle;
    private Renderer cubeRendererRight;
    Color black = new Color(0f, 0f, 0f, 0.8f);
    Color yellow = new Color(255f, 255f, 0f, 0.8f);
    public AudioSource ring;
    public AudioSource celebration;

    Vector3 objectStorage = new Vector3(10f, 10f, 10f);
    Vector3 originalSlatePosition = new Vector3(-0.216f, 1.78f, 1.612f);
    Vector3 newSlatePosition = new Vector3(0.076f, 1.211f, 1.612f);

    void Awake()
    {
        textMesH = mainText.GetComponent<TextMeshPro>();
        buttonEvents = navigationMenu.GetComponent<ButtonEventsSolver>();
        followCubeScript = followCube.GetComponent<Follow>();

        cubeRendererLeft = cubeLeft.GetComponent<Renderer>();
        cubeRendererMiddle = cubeMiddle.GetComponent<Renderer>();
        cubeRendererRight = cubeRight.GetComponent<Renderer>();
    }

    public void updateText(int counter)
    {
        caseScenerio = counter;
        this.eventTrigger();

        switch (caseScenerio)
        {
            case 0:
                textMesH.text = "A special subset of spatial manipulation scripts that allow for \"smart\" interactions are known as Solvers. These essentially allow unique interactions that react relative to the user.";
                break;

            case 1:
                textMesH.text = "The most common Solver you will most likely use is the Follow solver. This is what the \"Toggle (x)\" " +
                    "on your Near Menu uses. As the name implies, this Solver, when active, allows an object to follow the tracked object. " +
                    "In this example, the cube will be attached to you and follow you around. Access your Near Menu for customization settings to further manipulate this interaction.";
                break;
            case 2:
                textMesH.text = "Another solver you may use is Surface Magnetism. As the name applies, any object with this script will magnetize" +
                    " to the surface it sees. In this demonstration example, try to hit all of the black points on the surface board WITHOUT moving. " +
                    "The cube should naturally track with your head. Other interaction types are also possible.";
                    break;
            case 3:
                textMesH.text = "Next, the In Between solver. As the name implies, the object the solver is placed upon will move in between two" +
                    " objects the user sets. This is an average distance, and will remain true no matter what axis is being manipulated.";
                break;
            case 4:
                textMesH.text = "The next scene will explore another solver (Tap to Place) as well as the integration of solvers with spatial awareness. " +
                    "The interface used in this scene will be vastly different from the ones before; be prepared.";
                break;
            case 5:
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                break;
        }
    }

    void Update()
    {
        //Debug.Log(caseScenerio);
        switch (caseScenerio)
        {
            default:
                break;
            case 2:
                if ((magnetCube.transform.position.x < -0.87 && magnetCube.transform.position.x > -1.3) && (magnetCube.transform.position.y < 2.24 && magnetCube.transform.position.y > 2.115) && condition1 == false)
                {
                    condition1 = true;
                    cubeRendererLeft.material.SetColor("_Color", yellow);
                    ring.Play();
                }
                else if ((magnetCube.transform.position.x < -0.025 && magnetCube.transform.position.x > -0.16) && (magnetCube.transform.position.y < 1.27 && magnetCube.transform.position.y > 1.15) && condition2 == false)
                {
                    condition2 = true;
                    cubeRendererMiddle.material.SetColor("_Color", yellow);
                    ring.Play();
                }
                else if ((magnetCube.transform.position.x < .896 && magnetCube.transform.position.x > 0.77) && (magnetCube.transform.position.y < 2.24 && magnetCube.transform.position.y > 2.14) && condition3 == false)
                {
                    condition3 = true;
                    cubeRendererRight.material.SetColor("_Color", yellow);
                    ring.Play();
                }
                if (condition1 && condition2 && condition3)
                {
                    buttonEvents.updateCounter();
                    celebration.Play();
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
                magnetCube.SetActive(false);
                magnetSurface.SetActive(false);
                mainSlate.transform.position = originalSlatePosition;
                mainSlate.transform.eulerAngles = new Vector3(0, 0, 0);
                break;
            case 2:
                followNearMenu.SetActive(false);
                followCube.SetActive(false);
                magnetCube.SetActive(true);
                magnetSurface.SetActive(true);
                cubeRendererRight.material.SetColor("_Color", black);
                cubeRendererLeft.material.SetColor("_Color", black);
                cubeRendererMiddle.material.SetColor("_Color", black);
                mainSlate.transform.position = newSlatePosition;
                mainSlate.transform.eulerAngles = new Vector3(45, 0, 0);
                inBetweenCubes.SetActive(false);
                break;
            case 3:
                magnetCube.SetActive(false);
                magnetSurface.SetActive(false);
                mainSlate.transform.position = originalSlatePosition;
                mainSlate.transform.eulerAngles = new Vector3(0, 0, 0);
                inBetweenCubes.SetActive(true);
                break;
            case 4:
                inBetweenCubes.SetActive(false);
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
        if (followCubeScript.maxDistance == 0.1f)
        {
            Debug.Log("Too Low!");
        }
        else
        {
            followCubeScript.maxDistance -= 0.1f;
        }
    }

    public void addHorizontal()
    {
        followCubeScript.maxViewHorizontalDegrees += 30f;
    }

    public void subtractHorizontal()
    {
        if (followCubeScript.maxViewHorizontalDegrees < 31)
        {
            followCubeScript.maxViewHorizontalDegrees = 30f;
            Debug.Log("Too Low!");
        }
        else
        {
            followCubeScript.maxViewHorizontalDegrees -= 30f;
        }
    }

    public void addVertical()
    {
        followCubeScript.maxViewVerticalDegrees += 30f;
    }

    public void subtractVertical()
    {
        if (followCubeScript.maxViewVerticalDegrees < 31)
        {
            followCubeScript.maxViewVerticalDegrees = 30f;
            Debug.Log("Too Low!");
        }
        else
        {
            followCubeScript.maxViewVerticalDegrees -= 30f;
        }
    }
}
