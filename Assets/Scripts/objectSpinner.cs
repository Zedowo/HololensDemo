using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectSpinner : MonoBehaviour
{
    private bool rotation = false;
    public GameObject objectRotation;
    private float currentDegree = 0;

    public void enableRotation()
    {
        rotation = true;
        StartCoroutine(spinCube());
    }

    public void disableRotation()
    {
        rotation = false;
        objectRotation.transform.Rotate(0f, 0f, 0f);
    }

    /*void Update()
    {
        if (rotation)
        {
            this.updateDegree();
            objectRotation.transform.Rotate(0f, currentDegree, 0f);
        }*/
    

    IEnumerator spinCube()
    {
        while (rotation)
        {
        this.updateDegree();
        yield return new WaitForSeconds(0.05f);
        objectRotation.transform.Rotate(0f, currentDegree, 0f);
        }
    }

    public void updateDegree()
    {
        if (currentDegree >= 360)
        {
            currentDegree = 0;
        }
        currentDegree += 0.3f;
    }

}
