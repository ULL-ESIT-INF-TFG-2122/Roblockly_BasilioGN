/**
* Universidad de La Laguna
* Author: Basilio Gómez Navarro
* Email: alu0101049151@ull.edu.es
* Date: 20/07/2021
* File: SensorTouch.cs : This file contains the 
*       "SensorTouch" class implementation. This class is
*       used to manage any logic of the Touch sensor type.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class used to manage any logic of the Touch sensor type.
/// </summary>
public class SensorTouch : SensorGeneric
{
    private bool contact = false;
    // Start is called before the first frame update
    void Start()
    {
        SnapController.SetLinkedToARobotOn += base.SetLinkSensor;
    }

    public override void SetSensorName(string snapPoint)
    {
        base.SetSensorName(snapPoint);
        gameObject.transform.name = gameObject.transform.name + "Contacto";
        base.StoreSensorName(gameObject.transform.name);
    }

    /// <summary>
    /// OnCollisionEnter is called when this collider/rigidbody has begun
    /// touching another rigidbody/collider.
    /// </summary>
    /// <param name="other">The Collision data associated with this collision.</param>
    void OnCollisionEnter(Collision other)
    {
        Debug.Log("ha hecho contacto!");
        if (other.gameObject.tag != "SelectedRobot")
        {
            contact = true;    
        }
    }

    /// <summary>
    /// OnCollisionExit is called when this collider/rigidbody has
    /// stopped touching another rigidbody/collider.
    /// </summary>
    /// <param name="other">The Collision data associated with this collision.</param>
    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag != "SelectedRobot")
        {
            contact = false;
        }
    }

    public bool GetContact()
    {
        return contact;
    }

}
