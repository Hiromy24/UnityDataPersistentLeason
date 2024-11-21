using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PersistentManager : MonoBehaviour
{
    public static PersistentManager pManager;
    public  string Username;
    public int RecordScore;
    private void Awake()
    {
        LoadRecordScore();
        if (pManager == null)
        {
            pManager = this;
            DontDestroyOnLoad(this);
        }
        
    }

    class SaveData
    {
        public string Username;
        public int RecordScore;
    }

    public void LoadRecordScore()
    {
        string path = Application.persistentDataPath + "/RecordScore.txt";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            Username = data.Username;
            RecordScore = data.RecordScore;
        }
    }
    public void SaveRecordScore()
    {
        SaveData data = new SaveData();
        data.Username = Username;
        data.RecordScore = RecordScore;
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/RecordScore.json", json);
    }
    
}
