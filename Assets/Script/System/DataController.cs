using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataController : Singleton<DataController>
{
    private PlayerData playerData;
    [SerializeField]
    private string saveDirectory;
    private string playerName;
    public string PlayerName
    {
        get { return playerName; }
        set { playerName = value; }
    }

    public override void init()
    {
        DontDestroyOnLoad(this.gameObject);
        MakeDirectory();
    }

    private void MakeDirectory()
    {
        saveDirectory = Path.Combine(Application.persistentDataPath, "playerData");
        if (!Directory.Exists(saveDirectory))
        {
            Directory.CreateDirectory(saveDirectory);
        }
    }



    [ContextMenu("To Json Data")]
    public void SavePlayerData()
    {
        string jsonData = JsonUtility.ToJson(playerData);
        string savePath = Path.Combine(saveDirectory, playerData.name + "Data.json");
        File.WriteAllText(savePath, jsonData);
    }

    [ContextMenu("Load Data")]
    public void LoadPlayerData()
    {
        string savePath = Path.Combine(saveDirectory, playerName + "Data.json");
        string data = File.ReadAllText(savePath);
        playerData = JsonUtility.FromJson<PlayerData>(data);
    }


}
