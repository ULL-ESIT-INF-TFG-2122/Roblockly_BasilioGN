using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class USDetection : MonoBehaviour
{
    public float soundRadius;
    [Range(0,360)]
    public float soundAngle;
    public LayerMask detectableObjects;
    public LayerMask notDetectableObjects;

    void FindDetectableObjects()
    {
        Collider[] detectableObjectsInSoundRadius = Physics.OverlapSphere(transform.position, soundRadius, detectableObjects);
        for (int i = 0; i < detectableObjectsInSoundRadius.Length; i++)
        {
            Transform auxDetectableObject = detectableObjectsInSoundRadius[i].transform;
            Vector3 dirToDetectableOnject = (auxDetectableObject.position - transform.position).normalized;
            if (Vector3.Angle(transform.forward, dirToDetectableOnject) < soundAngle / 2)
            {
                //18:03
            }
        }
    }

    public Vector3 DirectionFromAngle(float angleInDegrees, bool angleIsGlobal)
    {
        if (!angleIsGlobal)
        {
            angleInDegrees += transform.eulerAngles.y;
        }
        return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), 0, Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
    }
}
