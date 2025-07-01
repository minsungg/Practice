using System;
using UnityEngine;

using System.IO;
using Unity.VisualScripting;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance;
    public int number;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        } else
        {
            Destroy(gameObject);
        }

        LoadNumber();
    }

    private void OnApplicationQuit()
    {
        SaveNumber();
    }

    [System.Serializable]
    class SaveData
    {
        public int _number;
    }

    public void SaveNumber()
    {
        SaveData saveData = new SaveData();
        saveData._number = number;

        string json = JsonUtility.ToJson(saveData);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadNumber()
    {
        string path = Application.persistentDataPath + "/savefile.json";

        if(File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData saveData = JsonUtility.FromJson<SaveData>(json);

            number = saveData._number;
        }
    }
}