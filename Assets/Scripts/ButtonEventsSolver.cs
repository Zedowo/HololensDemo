using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonEventsSolver : MonoBehaviour
{
    public int counter = 0;
    SolverEvents solverEvents;
    ChangeMenu changeMenu;
    public GameObject navigationMenu;

    void Awake()
    {
        solverEvents = navigationMenu.GetComponent<SolverEvents>();
        changeMenu = navigationMenu.GetComponent<ChangeMenu>();
    }

    public void backCounter()
    {
        if (counter == 0)
        {
            changeMenu.BackwardScene();
        }
        counter--;
        solverEvents.updateText(counter);
    }

    public void updateCounter()
    {
        counter++;
        solverEvents.updateText(counter);
    }

    public void updateCounterNeutral()
    {
        counter++;
    }
}
