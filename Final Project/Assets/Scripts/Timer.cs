using UnityEngine;
using System;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;

public class Timer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;
    private bool isRunning = false;
    private float displayTime;
    private int count = 0;

    private void Awake(){
        isRunning = false;
        displayTime = 0f;
    }

    private void OnEnable(){
        EventManager.TimerStart += EventManagerOnTimerStart;
        EventManager.TimerStop += EventManagerOnTimerStop;
    }

    private void OnDisable(){
        EventManager.TimerStart -= EventManagerOnTimerStart;
        EventManager.TimerStop -= EventManagerOnTimerStop;
    }
    
    private void EventManagerOnTimerStart() => isRunning = true;

    private void EventManagerOnTimerStop() => isRunning = false;

    private void Update(){
        if(isRunning){
            displayTime += Time.deltaTime;

            TimeSpan tSpan = TimeSpan.FromSeconds(displayTime);
            timerText.text = tSpan.ToString(@"mm\:ss\:ff");
            count++;

        }
    }

    public void sTimer(){
        isRunning = true;
        displayTime = 0f;
    }

    public void rTime(){
        displayTime = 0f;
    }

    public void endL(){
        isRunning = false;
        timerText.text = "LAPS FINISHED";
    }

    public void recordTime(){

    }


}
