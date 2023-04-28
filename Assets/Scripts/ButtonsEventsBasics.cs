using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonsEventsBasics : MonoBehaviour
{
    public int counter = 0;
    DemoEvents demoEvents;
    ChangeMenu changeMenu;
    public GameObject navigationMenu;

    void Awake()
    {
        demoEvents = navigationMenu.GetComponent<DemoEvents>();
        changeMenu = navigationMenu.GetComponent<ChangeMenu>();
    }

    public void backCounter()
    {
        if (counter == 0)
        {
            changeMenu.BackwardScene();
        }
        counter--;
        demoEvents.updateText(counter);
    }

    public void updateCounter()
    {
        counter++;
        demoEvents.updateText(counter);
    }

    public void updateCollision()
    {
        counter++;
    }
}
