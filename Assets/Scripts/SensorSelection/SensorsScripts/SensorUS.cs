/**
* Universidad de La Laguna
* Author: Basilio Gómez Navarro
* Email: alu0101049151@ull.edu.es
* Date: 20/07/2021
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

    // Start is called before the first frame update
    void Start()
    {
      SnapController.SetLinkedToARobotOn += base.SetLinkSensor;
    }

    /*public void ActivateUS()
    {
        transform.gameObject.SetActive(transform.gameObject.tag == "SensorUS");
    }*/

    public override void SetSensorName(string snapPoint)
    {
        base.SetSensorName(snapPoint);
        gameObject.transform.name = gameObject.transform.name + "Ultrasonido";
        base.StoreSensorName(gameObject.transform.name);
    }
}
