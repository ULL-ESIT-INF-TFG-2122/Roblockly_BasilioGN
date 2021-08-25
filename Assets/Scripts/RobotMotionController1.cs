using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotMotionController1 : MonoBehaviour
{
    private Rigidbody robotRigidbody;
    private const int DEFAULT_DISTANCE = 1;
    private const string RIGHT = "RIGHT";
    private const string LEFT = "LEFT";
    private float angleRotated = 0.0f; // Stores the angle rotated form 0 degrees.
    
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
    /// Moves the robot forward or backward at the speed passed by parameters.
    /// </summary>
    /// <param name="velocity"> The velocity to move the robot forward.</param>
    /// <param name="forward"> True if the robot moves forward, false  if 
    /// backward.</param>
    private void MoveVerticalRobot(float velocity, bool forward)
    {
        Vector3 moveInput;
        if (forward)
        {
            moveInput = new Vector3(0, 0, DEFAULT_DISTANCE);
        } else { // If wants to move robot backwards;
            moveInput = new Vector3(0, 0, -DEFAULT_DISTANCE);
        }
            moveInput = transform.TransformDirection(moveInput); // Used to transform robot direction from local into world space.
            robotRigidbody.MovePosition(transform.position + moveInput * Time.deltaTime * velocity);
            rotateWheels(velocity);
    }

    /// <summary>
    /// Moves the robot forward or backward at the vlocity passed by parameters.
    /// with NO time limit.
    /// </summary>
    /// <param name="velocity"> The velocity to move the robot forward.</param>
    /// <param name="forward"> True if the robot moves forward, false  if 
    /// backward.</param>
    public IEnumerator MoveVerticalRobotInfinite(float velocity, bool forward)
    {
        //for(;;)
        //{
            MoveVerticalRobot(velocity, forward);
            yield return null;
        //}
    }

    /// <summary>
    /// Moves the robot forward or backward at the vlocity passed by parameters.
    /// with time limit.
    /// </summary>
    /// <param name="velocity"> Velocity to move the robot forward.</param>
    /// <param name="timeToMove"> Time (in seconds) during wich the robot will
    /// move.</param>
    /// <param name="forward"> True if the robot moves forward, false  if 
    /// backward.</param>
    public IEnumerator MoveVerticalRobotTime(float velocity, float timeToMove, bool forward)
    {
        if (timeToMove > 0)
        {
            //float elapsedTime = Time.time;
            float elapsedTime = 0.0f;
            while(elapsedTime <= timeToMove)
            {
                //Debug.Log("Time: " + Time.time);
                MoveVerticalRobot(velocity, forward);
                elapsedTime += Time.deltaTime;
                yield return null;
            }
        }
        yield return null;
    }

    /*/// <summary>
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
    }*/

    /// <summary>
    /// Rotates the robot over its Y axis a specific angle.
    /// </summary>
    /// <param name="angleToRotate"> Value of the angle that the robot will 
    /// rotate.</param>
    public IEnumerator RotateRobot(float angleToRotate, string directionToRotate)
    {
        if (directionToRotate == LEFT)
        {
            angleToRotate *= -1; // Changes to negative the selected Angle;
        }
        angleRotated += angleToRotate;
        Quaternion goal = Quaternion.Euler(0, angleRotated, 0);
        while (Quaternion.Angle(transform.rotation, goal) > 1.0f)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, angleRotated, 0), Time.deltaTime);
            yield return null;
        }
        transform.rotation = Quaternion.Euler(0, angleRotated, 0);
        yield return null;
    }
    
    /// <summary>
    /// Stops the robot immediately;
    /// </summary>
    public IEnumerator StopRobot()
    {
        StopAllCoroutines();
        robotRigidbody.velocity = new Vector3(0, 0, 0);
        yield return null;
    }

    public void StopRobotNow()
    {
        //StopAllCoroutines();
        StopCoroutine("MoveVerticalRobotTime");
        robotRigidbody.velocity = Vector3.zero;
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

    public void ResetAngleRotated()
    {
        angleRotated = 0.0f;
    }
/*    /// <summary>
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
        /*if (Input.GetKeyDown("space"))
        {
            //StopRobot();
            //StopAllCoroutines();
            //print("Stopped all Coroutines: " + Time.time);
        }
    }

    int aux = 0;
    /// <summary>
    /// This function is called every fixed framerate frame, if the 
    /// MonoBehaviour is enabled.
    /// </summary>
    private void FixedUpdate()
    {
        /*if (aux == 0)
        {
            
        } /*else {
            StopRobot();
        }*/
        //aux++;
        //MoveBackwardRobot(1);
    //}
}

