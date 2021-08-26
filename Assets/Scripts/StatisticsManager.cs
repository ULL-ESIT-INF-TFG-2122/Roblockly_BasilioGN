using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatisticsManager : MonoBehaviour
{
    public static StatisticsManager statisticsManagerInstance;

    // This dictionary stores all the challenges that have been completed and their respective solutions.
    private Dictionary<string, List<ChallengeSolution>> challengesSolutions;

    private int usedBlocks = 0;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {   // Adding singleton pattern to keep the statistics manger through all   
        // the scenes
        if (StatisticsManager.statisticsManagerInstance == null)
        {
            StatisticsManager.statisticsManagerInstance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        Destroy(gameObject);
    }

    public void IncreaseUsedBlocks()
    {
        usedBlocks++;
    }

    public void DecreaseUsedBlocks()
    {
        if (usedBlocks > 0)
        {
            usedBlocks--;
        }
    }

    public void CleanUsedBlocks()
    {
        usedBlocks = 0;
    }

    public int GetUsedBlocks()
    {
        return usedBlocks;
    }

    /// <summary>
    /// Adds a new solution for a specific challenge if it exists as a key of
    /// "challengesSolutions" or adds it as new element to the dictionary.
    /// </summary>
    /// <param name="challengeName"> Is the challenge name used as key to look for in the dictionary. </param>
    /// <param name="solution"> Is the new solution to add to a specific challenge (key). </param>
    public void AddNewChallengeSolution(string challengeName, ChallengeSolution solution)
    {
        if (challengesSolutions.ContainsKey(challengeName))
        {
            challengesSolutions[challengeName].Add(solution);
        } else {
            List<ChallengeSolution> newListToAdd = new List<ChallengeSolution>();
            newListToAdd.Add(solution);
            challengesSolutions.Add(challengeName, newListToAdd);
        }
    }

    public Dictionary<string, List<ChallengeSolution>> GetChallengesSolutions()
    {
        return challengesSolutions;
    }

        
    /*/// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        if (!Finder.CheckContains ("StatisticsManager"))
        {
            DontDestroyOnLoad(this.gameObject);
            Finder.AddObject(this.gameObject);
        }
    }*/
}
