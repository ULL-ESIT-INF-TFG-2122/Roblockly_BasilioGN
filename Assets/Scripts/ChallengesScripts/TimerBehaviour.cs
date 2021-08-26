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
            TimerFunction();
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

    private void TimerFunction()
    {
        if (timeFinished)
        {
            return;
        }
        float currentTime = Time.time - startTime;
        string minutes = ((int) currentTime / 60).ToString();
        string seconds = (currentTime % 60).ToString("f2");
        string[] secondsParts = seconds.Split(','); // 0 -> seconds and 1 -> miliseconds.

        timerText.text = minutes + ":" + secondsParts[0] + ":" + secondsParts[1];
    }

    public void TimerFinish()
    {
        timeFinished = true;
        runTimer = false;
        timerText.color = Color.red;
    }
}
