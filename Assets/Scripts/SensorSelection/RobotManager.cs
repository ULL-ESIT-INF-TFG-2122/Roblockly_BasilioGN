/**
* Universidad de La Laguna
* Author: Basilio Gómez Navarro
* Email: alu0101049151@ull.edu.es
* Date: 18/06/2021
* File: RobotManager.cs : This file contains the 
*       "RobotManager" class implementation. This class is
*       used to manage the robot behaviour.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotManager : MonoBehaviour
{
    private bool Inclinometer = false; // True if the user click on 
                                       // "inclinometro" checkbox.
    private bool Microphone = false; // True if the user click on 
                                     // "microphone" checkbox.
    
    private Dictionary<string, string> usedSensors = new Dictionary<string, string>(); // Save the sensors snapped to the robot to know the blocks to show in the coding panel of the UGUI. This check is carried out in SnapController script and SensorGeneric (DeleteSensor method).

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        Kinematic(true);
    }

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        CheckInclinometer.CheckboxInclinometer = InclinometerActivation;
        CheckMicrophone.CheckboxMicrophone = MicrophoneActivation;
    }

    public void InclinometerActivation()
    {
        Inclinometer = true;
        Debug.Log("Inclinometer");
    }

    public void MicrophoneActivation()
    {
        Microphone = true;
        Debug.Log("Microphone");
    }

    /// <summary>
    /// This function is called when the behaviour becomes disabled or inactive.
    /// </summary>
    void OnDisable()
    {
        CheckInclinometer.CheckboxInclinometer -= InclinometerActivation;
        CheckMicrophone.CheckboxMicrophone -= MicrophoneActivation;
    }

    public void AddUsedSensor(string usedSensor, string usedSensorType)
    {
        if (!usedSensors.ContainsValue(usedSensor))
        {
            usedSensors.Add(usedSensor, usedSensorType);
        }
    }

    public bool CheckSensor(string sensorType)
    {
        if (usedSensors.ContainsValue(sensorType))
        {
            return true;
        }
        return false;
    }

    public void DeleteSensorFromUsedSensors(string usedSensor)
    {
        usedSensors.Remove(usedSensor);
    }

    /// <summary>
    /// Enables or disables the kinematic of the robot.
    /// </summary>
    /// <param name="status"> True for enable or false for disable the robot 
    /// kinematic </param> 
    public void Kinematic(bool status)
    {
        Rigidbody robotRb = GetComponent<Rigidbody>();
        robotRb.isKinematic = status;
    }

    public bool GetTouchInfo(string TouchSensorToFind)
    {
        GameObject sensorToFind;
        string sensorNameToFind = "Sensor " + TouchSensorToFind + ": Contacto";
        Debug.Log("SensorToFind " + sensorNameToFind);
        sensorToFind = transform.Find(sensorNameToFind).gameObject;
        return sensorToFind.GetComponent<SensorTouch>().GetContact();
    }

    public bool GetIRInfo(string IRSensorToFind, string colorToDetect)
    {
        GameObject sensorToFind;
        string sensorNameToFind = "Sensor " + IRSensorToFind + ": Infrarrojo";
        sensorToFind = transform.Find(sensorNameToFind).gameObject;
        return sensorToFind.GetComponent<SensorIR>().DetectColor(colorToDetect);
    }
    
    public bool GetColorInfo(string ColorSensorToFind, string colorToDetect)
    {
        GameObject sensorToFind;
        string sensorNameToFind = "Sensor " + ColorSensorToFind + ": Color";
        sensorToFind = transform.Find(sensorNameToFind).gameObject;
        return sensorToFind.GetComponent<SensorColor>().DetectColor(colorToDetect);
    }
}
