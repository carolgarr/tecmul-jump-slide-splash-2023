using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimerController : MonoBehaviour
{
    public TMP_Text timerText;

    private float currentTime;

    private bool countTime;

    void Start()
    {
        timerText.text = "Time: 00:00.00";
        countTime = true;
        

    }

    void Update()
    {
        if (countTime)
        {
            currentTime += Time.deltaTime;

            TimeSpan time = TimeSpan.FromSeconds(currentTime);

            timerText.text = "Time: "+time.ToString(@"mm\:ss\:fff");
        }
    }

    public void StartTimer(){
        currentTime = 0.0f;
        countTime = true;
    }
    public void ResumeTimer(){
        countTime = true;
    }
    public void PauseTimer(){
        countTime = false;
    }
    public void ResetTimer(){
        currentTime = 0.0f;
        countTime = false;
    }


}
