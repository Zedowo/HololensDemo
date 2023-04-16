using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TestTextChange : MonoBehaviour
{
    public TextMeshPro textMesH;
    public GameObject allCube;
    public GameObject mainSlate;

    Vector3 originalPosition = new Vector3(0.124f, 1.905f, 2.096f);
    Vector3 leftPosition = new Vector3(-1.071f, 1.905f, 2.096f);
    Vector3 rightCubePosition = new Vector3(0.934f, 1.464f, 2.138f);
    Vector3 restingCubePosition = new Vector3(1f, -10f, -10f);


    void Start ()
    {
        //find the textMeshPro object
        textMesH = GetComponent<TextMeshPro>();
    }

    public void printer()
    {
        Debug.Log("Hello World");
    }
 
    public void updateText(int counter)
    {
        //each case is the next iteration for the next part of the tutorial. Strings combined downwards for readability.
        switch (counter)
        {
            case 0:
                textMesH.text = "These three objects are scripts that typically work in tangent with one another. When you add ObjectManipulator to an object, Constraints are automatically added (as this is the default).\r\n\r\nTo properly move these objects," +
                "however, you also need a specific script named UGUIInputAdapterDraggable (you can find this by simply looking this up under \"Assets\" and all.) This is what allows the object to be interacted with.\r\n";
                mainSlate.transform.position = originalPosition;
                allCube.transform.position = restingCubePosition;
                break;

            case 1:
                textMesH.text = "First, let's take a look at a default interaction with all of these componenets -- no constraints added. With this box, you can move it around, change its size, and change its rotation. " +
                "The number of hands you use also matters when using these componenets. You'll notice that you aren't able to change an object's size with just one hand.";
                mainSlate.transform.position = leftPosition;
                allCube.transform.position = rightCubePosition;
                break;
         
        }
    }
}
