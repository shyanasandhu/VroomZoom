using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using TMPro;


public class LapTime : MonoBehaviour
{
    [SerializeField] private Transform displayA;
    [SerializeField] private TextMeshProUGUI lapText;

    private void Start()
    {

        Debug.Log("LapScrollDisplay started");
        LapData data = DataPersistenceManager.instance.GetLData();
        Debug.Log("Loaded data: " + JsonUtility.ToJson(data));

        displayL(data);

    }

    private void displayL(LapData data){
        foreach(Transform c in displayA){
            Destroy(c.gameObject);
        }
        addL("Lap 1: " + displayT(data.L1));
        addL("Lap 2: " + displayT(data.L2));
        addL("Lap 3: " + displayT(data.L3));
    }

    private void addL(string text){
        TextMeshProUGUI newT = Instantiate(lapText, displayA);
        newT.text = text;
    }

    private string displayT(float timeL){
        return System.TimeSpan.FromSeconds(timeL).ToString(@"mm\:ss\:ff");
    }

}
