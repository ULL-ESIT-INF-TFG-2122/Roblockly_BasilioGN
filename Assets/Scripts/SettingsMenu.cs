using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public GameObject statisticsPanel;
    public GameObject statisticsInfoPanel;
    private GameObject statisticsManager;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        statisticsManager = GameObject.FindWithTag("StatisticsManager");
    }

    public void StatisticsPanelActivation()
    {
        if (statisticsPanel.activeSelf)
        {
            statisticsPanel.SetActive(false);
        } else {
            ActivateCompletedChallengesButtons();
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

    /// <summary>
    /// Activates the number of buttons required based on the number of 
    /// completed challenges found in the dictionary.
    /// </summary>
    public void ActivateCompletedChallengesButtons()
    {
        Dictionary<string, List<ChallengeSolution>> auxSolutions = statisticsManager.GetComponent<StatisticsManager>().GetChallengesSolutions();
        if (auxSolutions != null)
        {
            foreach (var challengeSolution in auxSolutions)
            {
                int i = 1;
                bool found = false;
                while(!found && (i < 5))
                {
                    if (!statisticsPanel.transform.GetChild(i).gameObject.activeSelf)
                    {
                        found = true;
                        statisticsPanel.transform.GetChild(i).gameObject.SetActive(true);
                        statisticsPanel.transform.GetChild(i).transform.GetChild(0).GetComponent<Text>().text = GetChallengeButtonText(challengeSolution.Key);
                    }
                    i++;
                }
            }
        }
    }

    /// <summary>
    /// Given a key of an element from ChallengesSolutions dictionary, returns 
    // the text to be displayed on the buttons of "StatisticsPanel" GUI.
    /// </summary>
    /// <param name="challengeName"> The string with the key to be "translated" </param>
    private string GetChallengeButtonText(string challengeName)
    {
        string challengeButtonText;
        switch (challengeName)
        {
            case "Labyrinth": 
                challengeButtonText = "Reto del laberinto";
                break;
            case "IR":
                challengeButtonText = "Reto del sendero blanco";
                break;
            case "Color":
                challengeButtonText = "Reto del sendero de colores";
                break;
            case "Gyroscope": 
                challengeButtonText = "Reto de la plataforma móvil";
                break;
            default:
                challengeButtonText = "Reto de roblockly";
                break;
        }
        return challengeButtonText;
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
