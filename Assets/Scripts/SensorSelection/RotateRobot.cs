/**
* Universidad de La Laguna
* Author: Basilio Gómez Navarro
* Email: alu0101049151@ull.edu.es
* Date: 11/06/2021
* File: RotateRobot.cs : This file contains the code to allow the user to 
*                        rotate the robot by dragging it with the mouse.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateRobot : MonoBehaviour
{
    public float RotationSpeed = 50;

    /// <summary>
    /// OnMouseDrag is called when the user has clicked on a GUIElement or 
    /// Collider and is still holding down the mouse.
    /// </summary>
    void OnMouseDrag()
    {
        float rotX = Input.GetAxis("Mouse X") * RotationSpeed * Mathf.Deg2Rad;
        //float rotY = Input.GetAxis("Mouse Y") * RotationSpeed * Mathf.Deg2Rad;

        transform.Rotate(Vector3.up, -rotX);
        //transform.Rotate(Vector3.right, rotY);
    }

}
