using UnityEngine;
using UnityEngine.SceneManagement;

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


}
