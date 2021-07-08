/**
* Universidad de La Laguna
* Author: Basilio Gómez Navarro
* Email: alu0101049151@ull.edu.es
* Date: 07/06/2021
* File: SnapController.cs : This file contains the 
*       "SnapController" class implementation. This class is
*       used to manage the snap point to fix the selected sensors
*       to each robot.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class used to manage the different snap points of each robot.
/// </summary>
public class SnapController : MonoBehaviour
{                                       
    public List<Transform> SnapPoints; // Contains all the snap points of each 
                                       // robot.
    public float SnapRange = 2.0f;
    //bool HasSnappedSensor = false;
    DragObject[] SensorsToDrag; // Contains all the draggable
                                // sensors;
    // public GameObject[] AddedSensorBoxes;
    public delegate void CreateAddedSensorBox(DragObject sensorOfTheBox);
    public static event CreateAddedSensorBox CreateNewAddedSensorBox;

    private List<Transform> UsedSnapPoints = new List<Transform>();

    // Start is called before the first frame update
   void Start()
    {
        //AddedSensorBoxes = GameObject.FindGameObjectsWithTag("AddedSensorBox");
        /*foreach (DragObject currentSensor in SensorsToDrag)
        {
            currentSensor.DragFinished = OnDragEnded;
        }*/
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        AddNewSensor();
    }

    /// <summary>
    /// AddNewSensor is called in every frame on the Update loop to check if
    /// a new sensor has been created.
    /// </summary>
    private void AddNewSensor()
    {
        SensorsToDrag = Object.FindObjectsOfType<DragObject>(); // Looks for 
                                                    // each new added sensor.
        if (SensorsToDrag.Length > 0)
        {
            for (int i = 0; i < SensorsToDrag.Length; i++)
            {
                if (SensorsToDrag[i].tag == "NewSensor")
                {
                    SensorsToDrag[i].tag = "NotNewSensor";
                    SensorsToDrag[i].DragFinished = OnDragEnded;
                }
            }
        }
    }

    /// <summary>
    /// OnDragEnded is called when the mouse up event occurs and consequently, 
    /// the dragg process finish.
    /// </summary>
    private void OnDragEnded(DragObject sensorToDrag)
    {
        float ClosestDistance = -1;
        Transform ClosestSnapPoint = null;
        foreach (Transform currentSnapPoint in SnapPoints)
        {
            float currentDistance = Vector3.Distance(sensorToDrag.transform.position, currentSnapPoint.transform.position);
            if (ClosestSnapPoint == null || currentDistance < ClosestDistance)
            {
                ClosestSnapPoint = currentSnapPoint;
                ClosestDistance = currentDistance;
            }
        }

        bool used = false; // Auxiliary variable to check if the closest snap 
                           // point has been used.
        if (UsedSnapPoints.Count > 0)
        {
            //Debug.Log("UsedSanpPoints.Count: " + UsedSnapPoints.Count);
            for (int i = 0; i < UsedSnapPoints.Count; i++)
            {
                if(UsedSnapPoints[i] == ClosestSnapPoint)
                {
                    used = true;
                }
            }
        }

        if (!used) // If the Closest Sanp Point is free
        {
            Debug.Log("ClosestSnapPoint = " + ClosestSnapPoint);
            Debug.Log("ClosestDistance = " + ClosestDistance);

            if ((ClosestSnapPoint != null) && (ClosestDistance <= SnapRange))
            { // If the snap was successful:
                UsedSnapPoints.Add(ClosestSnapPoint);
                Debug.Log("Ha hecho el snap");
                switch (sensorToDrag.name)
                {
                    case "SensorUS(Clone)":
                        SetUltrasoundSensor(sensorToDrag, ClosestSnapPoint);
                        break;
                    case "SensorTouch(Clone)":
                        SetTouchSensor(sensorToDrag, ClosestSnapPoint);
                        break;
                    case "SensorIR(Clone)":
                        break;
                    case "SensorColor(Clone)":
                        break;
                    default:
                        Debug.Log("There aren't any sensor of this type");
                        break;
                }
                sensorToDrag.transform.parent = gameObject.transform;
                CreateNewAddedSensorBox(sensorToDrag);
                //CreateAddedSensorBox();
            }
            else // If the sensor doesn't snaps any point.
            {
                Destroy(sensorToDrag.gameObject);
            }
        }
        else // If the sensor doesn't snaps any point.
        {
            Destroy(sensorToDrag.gameObject);
        }
    }

    /// <summary>
    /// This method is used to set up the position of any Ultrasound sensor 
    /// when it is snapped to the robot.
    /// </summary>
    private void SetUltrasoundSensor(DragObject sensorToDrag, Transform ClosestSnapPoint)
    {
        //Debug.Log ("Es un sensor de ultrasonido");
        //====== Position transform ================================
        sensorToDrag.transform.position = ClosestSnapPoint.transform.position;
        float XPosCoord = sensorToDrag.transform.position.x;
        float YPosCoord = sensorToDrag.transform.position.y;
        float ZPosCoord = sensorToDrag.transform.position.z;
        float offset = 3f;
        sensorToDrag.transform.position = new Vector3(XPosCoord, YPosCoord + offset, ZPosCoord);

        //====== Rotation transform ================================
        sensorToDrag.transform.rotation = ClosestSnapPoint.transform.rotation;
        switch (ClosestSnapPoint.tag)
        {
            case "FrontSnap":
                sensorToDrag.transform.Rotate(0.0f, 90.0f, 0.0f);
                break;
            case "BackSnap":
                sensorToDrag.transform.Rotate(0.0f, -90.0f, 0.0f);
                break;
            case "LeftSnap":
                sensorToDrag.transform.Rotate(0.0f, 180.0f, 0.0f);
                break;
            default: // There is no right sensor because initial sensor         
                     // rotation is clockwise by default.
                sensorToDrag.transform.Rotate(0.0f, 0.0f, 0.0f);
                break;
        }
    }
    
    /// <summary>
    /// This method is used to set up the position of any Touch sensor 
    /// when it is snapped to the robot.
    /// </summary>
    private void SetTouchSensor(DragObject sensorToDrag, Transform ClosestSnapPoint)
    {
        //====== Position transform ================================
        sensorToDrag.transform.position = ClosestSnapPoint.transform.position;
        float XPosCoord = sensorToDrag.transform.position.x;
        float YPosCoord = sensorToDrag.transform.position.y;
        float ZPosCoord = sensorToDrag.transform.position.z;
        float offset;

        //====== Rotation transform ================================
        sensorToDrag.transform.rotation = ClosestSnapPoint.transform.rotation;
        switch (ClosestSnapPoint.tag)
        {
            case "FrontSnap":
                offset = 1.5f;
                sensorToDrag.transform.position = new Vector3(XPosCoord, YPosCoord + offset, ZPosCoord);
                sensorToDrag.transform.Rotate(0.0f, 90.0f, 0.0f);
                break;
            case "TopFrontSnap":
                offset = 1.5f;
                sensorToDrag.transform.position = new Vector3(XPosCoord, YPosCoord + offset, ZPosCoord);
                sensorToDrag.transform.Rotate(-5.0f, 4.0f, 0.0f);
                break;
            case "BackSnap":
                offset = 1.5f;
                sensorToDrag.transform.position = new Vector3(XPosCoord, YPosCoord + offset, ZPosCoord);
                sensorToDrag.transform.Rotate(0.0f, -90.0f, 0.0f);
                break;
            case "LeftSnap":
                offset = 0.5f;
                sensorToDrag.transform.position = new Vector3(XPosCoord, YPosCoord + offset, ZPosCoord);
                sensorToDrag.transform.Rotate(0.0f, 0.0f, -60.0f);
                break;
            default: // There is no right sensor because initial sensor         
                     // rotation is clockwise by default.
                offset = 0.5f;
                sensorToDrag.transform.position = new Vector3(XPosCoord, YPosCoord + offset, ZPosCoord);
                sensorToDrag.transform.Rotate(0.0f, 90.0f, -60.0f);
                break;
        }
    }



    /*void CreateNewAddedSensorBox(DragObject sensorOfTheBox)
    {
        Debug.Log("Ha entrado en el CreateAddedSensorBox");
        Debug.Log(AddedSensorBoxes);

        if (AddedSensorBoxes.Length == 0)
        {
            Debug.Log("Está vacio");
        }
        foreach (GameObject CurrentBox in AddedSensorBoxes)
        {
            Debug.Log("Ha entrado en el for");
            if (!CurrentBox.activeSelf)
            {
                Debug.Log("Ha entrado en el if");
                CurrentBox.SetActive(true);
            }
        }
    }*/
}
