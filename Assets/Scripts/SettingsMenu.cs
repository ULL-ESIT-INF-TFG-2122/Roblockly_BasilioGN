using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingsMenu : MonoBehaviour
{
    public GameObject statisticsPanel;
    public GameObject statisticsInfoPanel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void StatisticsPanelActivation()
    {
        if (statisticsPanel.activeSelf)
        {
            statisticsPanel.SetActive(false);
        } else {
            statisticsPanel.SetActive(true);
        }
    }

    public void StatisticsInfoPanelActivation()
    {
        if (statisticsInfoPanel.activeSelf)
        {
            statisticsInfoPanel.SetActive(false);
        } else {
            statisticsInfoPanel.SetActive(true);
        }
    }

    public void CancelMenu()
    {
        if (gameObject.activeSelf)
        {
            gameObject.SetActive(false);
        }
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    /// <summary>
    /// Method to quit the game.
    /// </summary>
    public void QuitGame ()
    {   Debug.Log("Quit!"); // To check that it runs properly in Unity
        Application.Quit();
    }
}
