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
    /// OnCollisionEnter is called when this collider/rigidbody has begun
    /// touching another rigidbody/collider.
    /// </summary>
    /// <param name="other">The Collision data associated with this collision.</param>
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "SelectedRobot")
        {
            GameObject selectedRobot = GameObject.FindWithTag("SelectedRobot");
            selectedRobot.GetComponent<RobotMotionController1>().StopRobot();
            gameObject.SetActive(false);
            StopTimer();
        }
    }
}
