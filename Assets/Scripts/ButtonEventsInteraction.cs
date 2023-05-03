using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonEventsInteraction : MonoBehaviour
{
    public int counter = 0;
    InteractionEvents interactionEvents;
    ChangeMenu changeMenu;
    public GameObject navigationMenu;


    void Awake()
    {
        interactionEvents = navigationMenu.GetComponent<InteractionEvents>();
        changeMenu = navigationMenu.GetComponent<ChangeMenu>();
    }

    public void backCounter()
    {
        if (counter == 0)
        {
            changeMenu.BackwardScene();
        }
        counter--;
        interactionEvents.updateText(counter);
    }

    public void updateCounter()
    {
        counter++;
        interactionEvents.updateText(counter);
    }
}

