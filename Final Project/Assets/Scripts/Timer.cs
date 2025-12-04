using UnityEngine;
using System;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;

public class Timer : MonoBehaviour, IDataPersistence
{
    [SerializeField] private TextMeshProUGUI timerText;
    private bool isRunning = false;
    private float displayTime;
    private int count = 0;
    private float L1;
    private float L2;
    private float L3;
    private int lapC;


    private void Awake(){
        isRunning = false;
        displayTime = 0f;
        L1 = 0f;
        L2 = 0f;
        L3 = 0f;
        lapC = 0;

    }

    public void LoadData(LapData data){
        L1 = data.L1;
        L2 = data.L2;
        L3 = data.L3;

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

        }
    }

    public void sTimer(){
        isRunning = true;
        displayTime = 0f;
    }

    public void rTime(){
        isRunning = true;
        displayTime = 0f;
    }

    public void recordLap(){
        lapC++;
        TimeSpan tSpan = TimeSpan.FromSeconds(displayTime);

        if(lapC == 1){
            L1 = (float)tSpan.TotalSeconds;
            //Debug.Log("L1 " + tSpan.ToString(@"mm\:ss\:ff"));
        }else if(lapC == 2){
            L2 = (float)tSpan.TotalSeconds;
            //Debug.Log("L2 " + tSpan.ToString(@"mm\:ss\:ff"));
        }else{
            L3 = (float)tSpan.TotalSeconds;
            //Debug.Log("L3 " + tSpan.ToString(@"mm\:ss\:ff"));
        }

    }

    public void endL(){
        isRunning = false;
        timerText.text = "LAPS FINISHED";
    }

    public void SaveData(ref LapData data){
        data.L1 = this.L1;
        data.L2 = this.L2;
        data.L3 = this.L3;


    }


}
