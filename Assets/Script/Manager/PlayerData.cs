using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class PlayerData : Singleton<PlayerData>
{
    private string saveDirectory;
    [SerializeField]
    private PlayerNameClass playerName;

    public PlayerNameClass PlayerName
    {
        get { return playerName; }
    }

    public override void Init()
    {
        DontDestroyOnLoad(this);
        SetDirectory();
        LoadPlayerData();
    }

    private void SetDirectory()
    {
        saveDirectory = Path.Combine(Application.persistentDataPath, "PlayerData");
        if (!Directory.Exists(saveDirectory))
        {
            Directory.CreateDirectory(saveDirectory);
        }
    }

    //PlayerNameClass;
    [ContextMenu("To Json Data")]
    public void SavePlayerData()
    {
        string jsonData = JsonUtility.ToJson(playerName);
        saveDirectory = Path.Combine(Application.persistentDataPath, "PlayerData");
        string savePath = Path.Combine(saveDirectory, "PlayerNamesData.json");
        File.WriteAllText(savePath, jsonData);
    }

    /// <summary>
    /// 플레이어 데이터를 로드하여 함수
    /// </summary>
    [ContextMenu("Load Data")]
    private void LoadPlayerData()
    {
        {
            string savePath = Path.Combine(saveDirectory, "PlayerNamesData.json");
            if (new FileInfo(savePath).Exists)
            {
                string data = File.ReadAllText(savePath);
                playerName = JsonUtility.FromJson<PlayerNameClass>(data);
            }
            else
            {
                playerName = new PlayerNameClass();
            }

            for (int i = 0; i < playerName.playerData.Length; i++)
            {
                if (playerName.playerData[i].name == "" || playerName.playerData[i].name == null)
                {
                    playerName.playerData[i].name = null;
                }
            }
        }
    }

}