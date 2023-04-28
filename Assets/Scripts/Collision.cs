using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    public GameObject moveCube;
    DemoEvents demoEvents;
    public GameObject navigationMenu;

    void Awake()
    {
        demoEvents = navigationMenu.GetComponent<DemoEvents>();
    }

    void Update()
    {
        if (transform.rotation.z <= 0.51)
        {
            demoEvents.collisionRequirement();
        }
    }
}
