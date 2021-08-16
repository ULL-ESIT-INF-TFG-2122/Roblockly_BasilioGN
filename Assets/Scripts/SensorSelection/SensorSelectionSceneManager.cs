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
    //public delegate void SetEnableCanvas(bool isActiveCanvas);
    //public static SetEnableCanvas SetCanvasActive;
    //private GameObject canvas;
    private GameObject selectedRobot;
    private GameObject rotatingPlatform;
    private bool settedUp = false;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        //canvas = GameObject.Find("SensorBackContinueUI");
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        if (selectedRobot == null)
        {
            selectedRobot = GameObject.FindWithTag("SelectedRobot");
            SetUpSelectedRobot();
        }
    }

    /// <summary>
    /// This method sets up the robot position and rotation at the start 
    /// method of the scene
    /// </summary>
    void SetUpSelectedRobot()
    {
        rotatingPlatform = GameObject.Find("RotatingPlatform");
        selectedRobot.transform.position = rotatingPlatform.transform.position;
        float XPosCoord = selectedRobot.transform.position.x;
        float YPosCoord = selectedRobot.transform.position.y;
        float ZPosCoord = selectedRobot.transform.position.z;   
        selectedRobot.transform.position = new Vector3(XPosCoord - 10, YPosCoord + 10, ZPosCoord + 10);
        selectedRobot.transform.rotation = rotatingPlatform.transform.rotation;
    }

    /// <summary>
    /// Method used to manage the transition between the 
    /// "IndividualSensorSelection" to the "IndividualSelectionMenu" scene.
    /// </summary>
    public void GoBack ()
    {   
        Finder.RemoveElementByTag("SelectedRobot");
        DestroySelectedRobot();
        //GlobalSceneManager.SwitchOnSecene3(false);
        //SetCanvasActive(false);
        // Load the previous level in the queue (in this case, is the scene 1, called "IndividualSelectionMenu").
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    /// <summary>
    /// Method used to manage the transition between the 
    /// "IndividualSensorSelection" to the "RobotProgramming" scene.
    /// </summary>
    public void GoForward ()
    {
        //GlobalSceneManager.SwitchOnSecene3(false);
        // Load the next level in the queue (in this case, is the scene 3, called "RobotProgramming").
        int sceneIndex = PlayerPrefs.GetInt("SelectedChallenge");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + sceneIndex);
    }

    private void DestroySelectedRobot()
    {
        GameObject auxRobot = GameObject.FindWithTag("SelectedRobot");
        if (auxRobot != null)
        {
            Destroy(auxRobot);
        } else {
            Debug.LogError("There is not any \"SelectedRobot\" currently");
        }
    }
}
