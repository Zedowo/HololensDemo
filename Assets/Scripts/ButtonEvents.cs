using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonEvents : MonoBehaviour
{
    public int counter = 0;
    TestTextChange testTextChange;
    public GameObject canvas;

    void Awake()
    {
        testTextChange = canvas.GetComponent<TestTextChange>();
    }

    public void backCounter()
    {
        counter--;
        testTextChange.updateText(counter);
    }

    public void updateCounter()
    {
        counter++;
        testTextChange.updateText(counter);
    }


}
