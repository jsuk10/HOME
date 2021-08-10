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
    private  List<GameObject> ButtonList = new List<GameObject>();
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
        ButtonList.Add(LobbyManager.Instance.ObjectDirctory["GameStartButton"]);
        ButtonList.Add(LobbyManager.Instance.ObjectDirctory["CreidtButton"]);
        ButtonList.Add(LobbyManager.Instance.ObjectDirctory["SettingButton"]);
        ButtonList.Add(LobbyManager.Instance.ObjectDirctory["ExitButton"]);
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
            SetTargetView(LobbyManager.Instance.ObjectDirctory["GameStart"], true);
            SoundManager.Instance.SFXPlayer("StartButton");
        });
        AddButtonEvent("CreidtButton", () => SetTargetView(LobbyManager.Instance.ObjectDirctory["Credit"], true));
        AddButtonEvent("SettingButton", () => SetTargetView(LobbyManager.Instance.ObjectDirctory["Setting"], true));
        AddButtonEvent("ExitButton", () => ExitGame());

        SetByttonHoverSound();
    }

    private void SetByttonHoverSound()
    {
        foreach (var button in ButtonList) {
            var eventTrigger = AddEventTrigger(button);
            var animator = GetAnimator(button);
            AddButtonTriggerEvent(eventTrigger, EventTriggerType.PointerEnter, () =>
            {
                //animator.Play("hover");
                SoundManager.Instance.SFXPlayer("MenuButtonHover");
            });
            AddButtonTriggerEvent(eventTrigger, EventTriggerType.PointerExit, () =>
            {
                //animator.Play("default");
            });
        }
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
