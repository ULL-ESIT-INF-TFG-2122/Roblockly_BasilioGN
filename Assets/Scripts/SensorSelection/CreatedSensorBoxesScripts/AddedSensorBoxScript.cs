using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddedSensorBoxScript : MonoBehaviour
{
    public delegate void SetFreePoint(Transform snappedPoint);
    public static SetFreePoint SetFreeSnappedPoint;

    public delegate void UpdateAddedSensorsPanel(string currentPanelText);
    public static UpdateAddedSensorsPanel UpdateAddedSensors;

    public void DestroySensor()
    {
        // =================== Sensor Removal ======================
        GameObject SelectedRobot = GameObject.FindGameObjectWithTag("SelectedRobot");
        string sensorName = gameObject.transform.GetChild(0).gameObject.GetComponent<TMPro.TextMeshProUGUI>().text;
        SetFreeSnappedPoint(SelectedRobot.transform.Find(sensorName).gameObject.GetComponent<DragObject>().SnappedPoint); // Access to the point which was sanpped the sensor.
        Destroy(SelectedRobot.transform.Find(sensorName).gameObject);

        // ====== Deactivativation of the "CancelPanel": ======
        GameObject CancelPanel = gameObject.transform.Find("CancelPanel").gameObject;
        if (CancelPanel.activeSelf)
        {
            CancelPanel.SetActive(false);
        }

        // ===== Update of the "AddedSensorsPanel" ======
        string auxString = gameObject.transform.GetChild(0).gameObject.GetComponent<TMPro.TextMeshProUGUI>().text;
        UpdateAddedSensors(auxString);
    }
    
}
