using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{   
    public static CanvasManager canvasManagerInstance;
    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        if (CanvasManager.canvasManagerInstance == null) // First call to the instance
        {
            CanvasManager.canvasManagerInstance = this;
            DontDestroyOnLoad(this.gameObject);
        } else { // An instance already exists.
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        SensorSelectionSceneManager.SetCanvasActive = EnableCanvas;
        IndividualSelectionSceneManager.SetActiveSceneCanvas = EnableCanvas;
    }

    private void EnableCanvas(bool isActive)
    {
        if (isActive)
        {
            gameObject.SetActive(true);
        } else {
            Debug.Log("Se ha eliminado");
            gameObject.SetActive(false);
            //this.enabled = false;
        }
    }
}
