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

/// <summary>
/// Class used to manage the scene configuration.
/// </summary>
public class LabyrinthSceneManager : MonoBehaviour
{
    GameObject selectedRobot;
    [SerializeField] private Transform startPoint; // Is the point from which the selected robot will take its position and rotation.

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        SetUpSelectedRobot();
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
    }
}
