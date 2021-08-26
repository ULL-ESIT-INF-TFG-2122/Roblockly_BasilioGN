// Used in Statistics manager script.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChallengeSolution : MonoBehaviour
{
    private string solutionID;
    private bool bestTime; // Indicates if the solution has been solved in the shortest time
    private bool bestBlocks; // Indicates if the solution has been solved with the least number of blocks.
    private string solutionTime; // Time elapsed to solve the challenge
    private float elapsedMinutes;
    private int blocksNumber; // Number of blocks used to solve the challenge
    private float progress; // Percentage of proximity to the optimal solution of the challenge

    public string GetSolutionID()
    {
        return solutionID;
    }

    public void SetSolutionID(string newSolutionID)
    {
        solutionID = newSolutionID;
    }

    public bool GetBestTime()
    {
        return bestTime;
    }

    public void SetBestTime(bool newBestTime)
    {
        bestTime = newBestTime;
    }

    public bool GetBestBlocks()
    {
        return bestBlocks;
    }

    public void GetBestBlocks(bool newBestBlocks)
    {
        bestBlocks = newBestBlocks;
    }

    public string GetSolutionTime()
    {
        return solutionTime;
    }

    public void SetSolutionTime(string newSolutionTime)
    {
        solutionTime = newSolutionTime;
    }

    public float GetElapsedMinutes()
    {
        return elapsedMinutes;
    }

    public void SetElapsedMinutes(float newElapsedMinutes)
    {
        elapsedMinutes = newElapsedMinutes;
    }

    public int GetBlocksNumber()
    {
        return blocksNumber;
    }

    public void SetBlocksNumber(int newBlocksNumber)
    {
        blocksNumber = newBlocksNumber;
    }

    public float GetProgress()
    {
        return progress;
    }

    public void SetProgress(float newProgress)
    {
        progress = newProgress;
    }
}
