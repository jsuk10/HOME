using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


/// <summary>
/// 플레이어들의 데이터를 관리해주는 스크립트
/// 차후에 제거 해도 될거 같음 물어볼것.
/// </summary>
public class PlayerDataController : Singleton<PlayerDataController>
{
    #region Field
    private PlayerDataClass playerData;
    private string saveDirectory;
    private string playerName;
    public string PlayerName
    {
        get { return playerName; }
        set { playerName = value; }
    }
    #endregion

    #region InheritanceFunction
    public override void Init()
    {
        DontDestroyOnLoad(this.gameObject);
        MakeDirectory();
        LoadPlayerData();
    }
    #endregion

    #region Function
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
        FileInfo fi = new FileInfo(savePath);
        // if(new FileInfo(savePath))
        if (fi.Exists)
        {
            playerData = JsonUtility.FromJson<PlayerDataClass>(File.ReadAllText(savePath));
        }
        else
            playerData = new PlayerDataClass();

    }
    #endregion
}
