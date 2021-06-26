using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchBox : MonoBehaviour
{

    public DragObject TouchSensor = null;

    public void SpawnSensor()
    {
        DragObject InstantiatedSensor = Instantiate(TouchSensor);
        InstantiatedSensor.ManageDrag();
    }
}
