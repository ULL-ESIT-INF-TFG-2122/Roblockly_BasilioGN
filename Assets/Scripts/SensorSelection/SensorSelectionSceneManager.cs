/**
* Universidad de La Laguna
* Author: Basilio Gómez Navarro
* Email: alu0101049151@ull.edu.es
* Date: 05/06/2021
* File: SensorSelectionSceneManager.cs : This file contains the 
*       "SensorSelectionSceneManager" class implementation. This class is
*       used to manage the buttons to move from this scene to another.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


/// <summary>
/// Class used to manage the "Individual Sensor Selection" scene.
/// </summary>
public class SensorSelectionSceneManager : MonoBehaviour
{
    // 
    public delegate void SetEnableCanvas(bool isActiveCanvas);
    public static SetEnableCanvas SetCanvasActive;
    private GameObject canvas;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        canvas = GameObject.Find("SensorBackContinueUI");
    }

    /// <summary>
    /// Method used to manage the transition between the 
    /// "IndividualSensorSelection" to the "IndividualSelectionMenu" scene.
    /// </summary>
    public void GoBack ()
    {   
        SetCanvasActive(false);
        // Load the previous level in the queue (in this case, is the scene 1, called "IndividualSelectionMenu").
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);

    }

    /// <summary>
    /// Method used to manage the transition between the 
    /// "IndividualSensorSelection" to the "RobotProgramming" scene.
    /// </summary>
    public void GoForward ()
    {
        // Load the next level in the queue (in this case, is the scene 3, called "RobotProgramming").
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
