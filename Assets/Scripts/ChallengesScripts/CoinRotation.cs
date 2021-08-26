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
        if (other.gameObject.tag == "SelectedRobot" ||
            other.gameObject.name == "Contact")
        {
            GameObject selectedRobot = GameObject.FindWithTag("SelectedRobot").gameObject;
            selectedRobot.GetComponent<RobotMotionController1>().StopRobotNow();
            gameObject.SetActive(false);
            ChallengeSolution newSolution = new ChallengeSolution();
            // Add time elapsed to complet the challenge:
            newSolution.SetSolutionTime(GameObject.FindWithTag("Timer").GetComponent<TimerBehaviour>().GetTimeString());
            // Add time elapsed to complet the challenge in string format:
            newSolution.SetSolutionTimeFloat(GameObject.FindWithTag("Timer").GetComponent<TimerBehaviour>().TimerFunction());
            // Set the number of used blocks to complete this solution:
            newSolution.SetBlocksNumber(GameObject.FindWithTag("StatisticsManager").GetComponent<StatisticsManager>().GetUsedBlocks());
            // Set of the progress in this solution:
            newSolution.CalculateProgress("Labyrinth");
            GameObject.FindWithTag("StatisticsManager").GetComponent<StatisticsManager>().AddNewChallengeSolution("Labyrinth", newSolution);
            StopTimer();
        }
    }
}
