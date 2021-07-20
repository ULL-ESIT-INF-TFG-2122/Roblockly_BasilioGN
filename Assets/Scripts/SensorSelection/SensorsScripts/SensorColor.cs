using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SensorColor : SensorGeneric
{
    private float range;
    private float precision;
    // Start is called before the first frame update
    void Start()
    {
        SnapController.SetLinkedToARobotOn += base.SetLinkSensor;
    }

    void SetPrecision() 
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
        gameObject.transform.name = gameObject.transform.name + "Color";
    }

}
