using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddedSensorBoxScript : MonoBehaviour
{
    public delegate void DeleteSensor(Transform snappedPoint);
    public static event DeleteSensor DeleteSensorEvent;
    private DragObject associatedSensor;

    public void SetAssociatedSensor(DragObject newSensor)
    {
        associatedSensor = newSensor;
    }

    public void DestroySensor()
    {
        GameObject SelectedRobot = GameObject.FindGameObjectWithTag("SelectedRobot");
        string sensorName = gameObject.transform.GetChild(0).gameObject.GetComponent<TMPro.TextMeshProUGUI>().text;
        DeleteSensorEvent(SelectedRobot.transform.Find(sensorName).gameObject.GetComponent<DragObject>().SnappedPoint);
        Destroy(SelectedRobot.transform.Find(sensorName).gameObject);
    }

    public void aux()
    {
        Debug.Log("Hola aux");
    }
}
