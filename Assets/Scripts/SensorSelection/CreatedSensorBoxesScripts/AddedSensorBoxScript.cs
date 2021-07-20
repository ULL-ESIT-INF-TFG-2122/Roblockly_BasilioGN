/**
* "Roblockly: Fostering computational thinking through educational robotics
* Universidad de La Laguna"
* Author: Basilio Gómez Navarro
* Email: alu0101049151@ull.edu.es
* Date: 25/06/2021
* File: AddedSensorBoxScript.cs : This file contains the class used to manage 
*       the actions carried out whn the user clicks on a box of the "Sensores 
*       Añadidos" panel. 
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddedSensorBoxScript : MonoBehaviour
{
    /*// Delegate used to release the snap point associated to the sensor deleted. This delegate is associated in the "SnapController.cs" script.
    public delegate void SetFreePoint(Transform snappedPoint);
    public static SetFreePoint SetFreeSnappedPoint;*/

    // Delegate used to update the sensor pannel when a box is deleted when a sensor is deleted. This delegate is associated in the "BoxesManager.cs" script.
    public delegate void UpdateAddedSensorsPanel(string currentPanelText);
    public static UpdateAddedSensorsPanel UpdateAddedSensors;

    /// <summary>
    /// This method is used to delete the sensor associated with this box.
    /// </summary>
    public void DestroySensor()
    {
        // =================== Sensor Removal ======================
        GameObject SelectedRobot = GameObject.FindGameObjectWithTag("SelectedRobot");
        string sensorName = gameObject.transform.GetChild(0).gameObject.GetComponent<TMPro.TextMeshProUGUI>().text;
        //SetFreeSnappedPoint(SelectedRobot.transform.Find(sensorName).gameObject.GetComponent<DragObject>().SnappedPoint); // Access to the point which the sensor was sanpped.
        Destroy(SelectedRobot.transform.Find(sensorName).gameObject);

        // ====== Deactivativation of the "CancelPanel": ======
        GameObject CancelPanel = gameObject.transform.Find("CancelPanel").gameObject;
        if (CancelPanel.activeSelf)
        {
            CancelPanel.SetActive(false);
        }

        // ===== Update of the "AddedSensorsPanel" ======
        string auxString = gameObject.transform.GetChild(0).gameObject.GetComponent<TMPro.TextMeshProUGUI>().text;
        UpdateAddedSensors(auxString);
    }
    
}
