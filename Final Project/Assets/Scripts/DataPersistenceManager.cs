using UnityEngine;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

public class DataPersistenceManager : MonoBehaviour
{
    public static DataPersistenceManager instance{get; private set;}
    private LapData lapData;
    private List<IDataPersistence> dataPersistenceObjects;


    private void Awake(){
        instance = this;
    }

    public void Start(){
        this.dataPersistenceObjects = findObjects();
        LoadGame();
    }
    
    public void NewGame(){
        this.lapData = new LapData();
    }

    public void LoadGame(){
        foreach (IDataPersistence dpObject in dataPersistenceObjects)
        {
            dpObject.LoadData(lapData);
        }

    }

    public void SaveGame(){
        foreach (IDataPersistence dpObject in dataPersistenceObjects)
        {
            dpObject.SaveData(ref lapData);
        }

        Debug.Log("load " + lapData.L1);
        Debug.Log("load " + lapData.L2);
        Debug.Log("load " + lapData.L3);
    }

    private void OnApplicationQuit(){
        SaveGame();
    }

    

    private List<IDataPersistence> findObjects(){
        IEnumerable<IDataPersistence> dataPersistenceObjects = FindObjectsOfType<MonoBehaviour>().OfType<IDataPersistence>();

        return new List<IDataPersistence>(dataPersistenceObjects);
    }

}
