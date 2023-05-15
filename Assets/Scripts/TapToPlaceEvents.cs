using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapToPlaceEvents : MonoBehaviour
{
    public GameObject cubeOne;
    public GameObject cubeTwo;
    public GameObject cubeThree;

    private int counter = 0;

    public void activateNext()
    {
        counter++;
        if (counter == 1)
        {
            cubeTwo.SetActive(true);
        }
        else
        {
            cubeThree.SetActive(true);
        }
    }
}
