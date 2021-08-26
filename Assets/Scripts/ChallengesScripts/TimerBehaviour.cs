using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerBehaviour : MonoBehaviour
{

    public Text timerText;
    private float startTime;
    private bool timeFinished = false;
    private bool runTimer = false;
    // Start is called before the first frame update
    void Start()
    {
        StartTimer();
        CoinRotation.StopTimer = TimerFinish;
    }

    // Update is called once per frame
    void Update()
    {
        if (runTimer)
        {
            ConvertTimerToString();
        }
    }

    public void StartTimer()
    {
        ResetTimer();
        startTime = Time.time;
        runTimer = true;
    }

    public void ResetTimer()
    {
        timeFinished = false;
        //runTimer = false;
        timerText.text = "00:00:00";
        timerText.color = Color.black;
    }

    public List<float> TimerFunction()
    {
        List<float> timerParts = new List<float>();
        if (!timeFinished)
        {
            float currentTime = Time.time - startTime;
            float minutes = ((int) currentTime / 60);
            float seconds = (currentTime % 60);
            timerParts.Add(minutes);
            timerParts.Add(seconds);
        }
        return timerParts;
    }

    private void ConvertTimerToString()
    {
        List<float> currentTime = TimerFunction();
        string minutes = currentTime[0].ToString("f0");
        string seconds = currentTime[1].ToString("f2");
        string[] secondsParts = seconds.Split(',');
        timerText.text = minutes + ":" + secondsParts[0] + ":" + secondsParts[1];
    }

    public string GetTimeString()
    {
        return timerText.text;
    }

    public void TimerFinish()
    {
        timeFinished = true;
        runTimer = false;
        timerText.color = Color.red;
    }
}
