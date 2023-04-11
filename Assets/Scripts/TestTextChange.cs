using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TestTextChange : MonoBehaviour
{
    public TextMeshPro textMesH;

    void Start ()
    {
        //find the textMeshPro object
        textMesH = GetComponent<TextMeshPro>();
    }

    // Start is called before the first frame update
    public void updateText(int counter)
    {
        //each case is the next iteration for the next part of the tutorial. Strings combined downwards for readability.
        switch (counter)
        {
            case 1:
                textMesH.text = "First, let's take a look at a default interaction with all of these componenets -- no constraints added. With this box, you can move it around, change its size, and change its rotation. " +
                "The number of hands you use also matter when using these componenets. You'll notice that you aren't able to change an object's size with just one hand.";
                break;
        }
    }
}
