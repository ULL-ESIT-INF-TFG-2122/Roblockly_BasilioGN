using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{   
    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        SensorSelectionSceneManager.SetCanvasActive = EnableCanvas;
    }

    private void EnableCanvas(bool isActive)
    {
        if (isActive)
        {
            this.enabled = true;
        } else {
            Debug.Log("Se ha eliminado");
            gameObject.SetActive(false);
            //this.enabled = false;
        }
    }
}
