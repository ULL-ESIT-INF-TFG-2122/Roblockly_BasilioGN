﻿/**
* Universidad de La Laguna
* Project: Roblockly
* Author: Basilio Gómez Navarro
* Email: alu0101049151@ull.edu.es
* File: SensorUS.cs : This file contains the "SensorUS" class implementation. 
*       This class is used to manage any logic of the Ultrasound sensor type.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class used to manage any logic of the Ultrasound sensor type.
/// </summary>
public class SensorUS : SensorGeneric
{
    private float range;
    private float error;

    private GameObject coneCollider;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        coneCollider = gameObject.transform.Find("ConeCollider").gameObject;
    }

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
      SnapController.SetLinkedToARobotOn += base.SetLinkSensor;
      SnapControllerDefender.SetLinkedToARobotOn += base.SetLinkSensor;
      SnapControllerHummer.SetLinkedToARobotOn += base.SetLinkSensor;
      SnapControllerHunter.SetLinkedToARobotOn += base.SetLinkSensor;
    }

    /// <summary>
    /// Sets the sensor name adding the sensor type
    /// </summary>
    /// <param name="snapPoint"> The of the snap point position.</param>
    public override void SetSensorName(string snapPoint)
    {
        base.SetSensorName(snapPoint);
        gameObject.transform.name = gameObject.transform.name + "Ultrasonido";
        base.StoreSensorName(gameObject.transform.name);
    }

    public float GetDistance()
    {
      float value = coneCollider.GetComponent<ConeCollider>().GetCollidedDistance();
      return value;
    }
}
