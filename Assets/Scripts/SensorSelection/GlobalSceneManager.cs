using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalSceneManager : MonoBehaviour
{
    public static bool switchOn = false;

    public static GlobalSceneManager globalInstance;
    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        if (GlobalSceneManager.globalInstance == null)
        {
            globalInstance = this;
            DontDestroyOnLoad(this.gameObject);
        } else {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
      //IndividualSelectionSceneManager1.SetActiveSceneCanvas = SwitchOnSecene3;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public static void SwitchOnSecene3(bool status)
    {
        Debug.Log("Ha entrado en el SwitchOnScene3 con status: " + status);
        if (status == true) { switchOn = true; }
        else { switchOn = false; }
        Debug.Log("SwitchOn: " + switchOn);
    }
}
