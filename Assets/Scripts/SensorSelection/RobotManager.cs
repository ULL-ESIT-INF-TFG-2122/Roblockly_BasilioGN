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
using UnityEngine.SceneManagement;

public class RobotManager : MonoBehaviour
{
    private bool Gyroscope = false; // True if the user click on 
                                       // "giróscopo" checkbox.
    private bool Microphone = false; // True if the user click on 
                                     // "microphone" checkbox.
    private GameObject BalanceSphere; // Is the sphere under the platform of the "BalanceChallenge".
    
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
        CheckGyroscope.CheckboxGyroscope = GyroscopeActivation;
        CheckMicrophone.CheckboxMicrophone = MicrophoneActivation;
        CheckGyroscope.DeactivateGyroscope = GyroscopeDeactivation;
    }

    public void GyroscopeActivation()
    {
        Gyroscope = true;
        AddUsedSensor("Gyroscope", "Gyroscope");
        Debug.Log("Gyroscope");
    }

    public void GyroscopeDeactivation()
    {
        Gyroscope = false;
        DeleteSensorFromUsedSensors("Gyroscope");
    }

    public void MicrophoneActivation() // Not used
    {
        Microphone = true;
        AddUsedSensor("Microphone", "Microphone");
        //Debug.Log("Microphone");
    }

    public void MicrophoneDeactivation() // Not used
    {
        Microphone = false;
        DeleteSensorFromUsedSensors("Microphone");
    }

    /// <summary>
    /// This function is called when the behaviour becomes disabled or inactive.
    /// </summary>
    void OnDisable()
    {
        CheckGyroscope.CheckboxGyroscope -= GyroscopeActivation;
        CheckMicrophone.CheckboxMicrophone -= MicrophoneActivation;
        CheckGyroscope.DeactivateGyroscope -= GyroscopeDeactivation;
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

    public bool GetTouchInfo(string touchSensorToFind)
    {
        GameObject sensorToFind;
        string sensorNameToFind = "Sensor " + touchSensorToFind + ": Contacto";
        Debug.Log("SensorToFind " + sensorNameToFind);
        sensorToFind = transform.Find(sensorNameToFind).gameObject;
        return sensorToFind.GetComponent<SensorTouch>().GetContact();
    }

    public bool GetIRInfo(string iRSensorToFind, string colorToDetect)
    {
        GameObject sensorToFind;
        string sensorNameToFind = "Sensor " + iRSensorToFind + ": Infrarrojo";
        sensorToFind = transform.Find(sensorNameToFind).gameObject;
        return sensorToFind.GetComponent<SensorIR>().DetectColor(colorToDetect);
    }
    
    public bool GetColorInfo(string colorSensorToFind, string colorToDetect)
    {
        GameObject sensorToFind;
        string sensorNameToFind = "Sensor " + colorSensorToFind + ": Color";
        sensorToFind = transform.Find(sensorNameToFind).gameObject;
        return sensorToFind.GetComponent<SensorColor>().DetectColor(colorToDetect);
    }

    public float GetUSInfo(string uSSensorToFind)
    {
        GameObject sensorToFind;
        string sensorNameToFind = "Sensor " + uSSensorToFind + ": Ultrasonido";
        sensorToFind = transform.Find(sensorNameToFind).gameObject;
        float distance = sensorToFind.GetComponent<SensorUS>().GetDistance();
        return distance;
    }

    public bool GetGyroscopeInfo(string direction)
    {
        if ((SceneManager.GetActiveScene().name == "BalanceChallenge") && (Gyroscope))
        {
            string status = GyroscopeBehavior();
            if (status == direction)
            {
                return true;
            }
        }
        return false;
    }

    private string GyroscopeBehavior()
    {
        BalanceSphere = GameObject.Find("BaseSphere");
        if ((SceneManager.GetActiveScene().name == "BalanceChallenge") &&     
            (Gyroscope))
        {
            if (!CheckParallel())
            {
                if (CheckAngle())
                {
                    return "forward";
                } else {
                    return "backward";
                }
            }
        }
        return "parallel";
    }

    private bool CheckParallel()
    {
        Vector3 SphereRobotVector = (transform.position - BalanceSphere.transform.position).normalized;
        Vector3 SphereUp = BalanceSphere.transform.up;
        float alignment = ((SphereUp.x * SphereRobotVector.x) + 
                           (SphereUp.y * SphereRobotVector.y) +
                           (SphereUp.z * SphereRobotVector.z));
        alignment = Mathf.Round(alignment);
        if (alignment == 1.0f) // If 1 -> Parallel, 0 -> Normal, -1 -> Other position.
        {
            return true;
        }
        return false;
    }

    private bool CheckAngle()
    {
        Vector3 SphereRobotVector = (transform.position - BalanceSphere.transform.position).normalized;
        Vector3 SphereForward = BalanceSphere.transform.forward;
        float planeRobotAngle = Vector3.Angle(SphereForward, SphereRobotVector);
        if (planeRobotAngle < 0.0f)
        {
            return true; // Robot is moving forward
        }
        return false; // Robot is moving backward
    }
}
