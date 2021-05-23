using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LobbyController : AddUIEvent
{
    private GameObject[] gamedatas;
    public override void Init()
    {
        SetName();
        Set();
    }
    public override void Set()
    {
        AddButtonEvent("GameStartButton", () =>
        {
            SetView(false);
            SetView(LobbyManager.Instance.ObjectDirctory["Load"], true);
        });
        AddButtonEvent("CreidtButton", () =>
        {
            SetView(false);
            SetView(LobbyManager.Instance.ObjectDirctory["Credit"], true);
        });
        AddButtonEvent("SettingButton", () =>
        {
            SetView(false);
            SetView(LobbyManager.Instance.ObjectDirctory["Setting"], true);
        });
        AddButtonEvent("ExitButton", () => ExitGame());
    }

    /// <summary>
    /// 데이터 로드 매뉴 불러오기
    /// </summary>
    private void SetName()
    {
        var playerName = PlayerData.Instance.PlayerName.playerData;
        for (int i = 0; i < playerName.Length; i++)
        {
            if (playerName[i] == null)
            {
                Debug.Log("데이터 존재");
                // SetText(LobbyManager.Instance.ObjectDirctory[$"Data{i + 1}"], "새 데이터 만들기");
                // AddButtonEvent(gamedatas[i], MakeNewData);
            }
            else
            {
                // SetText(LobbyManager.Instance.ObjectDirctory[$"Data{i + 1}"], playerName[i].name);
                // AddButtonEvent(gamedatas[i], LoadData);
            }
        }
    }


    #region Event
    private void MakeNewData()
    {
        //데이터 생성
        LoadScene(SceneName.inGame);
    }
    private void LoadData()
    {
        //데이터 할당
        LoadScene(SceneName.inGame);
    }


    #endregion
}
