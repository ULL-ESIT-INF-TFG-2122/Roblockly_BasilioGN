using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SettingsMenu : MonoBehaviour
{
    public GameObject statisticsPanel;
    public GameObject statisticsInfoPanel;
    public GameObject challengeTitle;
    public GameObject bestTimeText;
    public GameObject leastBlocksSolutionText;
    public GameObject averageTimeText;
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
            // In case to want to return the key given the text:
            case "Reto del laberinto":
                challengeButtonText = "Labyrinth";
                break;
            case "Reto del sendero blanco":
                challengeButtonText = "IR";
                break;
            case "Reto del sendero de colores":
                challengeButtonText = "Color";
                break;
            case "Reto de la plataforma móvi":
                challengeButtonText = "Gyroscope";
                break;
            default:
                challengeButtonText = "Reto de roblockly";
                break;
        }
        return challengeButtonText;
    }

    public void LoadSelectedButtonStatistics()
    {
        // Getting the button text content to get the key to look for.
        string buttonText;
        buttonText = EventSystem.current.currentSelectedGameObject.gameObject.transform.GetChild(0).GetComponent<Text>().text;
        string challengeKey = GetChallengeButtonText(buttonText); // Get key given the text.
        
        LoadStatisticsTittle(buttonText);
        LoadBestTimeInfo(challengeKey);
        LoadLeastBlocksSolution(challengeKey);
        LoadAverageTime(challengeKey);
    }

    private void LoadStatisticsTittle(string buttonText)
    {
        // Setting "RetoTitle" text field:
        challengeTitle.GetComponent<Text>().text = buttonText;
    }

    private void LoadBestTimeInfo(string challengeKey)
    {
        // Setting "MejorTiempoText" text field:
        bestTimeText.transform.GetChild(0).GetComponent<Text>().text = GetBestTime(challengeKey);
    }

    private void LoadLeastBlocksSolution(string challengeKey)
    {
        List<string> solutionInfo = GetLeastBlocks(challengeKey);
        // Setting "SolConMenosBloquesText" text field:
        // Setting "TiempoText" text field of "SolConMenosTiempoText" GUI section:
        leastBlocksSolutionText.transform.GetChild(0).GetComponent<Text>().text = solutionInfo[0];
        // Setting "BloquesUtilizadosText" text field of "SolConMenosTiempoText" GUI section:
        leastBlocksSolutionText.transform.GetChild(1).GetComponent<Text>().text = solutionInfo[1];
        // Setting "porcentajeDeAcercamiento" text field of "SolConMenosTiempoText" GUI section:
        leastBlocksSolutionText.transform.GetChild(2).GetComponent<Text>().text = solutionInfo[2];
    }

    private void LoadAverageTime(string challengeKey)
    {
        string averageTime = GetAverageTime(challengeKey).ToString();
        // Setting "TiempoPromedio" text field:
        averageTimeText.transform.GetChild(0).GetComponent<Text>().text = averageTime;
    }

    private string GetBestTime(string challengeKey)
    {
        int i = 0;
        Dictionary<string, List<ChallengeSolution>> auxDictionary = statisticsManager.GetComponent<StatisticsManager>().GetChallengesSolutions();
        while (i < auxDictionary[challengeKey].Count)
        {
            if (auxDictionary[challengeKey][i].GetBestTime())
            {
                return auxDictionary[challengeKey][i].GetSolutionTime();
            }
            i++;
        }
        return " ";
    }

    private List<string> GetLeastBlocks(string challengeKey)
    {
        int i = 0;
        List<string> solutionInfo = new List<string>();
        Dictionary<string, List<ChallengeSolution>> auxDictionary = statisticsManager.GetComponent<StatisticsManager>().GetChallengesSolutions();
        while(i < auxDictionary[challengeKey].Count)
        {
            if (auxDictionary[challengeKey][i].GetBestBlocks())
            {
                // Setting time elapsed to complete the challenge
                solutionInfo.Add(auxDictionary[challengeKey][i].GetSolutionTime());
                
                // Setting amount of used blocks;
                string auxBlocksNumber = auxDictionary[challengeKey][i].GetBlocksNumber().ToString();
                solutionInfo.Add(auxBlocksNumber);
                
                // Setting progress percentage
                //auxDictionary[challengeKey][i].CalculateProgress(challengeKey);
                string auxProgressPercentage = auxDictionary[challengeKey][i].GetProgress().ToString("f2");
                solutionInfo.Add(auxProgressPercentage);
                return solutionInfo;
            }
            i++;
        }
        return solutionInfo;
    }

    private float GetAverageTime(string challengeKey)
    {
        List<ChallengeSolution> selectedChallengeSolutions = statisticsManager.GetComponent<StatisticsManager>().GetChallengesSolutions()[challengeKey];
        float totalMinutes = 0.0f;
        foreach (ChallengeSolution solution in selectedChallengeSolutions)
        {
            totalMinutes += solution.GetElapsedMinutes();
        }
        return (totalMinutes / selectedChallengeSolutions.Count);
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
