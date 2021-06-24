using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxesManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            //Debug.Log(transform.GetChild(i).gameObject.name);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
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
