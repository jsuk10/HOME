using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class PlayerDataController : Singleton<PlayerDataController>
{
    private PlayerDataClass playerData;
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

    /// <summary>
    /// 경로를 만들어주는 메소드
    /// 지정된 없을시 경로를 만들고 만들어줌
    /// </summary>
    private void MakeDirectory()
    {
        saveDirectory = Path.Combine(Application.persistentDataPath, "playerData");
        if (!Directory.Exists(saveDirectory))
        {
            Directory.CreateDirectory(saveDirectory);
        }
    }


    /// <summary>
    /// 플레이어 데이터 자정
    /// </summary>
    [ContextMenu("To Json Data")]
    public void SavePlayerData()
    {
        string jsonData = JsonUtility.ToJson(playerData);
        string savePath = Path.Combine(saveDirectory, playerData.name + "Data.json");
        File.WriteAllText(savePath, jsonData);
    }

    /// <summary>
    /// 플레이어 데이터 불러오기
    /// </summary>
    [ContextMenu("Load Data")]
    public void LoadPlayerData()
    {
        string savePath = Path.Combine(saveDirectory, playerName + "Data.json");
        string data = File.ReadAllText(savePath);
        playerData = JsonUtility.FromJson<PlayerDataClass>(data);
    }


}
