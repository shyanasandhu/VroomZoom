using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;


/*public class LapTime : MonoBehaviour
{
    public GameObject SF;
    public int count = 0;
    public float delay = 5;
    private bool startT = false;


    public void OnTriggerEnter(Collider other){
        if(other.CompareTag("SFLine")){
            count += 1;
            recordTime();

            if(count == 5){
                EventManager.onTimerStop();
                StartCoroutine(RunEnd(delay));
            }

            if(!startT){
                EventManager.onTimerStart();
                startT = true;
            }
            


        }
    }

    private void recordTime(){

    }

    IEnumerator RunEnd(float delay){
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene("LapTimes");
    }
}
*/