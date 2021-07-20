using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SensorGeneric : MonoBehaviour
{
    [SerializeField] protected GameObject panelSensor;
    bool linkedToARobot = false;
    protected GameObject auxiliarPanel;
    protected PanelsManager panelsContainer;
    private string sensorName;
    
    /// <summary>
    /// OnMouseDown is called when the user has pressed the mouse button while
    /// over the GUIElement or Collider.
    /// </summary>
    void OnMouseDown()
    {
        panelsContainer = Object.FindObjectOfType<PanelsManager>();
        Debug.Log("Está entrando en el MouseDown");
        if (linkedToARobot) {
            //GameObject panel = GameObject.Find("PanelsContainer");
            //Instantiate(panelSensor, panel.gameObject.transform);
            panelsContainer.InstantiatePanel(panelSensor);
        }
    }

    public virtual void SetSensorName(string snapPoint)
    {
        gameObject.transform.name = "Sensor " + snapPoint + ": ";
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
}
