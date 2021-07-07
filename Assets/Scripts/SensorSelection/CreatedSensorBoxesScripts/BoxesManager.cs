/**
* Universidad de La Laguna
* Author: Basilio Gómez Navarro
* Email: alu0101049151@ull.edu.es
* Date: 27/06/2021
* File: BoxesManager.cs : This file contains the logic to spawn the boxes of 
* each sensor on the right box of the UI.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoxesManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// This function is called when the object becomes enabled and active.
    /// </summary>
    void OnEnable()
    {
        SnapController.CreateNewAddedSensorBox += OnActivation;
    }

    /// <summary>
    /// This function is called when a sensor is added to the robot in order to 
    /// spawn the box on the "Sensors Added" box on the right part of the UI.
    /// </summary>
    private void OnActivation(DragObject selectedSensor)
    {
        bool activated = false;
        int i = 0;
        string sensorType = NewBoxName(selectedSensor);
        //string auxText;
        while ((!activated) && (i < transform.childCount)) 
        {
            if ((!transform.GetChild(i).gameObject.activeSelf) && (transform.GetChild(i).gameObject.tag == "AddedSensorBox"))
            {
                transform.GetChild(i).gameObject.SetActive(true);
                /*auxText = transform.GetChild(i).gameObject.transform.GetChild(0).gameObject.GetComponent<TMPro.TextMeshProUGUI>().text;
                Debug.Log("auxText = " + auxText);*/
                transform.GetChild(i).gameObject.transform.GetChild(0).gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = "Sensor " + (i + 1) + ": " + sensorType;
                activated = true;
            } else {
                i++;
            }
        }
    }

    private string NewBoxName(DragObject selectedSensor)
    {
        string nameToReturn;
        switch (selectedSensor.name)
        {
            case "SensorUS(Clone)":
                nameToReturn = "Ultrasonido";
                break;
            case "SensorTouch(Clone)":
                nameToReturn = "Contacto";
                break;
            case "SensorIR(Clone)":
                nameToReturn = "Infrarrojo";
                break;
            case "SensorColor(Clone)":
                nameToReturn = "Color";
                break;
            default:
                nameToReturn = "NewSensor";
                break;
        }
        return nameToReturn;
    }
}
