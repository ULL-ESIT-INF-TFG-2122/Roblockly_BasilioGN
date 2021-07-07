/**
* Universidad de La Laguna
* Author: Basilio Gómez Navarro
* Email: alu0101049151@ull.edu.es
* Date: 27/06/2021
* File: BoxesManager.cs : This file contains the logic to spawn the boxes of 
* each sensor on the right box of the UI.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxesManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// This function is called when the object becomes enabled and active.
    /// </summary>
    void OnEnable()
    {
        SnapController.CreateNewAddedSensorBox += OnActivation;
    }

    private void OnActivation(DragObject selectedSensor)
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            if ((!transform.GetChild(i).gameObject.activeSelf) && (transform.GetChild(i).gameObject.tag == "AddedSensorBox"))
            {
                transform.GetChild(i).gameObject.SetActive(true);
            }   
        }
    }
}
