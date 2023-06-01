using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NavigateScene : MonoBehaviour
{
   public void basicsNavigation()
    {
        SceneManager.LoadScene(1);
    }

    public void voiceNavigation()
    {
        SceneManager.LoadScene(2);
    }

    public void objectNavigation()
    {
        SceneManager.LoadScene(3);
    }

    public void constraintsNavigation()
    {
        SceneManager.LoadScene(4);
    }

    public void interactionsNavigation()
    {
        SceneManager.LoadScene(5);
    }

    public void solversNavigation()
    {
        SceneManager.LoadScene(6);
    }

    public void tapToPlaceNavigation()
    {
        SceneManager.LoadScene(7);
    }
}
