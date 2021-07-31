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

    // Variables used for the rescale of the challengeViewer.
    private RectTransform canvasRect;
    private RectTransform challengeViewerRect;
    private float canvasWidth;
    private float canvasHeight;
    private float firstChallengeWidth;
    private float firstChallengeHeight;
    private Vector3 originalChallengeViewerPos;
    private Vector3 mainCanvasPosition;
    private GameObject maximizeButton;
    private RectTransform maximizeButtonRect;
    private Vector3 maximizeButtonInitPos;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        SetUpSelectedRobot();
        challengeViewer = GameObject.Find("Canvas/ChallengeViewer");
        maximizeButton = GameObject.Find("Canvas/MaximizeButton");
        mainCanvas = GameObject.Find("Canvas");
        changeImageScaleSetUp();
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

    public void changeImageScaleSetUp()
    {
        canvasRect = mainCanvas.GetComponent<RectTransform>();
        challengeViewerRect = challengeViewer.GetComponent<RectTransform>();
        maximizeButtonRect = maximizeButton.GetComponent<RectTransform>();
        canvasWidth = canvasRect.rect.width;
        canvasHeight = canvasRect.rect.height;
        firstChallengeWidth = challengeViewerRect.rect.width;
        firstChallengeHeight = challengeViewerRect.rect.height;
        originalChallengeViewerPos = challengeViewer.transform.position;
        mainCanvasPosition = mainCanvas.transform.position;
        maximizeButtonInitPos = maximizeButton.transform.position;
    }

    public void changeImageScale()
    {
        float challengeWidth = challengeViewerRect.rect.width;
        float challengeHeight = challengeViewerRect.rect.height;
        if((challengeWidth != canvasWidth) && (challengeHeight != canvasHeight))
        {
            challengeViewerRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, canvasHeight);
            challengeViewerRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, canvasWidth);
            challengeViewer.transform.position = mainCanvasPosition;
            float buttonOffset = (maximizeButtonRect.rect.width / 2);
            float auxWidth = (-canvasWidth/2);
            float auxHeight = (canvasHeight/2);
            Debug.Log ("auxWidth: " + auxWidth + " auxHeigth: " + auxHeight);
            float z = canvasRect.position.z;
            maximizeButtonRect.localPosition = new Vector3(auxWidth + buttonOffset, auxHeight - buttonOffset, canvasRect.position.z);
            //maximizeButton.transform.position = new Vector3((-canvasWidth/2), (canvasHeight/2), originalChallengeViewerPos.z);
        } else {
            challengeViewerRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, firstChallengeHeight);
            challengeViewerRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, firstChallengeWidth);
            challengeViewer.transform.position = originalChallengeViewerPos;
            maximizeButton.transform.position = maximizeButtonInitPos;
        }
    }
}
