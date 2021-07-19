using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SensorUS : MonoBehaviour
{
    [SerializeField] private GameObject panelUS;
    private string name = "Ultrasonido";
    private float error;
    private float range;
    private bool linkedToARobot = false;


    // Start is called before the first frame update
    void Start()
    {
        SnapController.SetLinkedToARobotOn = SetLink;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActivateUS()
    {
        transform.gameObject.SetActive(transform.gameObject.tag == "SensorUS");
    }

    /// <summary>
    /// OnMouseDown is called when the user has pressed the mouse button while
    /// over the GUIElement or Collider.
    /// </summary>
    void OnMouseDown()
    {
        Debug.Log("Está entrando en el MouseDown");
        if (linkedToARobot) {
            GameObject panel = GameObject.Find("AddedSensorsPanel");
            Instantiate(panelUS, panel.gameObject.transform);
        }
    }

    void SetLink(bool linkStatus)
    {
        if (linkStatus)
        {
            linkedToARobot = true;
        } else {
            linkedToARobot = false;
        }
    }

    void SetRange()
    {
        //
    }

    void SetError()
    {
        //
    }
    void DeleteSensor()
    {
        //
    }

    void CancelPanel()
    {
        panelUS.SetActive(false);
    }
}
