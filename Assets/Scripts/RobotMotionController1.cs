using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotMotionController1 : MonoBehaviour
{
    private float horizontaInput;
    private float verticalInput;
    private float steeringAngle;

    private Rigidbody robotRigidbody;
    
    public WheelCollider frontDriverWheel, frontPassengerWheel;
    public WheelCollider rearDriverWheel, rearPassengerWheel;
    public Transform frontDriverTransform, frontPassengerTransform;
    public Transform rearDriverTransform, rearPassengerTransform;
    public float maxSteerAngle = 30; // Controls the steering radious. How fast can we turn or would we do a u-turn in the robot. (Rotation angle for the wheels).
    public float motorForce = 50; // How fast the robot can go.
    public float motorSpeed = 50;
    

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        robotRigidbody = GetComponent<Rigidbody>();
    }

    public void GetInput()
    {
        horizontaInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
    }

    private void Steer()
    {
        steeringAngle = maxSteerAngle * horizontaInput;
        frontDriverWheel.steerAngle = steeringAngle;
        frontPassengerWheel.steerAngle = steeringAngle;
    }

    /// <summary>
    /// Applies acceleretion to the wheels in order to Emulate a real wheel 
    /// driving.
    /// </summary>
    private void Accelerate()
    {
        frontDriverWheel.motorTorque = verticalInput * motorForce;
        frontPassengerWheel.motorTorque = verticalInput * motorForce;
        rearDriverWheel.motorTorque = verticalInput * motorForce;
        rearPassengerWheel.motorTorque = verticalInput * motorForce;
    }

    /// <summary>
    /// This method is used to update the rotations and position of the wheels.
    /// It makes possible the wheels look like real wheels spinning.
    /// </summary>
    private void UpdateWheelPoses()
    {
        UpdateWheelPose(frontDriverWheel, frontDriverTransform);
        UpdateWheelPose(frontPassengerWheel, frontPassengerTransform);
        UpdateWheelPose(rearDriverWheel, rearDriverTransform);
        UpdateWheelPose(rearPassengerWheel, rearPassengerTransform);
    }

    /// <summary>
    /// This method is an overload of the previous one in orther to configure 
    /// each individual wheel and not duplicate all the code for each wheel in
    /// the previous method.
    /// </summary>
    private void UpdateWheelPose(WheelCollider currentCollider, Transform currentTransform)
    {
        Vector3 currentPosition = currentTransform.position;
        Quaternion currentRotation = currentTransform.rotation;

        currentCollider.GetWorldPose(out currentPosition, out currentRotation);
        currentTransform.position = currentPosition;
        currentTransform.rotation = currentRotation;
    }

    private void MoveForwardRobot(float distance)
    {
        Vector3 moveInput = new Vector3(0, 0, distance);
        robotRigidbody.MovePosition(transform.position + moveInput * Time.deltaTime * motorSpeed);
        if (distance != 0)
        {
            rotateWheels();
        }
    }

    private void MoveBackwardRobot(float distance)
    {
        Vector3 moveInput = new Vector3(0, 0, -distance);
        robotRigidbody.MovePosition(transform.position + moveInput * Time.deltaTime * motorSpeed);
        if (distance != 0)
        {
            rotateWheels();
        }
    }

    private void rotateWheels()
    {
        frontDriverTransform.Rotate(motorSpeed * 10 * Time.deltaTime, 0, 0);
        frontPassengerTransform.Rotate(motorSpeed * 10 * Time.deltaTime, 0, 0);
        rearDriverTransform.Rotate(motorSpeed * 10 * Time.deltaTime, 0, 0);
        rearPassengerTransform.Rotate(motorSpeed * 10 * Time.deltaTime, 0, 0);
    }

    private IEnumerator RotateRobot(float angleToRotate)
    {
        //gameObject.transform.Rotate(degreesToRotate * 20 * Time.deltaTime, 0, 0);
        Quaternion goal = Quaternion.Euler(0, angleToRotate, 0);
        while (Quaternion.Angle(transform.rotation, goal) > 1.0f)
        {
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.Euler(0, angleToRotate, 0), Time.deltaTime);
            yield return null;
        }
        this.transform.rotation = Quaternion.Euler(0, angleToRotate, 0);
        yield return null;
    }

    int aux = 0;

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        if (aux == 0)
        {
            Debug.Log("Ha entrado en el if");
            StartCoroutine(RotateRobot(90));
            aux++;
        }
        if (Input.GetKeyDown("space"))
        {
            StopAllCoroutines();
            print("Stopped all Coroutines: " + Time.time);
        }
    }

    /// <summary>
    /// This function is called every fixed framerate frame, if the 
    /// MonoBehaviour is enabled.
    /// </summary>
    private void FixedUpdate()
    {
        GetInput();
        //Steer();
        //Accelerate();
        //UpdateWheelPoses();
        //MoveForwardRobot(1);
        //MoveBackwardRobot(1);
    }
}
