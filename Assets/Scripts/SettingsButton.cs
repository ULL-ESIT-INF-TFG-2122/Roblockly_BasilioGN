using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsButton : MonoBehaviour
{
    public GameObject SettingsMenu;

    public void SettingsMenuActivation()
    {
        if (SettingsMenu != null)
        {
            if (SettingsMenu.activeSelf)
            {
                SettingsMenu.SetActive(false);
            } else {
                SettingsMenu.SetActive(true);
            }
        }
    }
}
