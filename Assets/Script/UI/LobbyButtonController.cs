using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LobbyButtonController : AddUIButtonEvent
{
    #region field
    private GameObject[] gamedatas;
    #endregion
    #region InheritanceFunction
    public override void Init()
    {
        // SetName();
        FindGameObject();
        Set();
    }

    private void FindGameObject()
    {
        ButtonList.Add(LobbyManager.Instance.ObjectDictionary["GameStartButton"]);
        ButtonList.Add(LobbyManager.Instance.ObjectDictionary["ReloadButton"]);
        ButtonList.Add(LobbyManager.Instance.ObjectDictionary["SettingButton"]);
        ButtonList.Add(LobbyManager.Instance.ObjectDictionary["ExitButton"]);
    }
    #endregion

    #region Function
    /// <summary>
    /// 이벤트 할당을 위해 Init 에서 실행하는 함수
    /// </summary>
    public override void Set()
    {
        AddButtonEvent("GameStartButton", () =>
        {
            //신로드하기
            //데이터 초기화
            SoundManager.Instance.SFXPlayer("StartButton");
        });
        //로드버튼에 이벤트주기
        //AddButtonEvent("ReloadButton", () => SetTargetView(LobbyManager.Instance.ObjectDictionary["ReloadButton"], true));
        AddButtonEvent("SettingButton", () => SetTargetView(LobbyManager.Instance.ObjectDictionary["Setting"], true));
        AddButtonEvent("ExitButton", () => ExitGame());

        SetButtonHoverSound();
    }


    /// <summary>
    /// 데이터 로드 매뉴 불러오기
    /// </summary>
    // private void SetName()
    // {
    //     var playerName = PlayerData.Instance.PlayerName.playerData;
    //     for (int i = 0; i < playerName.Length; i++)
    //     {
    //         if (playerName[i] == null)
    //         {
    //             Debug.Log("데이터 존재");
    //             // SetText(LobbyManager.Instance.ObjectDirctory[$"Data{i + 1}"], "새 데이터 만들기");
    //             // AddButtonEvent(gamedatas[i], MakeNewData);
    //         }
    //         else
    //         {
    //             Debug.Log("데이터 없음 ");

    //             // SetText(LobbyManager.Instance.ObjectDirctory[$"Data{i + 1}"], playerName[i].name);
    //             // AddButtonEvent(gamedatas[i], LoadData);
    //         }
    //     }
    // }
    #endregion

    #region Event

    #endregion
}
