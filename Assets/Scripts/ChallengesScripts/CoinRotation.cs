using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinRotation : MonoBehaviour
{
    public delegate void SetTimerOff();
    public static SetTimerOff StopTimer;
    public float rotationSpeed = 60.0f;
    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        RotateCoin();
    }

    private void RotateCoin()
    {
        gameObject.transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
    }

    /// <summary>
    /// OnTriggerEnter is called when the Collider other enters the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Ha entrado en el trigger enter");
        if (other.gameObject.tag == "SelectedRobot")
        {
            GameObject selectedRobot = GameObject.FindWithTag("SelectedRobot").gameObject;
            selectedRobot.GetComponent<RobotMotionController1>().StopRobotNow();
            gameObject.SetActive(false);
            StopTimer();
        }
    }
}
