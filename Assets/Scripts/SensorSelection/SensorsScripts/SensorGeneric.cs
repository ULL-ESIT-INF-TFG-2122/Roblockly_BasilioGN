/**
* Universidad de La Laguna
* Author: Basilio Gómez Navarro
* Email: alu0101049151@ull.edu.es
* Date: 20/07/2021
* File: SensorGeneric.cs : This file contains the 
*       "SensorGeneric" class implementation. This class is a "base" class
*       used to manage the "generic" logic of a any sensor type.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Class used to manage the "generic" logic of a any sensor type.
/// </summary>
public abstract class SensorGeneric : MonoBehaviour
{
    [SerializeField] protected GameObject panelSensor;
    bool linkedToARobot = false;
    protected GameObject auxiliarPanel;
    protected PanelsManager panelsContainer;
    private Transform SnappedPoint; // Is the point which it has been snapped.
    // This variable is set in the "SnapController" script, when the sensor is snapped.
    protected string sensorName;

    // Delegate used to release the snap point associated to the sensor deleted. This delegate is associated in the "SnapController.cs" script.
    public delegate void SetFreePoint(Transform snappedPoint);
    public static SetFreePoint SetFreeSnappedPoint;
    
    /// <summary>
    /// OnMouseDown is called when the user has pressed the mouse button while
    /// over the GUIElement or Collider.
    /// </summary>
    void OnMouseDown()
    {
        panelsContainer = Object.FindObjectOfType<PanelsManager>();
        Debug.Log("Está entrando en el MouseDown");
        if (linkedToARobot) {
            SetPanelName(sensorName);
            panelsContainer.InstantiatePanel(panelSensor);
        }
    }
    
    public Transform GetSnappedPoint()
    {
        return SnappedPoint;
    }

    public void SetSnappedPoint(Transform newSnappedPoint)
    {
        SnappedPoint = newSnappedPoint;
    }

    private string SetSensorLocationName(string snapPoint)
    {
        string sensorLocationName;
        switch (snapPoint)
        {
            case "FrontSnap":
                sensorLocationName = "delantero";
                break;
            case "TopFrontSnapCenter":
                sensorLocationName = "frontal central";
                break;
            case "TopFrontSnapRight":
                sensorLocationName = "frontal derecho";
                break;
            case "TopFrontSnapLeft":
                sensorLocationName = "frontal izquierdo";
                break;
            case "BackSnap":
                sensorLocationName = "trasero";
                break;
            case "LeftSnap":
                sensorLocationName = "izquierdo";
                break;
            case "RightSnap":
                sensorLocationName = "derecho";
                break;
            default:
                sensorLocationName = "robot";
                break;
        }
        return sensorLocationName;
    }

    public virtual void SetSensorName(string snapPoint)
    {
        string sensorLocationName = SetSensorLocationName(snapPoint);
        gameObject.transform.name = "Sensor " + sensorLocationName + ": ";
    }

    protected void SetPanelName(string panelName)
    {
        panelSensor.gameObject.transform.GetChild(0).gameObject.GetComponent<Text>().text = panelName;
    }

    protected string GetPanelName()
    {
        return panelSensor.gameObject.transform.GetChild(0).gameObject.GetComponent<Text>().text;
    }

    protected void SetLinkSensor(bool linkStatus)
    {
        if (linkStatus)
        {
            linkedToARobot = true;
        } else {
            linkedToARobot = false;
        }
    }

    public void CancelPanel()
    {
        //Debug.Log("Está activado el panel");
        panelsContainer = Object.FindObjectOfType<PanelsManager>();
        panelsContainer.DestroyPanel(panelSensor.name + "(Clone)");
        SetPanelName("");
    }

    protected void StoreSensorName(string newSensorName)
    {
        sensorName = newSensorName;
    }

    public void DeleteSensor()
    {
        GameObject SelectedRobot = GameObject.FindGameObjectWithTag("SelectedRobot");
        SetFreeSnappedPoint(SelectedRobot.transform.Find(GetPanelName()).gameObject.GetComponent<SensorGeneric>().GetSnappedPoint());
        Destroy(SelectedRobot.transform.Find(GetPanelName()).gameObject);
        SelectedRobot.GetComponent<RobotManager>().DeleteSensorFromUsedSensors(GetPanelName());
        CancelPanel();
    }
}
