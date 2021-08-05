using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnOffUiController : AddUIButtonEvent
{
    #region field
    private GameObject[] gamedatas;
    #endregion
    #region InheritanceFunction
    public override void Init()
    {
        Set();
    }
    #endregion

    #region Function
    /// <summary>
    /// 이벤트 할당을 위해 Init 에서 실행하는 함수
    /// </summary>
    public override void Set()
    {
        AddButtonEvent("Credit/CreditOffButton", () => SetTargetView(LobbyManager.Instance.ObjectDirctory["Credit"], false));
        AddButtonEvent("Setting/SettingOffButton", () => SetTargetView(LobbyManager.Instance.ObjectDirctory["Setting"], false));
        AddButtonEvent("GameStart/LoadOffButton", () => SetTargetView(LobbyManager.Instance.ObjectDirctory["Load"], false));
    }


    #endregion

    #region Event


    #endregion
}
