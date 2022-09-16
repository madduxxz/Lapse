using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using TMPro;
public class JsonReadWriteSystem : MonoBehaviour
{
    public int yearCount;
    public int yearText;
    public int dayCount;
    public static JsonReadWriteSystem Instance { get; private set;}

    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }
    public void SaveToJson()
    {
        
        GameData data = new GameData();
        data.yearPassed = yearCount;
        data.yearPassed = yearText;
        data.dayPassed = dayCount;

        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(Application.dataPath + "/GameDataFile.json", json);

    }

    public void LoadFromJson()
    {
        string json = File.ReadAllText(Application.dataPath + "/GameDataFile.json");
        GameData data = JsonUtility.FromJson<GameData>(json);

        yearCount = data.yearPassed;
        dayCount = data.dayPassed;
        

    }
}
