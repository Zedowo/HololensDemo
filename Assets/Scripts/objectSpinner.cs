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
        this.transform.rotation = Quaternion.Euler(-90f, 0f, 0f);
    }

   /* public float rotationSpeed = 1.0f;
    public float cycleDuration = 5.0f;

    private Quaternion startRotation;
    private Quaternion targetRotation;
    private float timer = 0.0f;

    private void Start()
    {
        // Initialize start and target rotations
        startRotation = transform.rotation;
        targetRotation = Quaternion.Euler(0.0f, 360.0f, 0.0f) * startRotation;
    }

    private void Update()
    {
        while (rotation) {
            // Increment timer based on deltaTime
            timer += Time.deltaTime;

            // Calculate t value for lerp based on the current timer and cycle duration
            float t = Mathf.PingPong(timer / cycleDuration, 1.0f);

            // Interpolate between start and target rotations using Quaternion.Lerp
            Quaternion newRotation = Quaternion.Lerp(startRotation, targetRotation, t);

            // Apply the new rotation to the object
            transform.rotation = newRotation;
        }
        
    }*/

    /* void Update()
     {
         *//*if (rotation)
         {
             this.updateDegree();
             objectRotation.transform.Rotate(0f, currentDegree, 0f);
         }*//*

         if (rotation) {
             Vector3 direction = new Vector3(0f, 360f, 0f);
             Quaternion targetRotation = Quaternion.Euler(direction);
             this.transform.rotation = Quaternion.Lerp(this.transform.rotation, targetRotation, Time.deltaTime * 3);*/
    /*targetRotation = Quaternion.Euler(0, 0, 0);
    this.transform.rotation = Quaternion.Lerp(this.transform.rotation, targetRotation, Time.deltaTime * 3);
    if (this.transform.rotation.y == 180 || this.transform.rotation.y == -180) {
        targetRotation = Quaternion.Euler(0, 0, 0);
        this.transform.rotation = Quaternion.Lerp(this.transform.rotation, targetRotation, Time.deltaTime * 3);
    }
    /*else if (this.transform.rotation.y >= -5)
     {
         direction = new Vector3(0f, 180f, 0f);
     }*/

/*}
      
    }*/
    

    IEnumerator spinCube()
    {
        while (rotation)
        {
        this.updateDegree();
        yield return new WaitForSeconds(0.1f);
        objectRotation.transform.Rotate(0f, 0f, currentDegree);
        }
    }

    public void updateDegree()
    {
        /*if (currentDegree >= 179)
        {
            currentDegree *= -1;
        }*/
        currentDegree += .1f;
    }

}
