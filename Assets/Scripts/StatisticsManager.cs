using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatisticsManager : MonoBehaviour
{
    public static StatisticsManager statisticsManagerInstance;

    private Dictionary<string, List<ChallengeSolution>> challengesSolutions;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        if (StatisticsManager.statisticsManagerInstance == null)
        {
            StatisticsManager.statisticsManagerInstance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        Destroy(gameObject);
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
