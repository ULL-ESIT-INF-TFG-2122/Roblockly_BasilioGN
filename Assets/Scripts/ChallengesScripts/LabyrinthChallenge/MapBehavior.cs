using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapBehavior : MonoBehaviour
{
    private Transform robotTransform;
    // Start is called before the first frame update
    void Start()
    {
        robotTransform = GameObject.FindWithTag("SelectedRobot").transform;
    }

    /// <summary>
    /// LateUpdate is called every frame, if the Behaviour is enabled.
    /// It is called after all Update functions have been called.
    /// </summary>
    void LateUpdate()
    {
        Vector3 newMapPosition = robotTransform.position;
        newMapPosition.y = robotTransform.position.y + 100;
        transform.position = newMapPosition;
    }
}
