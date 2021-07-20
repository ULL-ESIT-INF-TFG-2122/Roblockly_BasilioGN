using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SensorUS : SensorGeneric
{
    private float range;
    private float error;

    // Start is called before the first frame update
    void Start()
    {
      SnapController.SetLinkedToARobotOn += base.SetLinkSensor;
    }

    public void ActivateUS()
    {
        transform.gameObject.SetActive(transform.gameObject.tag == "SensorUS");
    }

    void SetRange()
    {
        //
    }

    void SetError()
    {
        //
    }

    public override void SetSensorName(string snapPoint)
    {
        base.SetSensorName(snapPoint);
        gameObject.transform.name = gameObject.transform.name + "Ultrasonido";
        base.StoreSensorName(gameObject.transform.name);
        base.SetPanelName();
    }
}
