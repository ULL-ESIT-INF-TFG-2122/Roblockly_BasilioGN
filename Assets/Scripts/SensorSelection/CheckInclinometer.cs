/**
* Universidad de La Laguna
* Author: Basilio Gómez Navarro
* Email: alu0101049151@ull.edu.es
* Date: 18/06/2021
* File: CheckInclinometer.cs : This file contains the logic for the 
*       Inclinometer checkbox selection.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckInclinometer : MonoBehaviour
{
    public delegate void InclinometerChecked();
    public static InclinometerChecked CheckboxInclinometer;
    public void Acivation()
    {
        if (!gameObject.activeSelf)
        {
            gameObject.SetActive(true);
            CheckboxInclinometer();
        } else {
            gameObject.SetActive(false);
        } 
    }
}
