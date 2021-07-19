using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SensorTouch : MonoBehaviour
{
    [SerializeField] private GameObject panelTouch;
    private bool linkedToARobot = false;
    // Start is called before the first frame update
    void Start()
    {
        SnapController.SetLinkedToARobotOn += SetLinkTouch;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// OnMouseDown is called when the user has pressed the mouse button while
    /// over the GUIElement or Collider.
    /// </summary>
    void OnMouseDown()
    {
        Debug.Log("Está entrando en el MouseDown del Touch");
        if (linkedToARobot) {
            GameObject panel = GameObject.Find("AddedSensorsPanel");
            Instantiate(panelTouch, panel.gameObject.transform);
        }
    }

    void SetLinkTouch(bool linkStatus)
    {
        if (linkStatus)
        {
            linkedToARobot = true;
        } else {
            linkedToARobot = false;
        }
    }
}
