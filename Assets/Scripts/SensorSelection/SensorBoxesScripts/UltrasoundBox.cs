/**
* Universidad de La Laguna
* Author: Basilio Gómez Navarro
* Email: alu0101049151@ull.edu.es
* Date: 19/06/2021
* File: UltrasoundBox.cs : This file contains the logic to spawn a Ultrasound 
*       sensor when the user clicks on the Ultrasound Sensor Box.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UltrasoundBox : MonoBehaviour
{
    public DragObject UltrasoundSensor = null;

    public void SpawnSensor()
    {
       // if (Input.GetMouseButtonDown(0))
       // {
            /*Ray auxiliarRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit auxiliarRayHit;
            if (Physics.Raycast(auxiliarRay, out auxiliarRayHit))
            {
                Debug.Log("Hit: " + auxiliarRayHit.point);
                DragObject InstantiatedSensor = Instantiate(UltrasoundSensor);
                //InstantiatedSensor.gameObject.layer = spawnedObjectLayer;
                InstantiatedSensor.transform.position = auxiliarRayHit.point;
            }*/
        //}
    /*
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Debug.Log("Spawn");
            Ray ray = MainCamera.ScreenPointToRay(Mouse.current.position.ReadValue());
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
             {
                 Instantiate(UltrasoundSensor, new Vector3(hit.point.x, hit.point.y + UltrasoundSensor.transform.position.y, hit.point.z), Quaternion.identity);
             }
        }
        */
        DragObject InstantiatedSensor = Instantiate(UltrasoundSensor);
        Debug.Log("Transform en el ultrasound: " + InstantiatedSensor.transform.position);
        InstantiatedSensor.ManageDrag();
    }

}
