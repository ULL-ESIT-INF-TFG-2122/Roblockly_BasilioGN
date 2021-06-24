using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SensorUS : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActivateUS()
    {
        transform.gameObject.SetActive(transform.gameObject.tag == "SensorUS");
    }
}
