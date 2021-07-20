using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SensorGeneric : MonoBehaviour
{
    [SerializeField] private GameObject panelSensor;
    private bool linkedToARobot = false;
    // Start is called before the first frame update
    
    /// <summary>
    /// OnMouseDown is called when the user has pressed the mouse button while
    /// over the GUIElement or Collider.
    /// </summary>
    void OnMouseDown()
    {
        Debug.Log("Está entrando en el MouseDown");
        if (linkedToARobot) {
            GameObject panel = GameObject.Find("AddedSensorsPanel");
            Instantiate(panelSensor, panel.gameObject.transform);
        }
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

    void CancelPanel()
    {
        panelSensor.SetActive(false);
    }
}
