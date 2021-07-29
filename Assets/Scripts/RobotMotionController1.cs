using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotMotionController1 : MonoBehaviour
{
    private Rigidbody robotRigidbody;
    private const int DEFAULT_DISTANCE = 1;
    
    public Transform frontDriverTransform, frontPassengerTransform;
    public Transform rearDriverTransform, rearPassengerTransform;
    public float motorSpeed = 50;
    

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        robotRigidbody = GetComponent<Rigidbody>();
    }

    /// <summary>
    /// Moves the robot forward at the speed passed by parameters.
    /// </summary>
    /// <param name="velocity"> The velocity to move the robot forward.</param>
    private void MoveForwardRobot(float velocity)
    {
        Vector3 moveInput = new Vector3(0, 0, DEFAULT_DISTANCE);
        robotRigidbody.MovePosition(transform.position + moveInput * Time.deltaTime * velocity);
        if (DEFAULT_DISTANCE != 0)
        {
            rotateWheels(velocity);
        }
    }

    /// <summary>
    /// Moves the robot backward at the speed passed by parameters.
    /// </summary>
    /// <param name="velocity"> The velocity to move the robot backward.</param>
    private void MoveBackwardRobot(float velocity)
    {
        Vector3 moveInput = new Vector3(0, 0, -DEFAULT_DISTANCE);
        robotRigidbody.MovePosition(transform.position + moveInput * Time.deltaTime * velocity);
        if (DEFAULT_DISTANCE != 0)
        {
            rotateWheels(velocity);
        }
    }

    /// <summary>
    /// Rotates the robot wheels. Is called when the robot is in motion.
    /// </summary>
    /// <param name="velocity"> The velocity to rotate the wheels.</param>
    private void rotateWheels(float velocity)
    {
        frontDriverTransform.Rotate(velocity * 10 * Time.deltaTime, 0, 0);
        frontPassengerTransform.Rotate(velocity * 10 * Time.deltaTime, 0, 0);
        rearDriverTransform.Rotate(velocity * 10 * Time.deltaTime, 0, 0);
        rearPassengerTransform.Rotate(velocity * 10 * Time.deltaTime, 0, 0);
    }

    /// <summary>
    /// Rotates the robot over its Y axis a specific angle.
    /// </summary>
    /// <param name="angleToRotate"> Value of the angle that the robot will 
    /// rotate.</param>
    private IEnumerator RotateRobot(float angleToRotate)
    {
        Quaternion goal = Quaternion.Euler(0, angleToRotate, 0);
        while (Quaternion.Angle(transform.rotation, goal) > 1.0f)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, angleToRotate, 0), Time.deltaTime);
            yield return null;
        }
        transform.rotation = Quaternion.Euler(0, angleToRotate, 0);
        yield return null;
    }
    
    /// <summary>
    /// Stops the robot immediately;
    /// </summary>
    private void StopRobot()
    {
        robotRigidbody.velocity = new Vector3(0, 0, 0);
        StopAllCoroutines();
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        /*if (aux == 0)
        {
            Debug.Log("Ha entrado en el if");
            StartCoroutine(RotateRobot(90));
            aux++;
        }*/
        if (Input.GetKeyDown("space"))
        {
            //StopRobot();
            //StopAllCoroutines();
            //print("Stopped all Coroutines: " + Time.time);
        }
    }

    //int aux = 0;
    /// <summary>
    /// This function is called every fixed framerate frame, if the 
    /// MonoBehaviour is enabled.
    /// </summary>
    private void FixedUpdate()
    {
        /*if (aux < 100)
        {
            MoveForwardRobot(20);
        } else {
            StopRobot();
        }
        aux++;*/
        //MoveBackwardRobot(1);
    }
}
