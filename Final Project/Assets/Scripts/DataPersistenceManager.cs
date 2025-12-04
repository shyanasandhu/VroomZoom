using UnityEngine;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

public class DataPersistenceManager : MonoBehaviour
{
    public static DataPersistenceManager instance{get; private set;}
    private LapData lapData;
    private List<IDataPersistence> dataPersistenceObjects;
    private FileDataHandler dataHandler;

    [Header("File Storage Config")]
    [SerializeField] private string fileN;




    private void Awake(){
        if(instance != null && instance != this) {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);

        this.dataHandler = new FileDataHandler(Application.persistentDataPath, fileN);
        this.dataPersistenceObjects = findObjects();
        NewGame();
        LoadGame();
    }

    /*public void Start(){
        this.dataHandler = new FileDataHandler(Application.persistentDataPath, fileN);
        this.dataPersistenceObjects = findObjects();
        NewGame();
        LoadGame();
    }*/
    
    public void NewGame(){
        this.lapData = new LapData();
    }

    public void LoadGame(){
        this.lapData = dataHandler.Load();

        if(lapData == null) lapData = new LapData();

        foreach (IDataPersistence dpObject in dataPersistenceObjects)
        {
            dpObject.LoadData(lapData);
        }

        Debug.Log("load " + lapData.L1);
        Debug.Log("load " + lapData.L2);
        Debug.Log("load " + lapData.L3);

    }

    public void SaveGame(){
        foreach (IDataPersistence dpObject in dataPersistenceObjects)
        {
            dpObject.SaveData(ref lapData);
        }

        dataHandler.Save(lapData);

        Debug.Log("save " + lapData.L1);
        Debug.Log("save " + lapData.L2);
        Debug.Log("save " + lapData.L3);
    }

    public LapData GetLData(){
        return lapData;
    }

    private void OnApplicationQuit(){
        SaveGame();
    }

    

    private List<IDataPersistence> findObjects(){
        IEnumerable<IDataPersistence> dataPersistenceObjects = FindObjectsOfType<MonoBehaviour>(true).OfType<IDataPersistence>();

        return new List<IDataPersistence>(dataPersistenceObjects);
    }

}
