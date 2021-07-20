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
}
