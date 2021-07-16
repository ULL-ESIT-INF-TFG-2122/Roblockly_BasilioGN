/**
* Universidad de La Laguna
* Author: Basilio Gómez Navarro
* Email: alu0101049151@ull.edu.es
* Date: 07/05/2021
* File: IndividualSelectionSceneManager.cs : This file contains the 
*       "IndividualSelectionSceneManager" class implementation. This class is
*       used to manage the selection of the robots for the individual 
*       challenges.
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Class used to manage the "Individual Robot Selection" scene.
/// </summary>
public class IndividualSelectionSceneManager : MonoBehaviour
{
    private GameObject Platform; // Is the rotating platform.
    private GameObject CurrentRobot; // Is the robot that is currently rotating 
                                     // on the platform
    public float RotationSpeed = 5;

    public delegate void SetSceneActive(bool activeCanvas);
    public static SetSceneActive SetActiveSceneCanvas;
    
    void Start()
    {
        Platform = GameObject.FindWithTag("RotatingPlatform");
    }

    void Update()
    {   // Procedure to rotate the platform and the robot on it.
        CurrentRobot = GameObject.FindWithTag("CurrentRobot");
        Platform.transform.Rotate(Vector3.up * RotationSpeed * Time.deltaTime);
        CurrentRobot.transform.Rotate(Vector3.up * RotationSpeed * Time.deltaTime);
    }

    /// <summary>
    /// Method used to manage the transition between the 
    /// "IndividualSelectionScene" to the "MainMenu" scene.
    /// </summary>
    public void GoBack ()
    {
        // Load the previous level in the queue (in this case, is the scene 0, called "MainMenu").
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    /// <summary>
    /// Method used to manage the transition between the 
    /// "IndividualSelectionScene" to the "IndividualSensorSelection" scene.
    /// </summary>
    public void GoForward ()
    {
        // SetActiveSceneCanvas(true);
        // Load the next level in the queue (in this case, is the scene 1, called "IndividualSensorSelection").
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}


