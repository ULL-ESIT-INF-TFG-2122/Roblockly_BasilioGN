using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ErrorPanel : MonoBehaviour
{
    public GameObject errorPanel;
    public void ShowErrorSensorPosition(string errorToShow)
    {
        UBlockly.CSharp.Runner.Stop();
        if (!gameObject.activeSelf)
        {
            gameObject.SetActive(true);
        }
        errorPanel.transform.GetChild(1).GetComponent<Text>().text = errorToShow;
    }

    public void CancelPanel()
    {
        if (gameObject.activeSelf)
        {
            gameObject.SetActive(false);
        }
    }
}
