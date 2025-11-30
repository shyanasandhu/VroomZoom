using UnityEngine;

public interface IDataPersistence 
{
    void LoadData(LapData data);
    void SaveData(ref LapData data);
}
