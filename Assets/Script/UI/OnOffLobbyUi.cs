using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnOffLobbyUi : AddUIButtonEvent
{
    #region field
    #endregion

    #region InheritanceFunction
    public override void Init()
    {
        FindGameObject();
        Set();
    }

    private void FindGameObject()
    {

    }
    #endregion

    #region Function
    /// <summary>
    /// 이벤트 할당을 위해 Init 에서 실행하는 함수
    /// </summary>
    public override void Set()
    {

        //AddButtonEvent("Credit/CreditOffButton", () => SetTargetView(LobbyManager.Instance.ObjectDictionary["Credit"], false));
        //AddButtonEvent("Setting/SettingOnOffMenu", () => SetTargetView(LobbyManager.Instance.ObjectDictionary["Setting"], false));
        //AddButtonEvent("GameStart/LoadOffButton", () => SetTargetView(LobbyManager.Instance.ObjectDictionary["GameStart"], false));
    }


    #endregion

    #region Event


    #endregion
}
