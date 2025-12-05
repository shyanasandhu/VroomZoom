using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class Buttons : MonoBehaviour
{
    public void cTrack(){
        SceneManager.LoadScene("CityTrack");
    }

    public void rTrack(){
        SceneManager.LoadScene("RaceTrack");
    }

    public void lTimes(){
        SceneManager.LoadScene("LapTimes");
    }

    public void home(){
        SceneManager.LoadScene("WelcomePage");
    }

    private void saveScene(){
        string currScene = SceneManager.GetActiveScene().name;
        PlayerPrefs.SetString("lastSceneName", currScene);
        PlayerPrefs.Save();

    }

    public void resume(){
        if(PlayerPrefs.HasKey("lastSceneName")){ 
            string lastScene = PlayerPrefs.GetString("lastSceneName");
            SceneManager.LoadScene(lastScene);
        }
    }

    public void pause(){
        saveScene();
        SceneManager.LoadScene("Pause");
    }

    public void exit(){
        SceneManager.LoadScene("WelcomePage");
    }

    public void quit(){
        Application.Quit();
        Debug.Log("quit");
    }

    private void OnApplicationQuit()
    {
        saveScene();
    }



}
