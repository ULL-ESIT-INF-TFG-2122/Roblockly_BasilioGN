using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public virtual void SetSensorName(string snapPoint)
    {
        gameObject.transform.name = "Sensor " + snapPoint + ": ";
    }

    protected void SetPanelName()
    {
        panelSensor.gameObject.transform.GetChild(0).gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = gameObject.transform.name;
    }

    protected string GetPanelName()
    {
        return panelSensor.gameObject.transform.GetChild(0).gameObject.GetComponent<TMPro.TextMeshProUGUI>().text;
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
        Debug.Log("Está activado el panel");
        panelsContainer = Object.FindObjectOfType<PanelsManager>();
        panelsContainer.DestroyPanel(panelSensor.name + "(Clone)");
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
        CancelPanel();
    }
}
