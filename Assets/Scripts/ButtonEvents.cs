using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonEvents : MonoBehaviour
{
    public int counter = 0;
    TestTextChange testTextChange;
    ChangeMenu changeMenu;
    public GameObject canvas;


    void Awake()
    {
        testTextChange = canvas.GetComponent<TestTextChange>();
        changeMenu = canvas.GetComponent<ChangeMenu>();
    }

    public void backCounter()
    {
        if (counter == 0)
        {
            changeMenu.BackwardScene();
        }
        counter--;
        testTextChange.updateText(counter);
    }

    public void updateCounter()
    {
        counter++;
        testTextChange.updateText(counter);
    }


}
