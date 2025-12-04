using UnityEngine;
using System;
using System.IO;

public class FileDataHandler 
{
    private string dataDir = "";
    private string dataFile = "";

    public FileDataHandler(string dataDir, string dataFile){
        this.dataDir = dataDir;
        this.dataFile = dataFile;
    }


    public LapData Load(){
        string path = Path.Combine(dataDir, dataFile);
        LapData lData = null;

        if(File.Exists(path)){
            try
            {
                string dataload = "";
                
                using(FileStream s = new FileStream(path, FileMode.Open)){
                    using(StreamReader r = new StreamReader(s)){
                        dataload = r.ReadToEnd();
                    }
                }

                lData = JsonUtility.FromJson<LapData>(dataload);
            }
            catch (System.Exception)
            {
                
                throw;
            }

        }
        return lData;


    }

    public void Save(LapData data){
        string path = Path.Combine(dataDir, dataFile);

        try
        {
            Directory.CreateDirectory(Path.GetDirectoryName(path));

            string storeData = JsonUtility.ToJson(data, true);

            using(FileStream s = new FileStream(path, FileMode.Create)){
                using(StreamWriter w = new StreamWriter(s)){
                    w.Write(storeData);
                }
            }
        }
        catch (System.Exception)
        {
            
            Debug.LogError("Save file error: " + path);
        }

    }
}
