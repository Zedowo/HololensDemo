using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.Profiling;
//using Microsoft.MixedReality.Toolkit.SpatialManipulation;
using Microsoft.MixedReality.Toolkit.Utilities.Solvers;
using UnityEngine.SceneManagement;

public class ObjectandBoundEvents : MonoBehaviour
    {
        public TextMeshPro textMesH;
        public GameObject allCube;
        public GameObject mainSlate;
        public GameObject rotationCube;
        public GameObject mainCamera;

        public Follow followMeCube;
        public Follow followMeSlate;

        /*Vector3 originalPosition = new Vector3(0f, 0f, 0f);
        Vector3 leftPosition = new Vector3(-1.071f, 1.905f, 2.096f);
        Vector3 rightCubePosition = new Vector3(0.934f, 1.464f, 2.138f);
        Vector3 restingCubePosition = new Vector3(100f, 100f, 100f);*/

        void Awake()
        {
            //find the textMeshPro object
            textMesH = GetComponent<TextMeshPro>();
            followMeCube = allCube.GetComponent<Follow>();
            followMeSlate = mainSlate.GetComponent<Follow>();
        }

        /*public void printer()
        {
            Debug.Log("Hello World");
        }
 
        public void resetPosition()
        {
            mainCamera.transform.position = originalPosition;
        }*/

        public void updateText(int counter)
        {

            //each case is the next iteration for the next part of the tutorial. Strings combined downwards for readability.
            switch (counter)
            {
                case 0:
                    textMesH.text = "The interactions you performed on the previous page were the result of the scripts, ObjectManipulator, BoundsControl, " +
                    "and ConstraintManager. \r\n\r\n- ObjectManipulator allows you to move, scale, and rotate.\r\n- BoundsControl works in tangent with ObjectManipulator to give " +
                    "each object a border you can manipulate.\r\n- ConstraintManager ensures an object does not get out of hand.";
                    allCube.SetActive(false);
                    break;

                case 1:
                    textMesH.text = "First, let's take a look at a default interaction with all of these componenets -- no constraints added. With this box, you can move it around, change its size, and change its rotation. " +
                    "Adjust the cube however your like. There are no constraints on the object, though you can reset the scene on the Near Menu if things get out of hand. ";
                allCube.SetActive(true);
                break;

                case 2:
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                    break;
         
            }
        }
    }
