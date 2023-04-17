using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{

    public void LoadFirstScene() {
        SceneManager.LoadScene(1);
    }

    public void LoadSecondScene()
    {
        SceneManager.LoadScene(2);
    }

    public void LoadThirdScene()
    {
        SceneManager.LoadScene(3);
    }

}