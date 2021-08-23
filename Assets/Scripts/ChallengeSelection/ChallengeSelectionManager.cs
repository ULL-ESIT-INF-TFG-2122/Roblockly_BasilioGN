using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChallengeSelectionManager : MonoBehaviour
{
    public void SelectLabyrinthChallenge()
    {
        PlayerPrefs.SetInt("SelectedChallenge", 1);
    }
    public void SelectIRChallenge()
    {
        PlayerPrefs.SetInt("SelectedChallenge", 2);
    }
    public void SelectColorChallenge()
    {
        PlayerPrefs.SetInt("SelectedChallenge", 3);
    }
    public void SelectBalanceChallenge()
    {
        PlayerPrefs.SetInt("SelectedChallenge", 4);
    }

    public void GoForward()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void GoBack()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
