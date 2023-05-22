using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Microsoft.MixedReality.Toolkit.Utilities.Solvers;
using UnityEngine.SceneManagement;

public class VoiceCommandEvents : MonoBehaviour
{
    public GameObject mainText;
    public TextMeshPro textMesH;
    public ButtonEventVoice buttonEvents;
    public GameObject navigationMenu;
    public GameObject mainSlate;

    public GameObject largeSlate;
    public GameObject smallSlate;
    public GameObject smallMainText;
    public GameObject largeMainText;
    private TextMeshPro textMeshSmall;
    private TextMeshPro textMeshLarge;

    public GameObject colorCube;
    private Renderer cubeRenderer;
    Color white = new Color(255f, 255f, 255f, 0.8f);
    Color red = new Color(255f, 0f, 0f, 0.8f);
    Color blue = new Color(0f, 0f, 255f, 0.8f);
    Color green = new Color(0f, 255f, 0f, 0.8f);
    Color black = new Color(0f, 0f, 0f, 0.8f);

    private int caseScenerio = 0;

    Vector3 originalSlatePosition = new Vector3(.104f, 1.78f, 1.505f);
    Vector3 movedSlatePosition = new Vector3(.218f, 2.061f, 1.505f);

    void Awake()
    {
        textMesH = mainText.GetComponent<TextMeshPro>();
        buttonEvents = navigationMenu.GetComponent<ButtonEventVoice>();
        textMeshSmall = smallMainText.GetComponent<TextMeshPro>();
        textMeshLarge = largeMainText.GetComponent<TextMeshPro>();
        cubeRenderer = colorCube.GetComponent<Renderer>();
    }

    public void updateText(int counter)
    {
        caseScenerio = counter;
        this.positionUpdate();

        switch (caseScenerio)
        {
            case 0:
                textMesH.text = "Second, voice commands. Two objects handle" +
                    " this component: the object listening (the microphone) and the Toolkit, which is checked with to see if a command is valid. " +
                    "These components work in tangent to enable speech recognition, allowing you to perform hands-free interactions; a feature you will find most useful.";
                break;

            case 1:
                textMesH.text = "Here's an example of a color changing program. Here, the cube is set up with the following colors: white, red, blue, green, and black. " +
                    "The confidence level has also been set to medium -- meaning the microphone will detect things with around a 50% rate of reluctance.";
                break;

            case 2:
                textMesH.text = "If we go back to the idea of an object being a microphone, you will find that voice recognition will work seperately between " +
                    "objects of difference sizes and distances. The bigger the microphone, the more it hears. The closer you are to the microphone, the better it hears." +
                    " Of course, you can also simply see microphones to the user for a universal command.";
                break;
            case 3:
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                break;

        }
    }

    public void positionUpdate()
    {
        switch (caseScenerio)
        {
            default:
                break;
            case 0:
                colorCube.gameObject.SetActive(false);
                break;
            case 1:
                mainSlate.transform.position = originalSlatePosition;
                colorCube.gameObject.SetActive(true);
                smallSlate.SetActive(false);
                largeSlate.SetActive(false);
                break;
            case 2:
                mainSlate.transform.position = movedSlatePosition;
                colorCube.gameObject.SetActive(false);
                smallSlate.SetActive(true);
                largeSlate.SetActive(true);
                break;
        }
    }

    public void activateTextBig()
    {
        StartCoroutine(flashRecognized(1));
    }

    public void activateTextSmall()
    {
        StartCoroutine(flashRecognized(2));
    }

    IEnumerator flashRecognized(int slateNumber)
    {
        if (slateNumber == 1)
        {
            textMeshLarge.text = "Voice Command Recognized!";
            yield return new WaitForSeconds(2);
            textMeshLarge.text = "Command Not Recognized.";
        }
        else
        {
            textMeshSmall.text = "Voice Command Recognized!";
            yield return new WaitForSeconds(2);
            textMeshSmall.text = "Command Not Recognized.";
        }
        yield return null;
    }

    public void colorRed()
    {
        cubeRenderer.material.SetColor("_Color", red);
    }

    public void colorWhite()
    {
        cubeRenderer.material.SetColor("_Color", white);
    }

    public void colorBlue()
    {
        cubeRenderer.material.SetColor("_Color", blue);
    }

    public void colorGreen()
    {
        cubeRenderer.material.SetColor("_Color", green);
    }

    public void colorBlack()
    {
        cubeRenderer.material.SetColor("_Color", black);
    }

    public void testPrint()
    {
        Debug.Log("Successful!");
    }
}
