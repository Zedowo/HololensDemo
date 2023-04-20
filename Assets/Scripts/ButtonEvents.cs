using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonEvents : MonoBehaviour
{
    public int counter = 0;
    ObjectandBoundEvents objectandBoundEvents;
    ChangeMenu changeMenu;
    public GameObject canvas;


    void Awake()
    {
        objectandBoundEvents = canvas.GetComponent<ObjectandBoundEvents>();
        changeMenu = canvas.GetComponent<ChangeMenu>();
    }

    public void backCounter()
    {
        if (counter == 0)
        {
            changeMenu.BackwardScene();
        }
        counter--;
        objectandBoundEvents.updateText(counter);
    }

    public void updateCounter()
    {
        counter++;
        objectandBoundEvents.updateText(counter);
    }


}
