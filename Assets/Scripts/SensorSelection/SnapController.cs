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
    public GameObject[] AddedSensorBoxes;
    public delegate void CreateAddedSensorBox(DragObject sensorOfTheBox);
    public CreateAddedSensorBox CreateNewAddedSensorBox;

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

        Debug.Log("ClosestSnapPoint = " + ClosestSnapPoint);
        Debug.Log("ClosestDistance = " + ClosestDistance);

        if ((ClosestSnapPoint != null) && (ClosestDistance <= SnapRange))
        {
            //HasSnappedSensor = true;
            Debug.Log("Ha hecho el snap");
            // TODO: HACER FUNCIONES CON POSICIÓN PARA CADA TIPO DE SENSOR Y AÑADIR SWITCH
            sensorToDrag.transform.position = ClosestSnapPoint.transform.position;
            sensorToDrag.transform.parent = gameObject.transform;
            float XCoordinate = sensorToDrag.transform.position.x;
            float YCoordinate = sensorToDrag.transform.position.y;
            float ZCoordinate = sensorToDrag.transform.position.z;
            float offset = 3f;
            sensorToDrag.transform.position = new Vector3(XCoordinate, YCoordinate + offset, ZCoordinate);
            //CreateNewAddedSensorBox(sensorToDrag);
            //CreateAddedSensorBox();
        } 
        else 
        {
            Destroy(sensorToDrag.gameObject);
        }
    }

    /// <summary>
    /// This method is used to set up the position of any Ultrasound sensor 
    /// when it is snapped to the robot.
    /// </summary>
    private void SetUltrasoundSensor()
    {

    }

    /*void CreateAddedSensorBox()
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
