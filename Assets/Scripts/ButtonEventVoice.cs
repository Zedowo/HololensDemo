using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonEventVoice: MonoBehaviour
{
    public int counter = 0;
    VoiceCommandEvents voiceCommandEvents;
    ChangeMenu changeMenu;
    public GameObject navigationMenu;

    void Awake()
    {
        voiceCommandEvents = navigationMenu.GetComponent<VoiceCommandEvents>();
        changeMenu = navigationMenu.GetComponent<ChangeMenu>();
    }

    public void backCounter()
    {
        if (counter == 0)
        {
            changeMenu.BackwardScene();
        }
        counter--;
        voiceCommandEvents.updateText(counter);
    }

    public void updateCounter()
    {
        counter++;
        voiceCommandEvents.updateText(counter);
    }

}
