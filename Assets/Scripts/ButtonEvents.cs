using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonEvents : MonoBehaviour
{
    public int counter = 0;
    private TestTextChange scriptChanger;

    void start()
    {
        scriptChanger = GameObject.FindObjectOfType<TestTextChange>();
    }

    // Start is called before the first frame update

    public void updateCounter()
    {
        counter++;
        scriptChanger.updateText(counter);
    }


}
