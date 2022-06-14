using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Timer : MonoBehaviour
{
    bool timerActive = false;
    [Header("Component")]
    public TextMeshProUGUI timerText;

    [Header("Timer Settings")]
    public float currentTime;
    public int startMinutes;

    [Header("Format Settings")]
    public TimerFormats format;
    private Dictionary<TimerFormats, string> timeFormats = new Dictionary<TimerFormats, string>();
    // Start is called before the first frame update
    void Start()
    {
        // timeFormats.Add(TimerFormats.Whole, "0:00");
        // timeFormats.Add(TimerFormats.TenthDecimal, "0.0");
        // timeFormats.Add(TimerFormats.HundrethsDecimal, "0.00");
        currentTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        TimeSpan time = TimeSpan.FromSeconds(currentTime);
        timerText.text = "Time\n" + time.Hours.ToString("00") + ":" + time.Minutes.ToString("00") + ":" + time.Seconds.ToString("00");
    }

    public void StartTimer(){
        timerActive = true;
    }

    public void StopTimer(){
        timerActive = false;
    }
}

public enum TimerFormats
{
    Whole,
    TenthDecimal,
    HundrethsDecimal
}