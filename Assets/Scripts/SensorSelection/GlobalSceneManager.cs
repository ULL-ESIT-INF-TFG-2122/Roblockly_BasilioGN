using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalSceneManager : MonoBehaviour
{
    public static bool switchOn = false;
    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
      IndividualSelectionSceneManager1.SetActiveSceneCanvas = SwitchOnSecene3;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SwitchOnSecene3(bool status)
    {
        if (status == true) { switchOn = true; }
        else { switchOn = false; }
    }
}
