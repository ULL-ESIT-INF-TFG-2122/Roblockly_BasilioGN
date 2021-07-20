using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelsManager : MonoBehaviour
{
    public void InstantiatePanel(GameObject panelSensorToInstantiate)
    {
        if (transform.childCount > 0)
        {
            DestroyPanel(transform.GetChild(0).name);
            Instantiate(panelSensorToInstantiate, gameObject.transform);
        } else {
            Instantiate(panelSensorToInstantiate, gameObject.transform);
        }
    }

    public void DestroyPanel(string currentPanel)
    {
        Debug.Log("Ha entrado enel destroy panel");
        bool found = false;
        int i = 0;
        if (transform.childCount > 0)
        {
            while ((!found) && (i < transform.childCount))
            {
                if (transform.GetChild(i).name == currentPanel)
                {
                    found = true;
                    Destroy(transform.GetChild(i).gameObject);
                }
                i++;
            }
        } else {
            Debug.LogError("There are not any panel to destroy");
        }
    }
}
