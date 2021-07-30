/**
* Universidad de La Laguna
* Author: Basilio Gómez Navarro
* Email: alu0101049151@ull.edu.es
* Date: 26/07/2021
* File: LabyrinthSeceneManager.cs : This file contains the 
*       "LabyrinthSceneManager" class implementation which allows the 
*        configuration of some stuff of the scene as:
*           - Set the position of the selectedRobot gameobject.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Class used to manage the scene configuration.
/// </summary>
public class LabyrinthSceneManager : MonoBehaviour
{
    private GameObject selectedRobot;
    [SerializeField] private Transform startPoint; // Is the point from which the selected robot will take its position and rotation.
    private float DEFALUT_WIDTH = 300.0f;
    private float DEFAULT_HEIGHT = 200.0f;
    private GameObject challengeViewer;
    private GameObject mainCanvas;

    public Camera robotCamera;


    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        robotCamera = robotCamera.GetComponent<Camera>();
        SetUpSelectedRobot();
        challengeViewer = GameObject.Find("Canvas/ChallengeViewer");
        mainCanvas = GameObject.Find("Canvas");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// This method sets up the robot position and rotation at the start 
    /// method of the scene
    /// </summary>
    void SetUpSelectedRobot()
    {
        selectedRobot = GameObject.FindWithTag("SelectedRobot");
        selectedRobot.transform.position = startPoint.position;
        float XPosCoord = selectedRobot.transform.position.x;
        float YPosCoord = selectedRobot.transform.position.y;
        float ZPosCoord = selectedRobot.transform.position.z;   
        selectedRobot.transform.position = new Vector3(XPosCoord, YPosCoord + 10, ZPosCoord);
        selectedRobot.transform.rotation = startPoint.rotation;
        selectedRobot.GetComponent<RobotManager>().Kinematic(false); // Enables robot physics again.
    }

    /// <summary>
    /// Method used to manage the transition between the 
    /// "IndividualSelectionScene" to the "MainMenu" scene.
    /// </summary>
    public void GoBack ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void changeImageScale()
    {
        RectTransform canvasRect = mainCanvas.GetComponent<RectTransform>();
        RectTransform challengeViewerRect = challengeViewer.GetComponent<RectTransform>();
        RectTransform cameraRect = robotCamera.GetComponent<RectTransform>();
        float canvasWidth = canvasRect.rect.width;
        float canvasHeight = canvasRect.rect.height;
        float challengeWidth = challengeViewerRect.rect.width;
        float challengeHeight = challengeViewerRect.rect.height;
        if((challengeWidth != canvasWidth) && (challengeHeight != canvasHeight))
        {
            challengeViewerRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, canvasHeight);
            challengeViewerRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, canvasWidth);
        } else {
            challengeViewerRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, DEFAULT_HEIGHT);
            challengeViewerRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, DEFALUT_WIDTH);
        }
    }

}
