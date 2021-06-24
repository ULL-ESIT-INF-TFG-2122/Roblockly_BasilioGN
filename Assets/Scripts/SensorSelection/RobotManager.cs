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
    // Start is called before the first frame update
    void Start()
    {
        CheckInclinometer.CheckboxInclinometer = InclinometerActivation;
        CheckMicrophone.CheckboxMicrophone = MicrophoneActivation;
    }

    // Update is called once per frame
    void Update()
    {
        
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
}
