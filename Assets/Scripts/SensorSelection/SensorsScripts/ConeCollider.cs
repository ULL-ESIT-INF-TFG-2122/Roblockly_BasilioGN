using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConeCollider : MonoBehaviour
{
    public GameObject ParentSensorUS;
    private bool collided = false;
    private GameObject collidedObject;
    private Vector3 distanceToCollided;
    private bool firstCollision = false;
    private float baseDistance;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        this.GetComponent<Renderer>().enabled = false;
    }

    /// <summary>
    /// OnCollisionEnter is called when this collider/rigidbody has begun
    /// touching another rigidbody/collider.
    /// </summary>
    /// <param name="other">The Collision data associated with this collision.</param>
    void OnCollisionEnter(Collision other)
    {
        collided = true;
        UpdateCollidedObject(other);
        Debug.Log("Ha chocado con: " + other.gameObject.name);
        Debug.Log("Posición muro: " + other.transform.position);
    }

    private void UpdateCollidedObject(Collision other)
    {
        if (collidedObject != null)
        {
            if (collidedObject.tag == "CollidedObject")
            {
                collidedObject.tag = "NotCollidedObject";
            }
        }
        collidedObject = other.gameObject;
        collidedObject.tag = "CollidedObject";
    }

    /// <summary>
    /// OnCollisionExit is called when this collider/rigidbody has
    /// stopped touching another rigidbody/collider.
    /// </summary>
    /// <param name="other">The Collision data associated with this collision.</param>
    void OnCollisionExit(Collision other)
    {
        collided = false;
        firstCollision = false;
    }

    public float GetCollidedDistance()
    {
        Vector3 distance;
        if (collided)
        {
            distance = ParentSensorUS.transform.position - collidedObject.transform.position;
            if (!firstCollision)
            {
                firstCollision = true;
                baseDistance = Mathf.Abs(distance.z);
                return 10.0f;
            }
            float finalDistance = CalculateDistance(baseDistance, Mathf.Abs(distance.z));
            return Mathf.Round(finalDistance);
        }
        return Mathf.Infinity;
    }
    
    private float CalculateDistance(float baseDistance, float currentDistance)
    {
        return (currentDistance * 10.0f) / baseDistance;
    }
}
