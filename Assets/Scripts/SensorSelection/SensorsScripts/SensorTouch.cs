﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SensorTouch : SensorGeneric
{
    // Start is called before the first frame update
    void Start()
    {
        SnapController.SetLinkedToARobotOn += base.SetLinkSensor;
    }
}
