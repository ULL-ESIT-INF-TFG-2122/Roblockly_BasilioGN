using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConeCollider : MonoBehaviour
{
    public GameObject ParentSensorUS;
    private bool collided = false;
    Vector3 distanceToCollided;

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
        distanceToCollided = ParentSensorUS.transform.position - other.transform.position;
        Debug.Log("Ha chocado con: " + other.gameObject.name);
    }

    /// <summary>
    /// OnCollisionExit is called when this collider/rigidbody has
    /// stopped touching another rigidbody/collider.
    /// </summary>
    /// <param name="other">The Collision data associated with this collision.</param>
    void OnCollisionExit(Collision other)
    {
        collided = false;
    }

    public float GetCollidedDistance()
    {
        if (collided)
        {
            return distanceToCollided.x;
        }
        return Mathf.Infinity;
    }
}
