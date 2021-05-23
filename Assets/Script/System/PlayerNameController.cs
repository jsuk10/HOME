using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class PlayerNameController : Singleton<PlayerNameController>
{
    private string saveDirectory;
    [SerializeField]
    private PlayerName playerName;

    public PlayerName PlayerName
    {
        get { return playerName; }
    }

    public override void init()
    {
        MakeDirectory();
        LoadPlayerName();
    }




    private void MakeDirectory()
    {
        saveDirectory = Path.Combine(Application.persistentDataPath, "PlayerData");
        if (!Directory.Exists(saveDirectory))
        {
            Directory.CreateDirectory(saveDirectory);
        }
    }

    //PlayerName;
    [ContextMenu("To Json Data")]
    public void SavePlayerName()
    {
        string jsonData = JsonUtility.ToJson(playerName);
        saveDirectory = Path.Combine(Application.persistentDataPath, "PlayerData");
        string savePath = Path.Combine(saveDirectory, "PlayerNamesData.json");
        File.WriteAllText(savePath, jsonData);
    }

    [ContextMenu("Load Data")]
    private void LoadPlayerName()
    {
        string savePath = Path.Combine(saveDirectory, "PlayerNamesData.json");
        if (new FileInfo(savePath).Exists)
        {
            string data = File.ReadAllText(savePath);
            playerName = JsonUtility.FromJson<PlayerName>(data);
        }
        else
        {
            playerName = new PlayerName();
        }

        for (int i = 0; i < playerName.playerNames.Length; i++)
        {
            if (playerName.playerNames[i] == "")
            {
                playerName.playerNames[i] = null;
            }
        }
    }

}
