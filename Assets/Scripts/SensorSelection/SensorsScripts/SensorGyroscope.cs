using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SensorGyroscope : MonoBehaviour
{
    private GameObject selectedRobot;
    private GameObject BalanceSphere; // Is the sphere under the platform of the "BalanceChallenge".

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        selectedRobot = GameObject.FindWithTag("SelectedRobot");
    }

    public string GyroscopeBehavior()
    {
        BalanceSphere = GameObject.Find("BaseSphere");
        if (!CheckParallel())
        {
            if (CheckAngle())
            {
                return "forward";
            } else {
                return "backward";
            }
        }
        return "parallel";
    }

    private bool CheckParallel()
    {
        Vector3 SphereRobotVector = (selectedRobot.transform.position - BalanceSphere.transform.position).normalized;
        Debug.DrawLine(selectedRobot.transform.position, BalanceSphere.transform.position, Color.red, 5.0f);
        Vector3 PointSphereUp = new Vector3(BalanceSphere.transform.position.x, BalanceSphere.transform.position.y + 100, BalanceSphere.transform.position.z);
        Vector3 SphereUp = (PointSphereUp - BalanceSphere.transform.position).normalized;
        Debug.DrawLine(BalanceSphere.transform.position, PointSphereUp, Color.blue, 5.0f);
        float auxAngle = Vector3.SignedAngle(SphereRobotVector, SphereUp, BalanceSphere.transform.right);
        Debug.Log("Ángulo: " + auxAngle);
        auxAngle = Mathf.Round(auxAngle);
        if (auxAngle < 10.0f && auxAngle > -10.0f)
        {
            return true;
        }
        return false;
    }

    private bool CheckAngle()
    {
        Vector3 SphereRobotVector = (selectedRobot.transform.position - BalanceSphere.transform.position).normalized;
        Vector3 PointSphereUp = new Vector3(BalanceSphere.transform.position.x, BalanceSphere.transform.position.y + 100, BalanceSphere.transform.position.z);
        Vector3 SphereUp = (PointSphereUp - BalanceSphere.transform.position).normalized;
        float auxAngle = Vector3.SignedAngle(SphereRobotVector, SphereUp, BalanceSphere.transform.right);
        Debug.Log("Ángulo2: " + auxAngle);
        if (auxAngle < 0.0f)
        {
            return true; // Robot is moving forward
        }
        return false; // Robot is moving backward
    }
}
