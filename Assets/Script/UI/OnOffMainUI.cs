using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnOffMainUI : AddUIButtonEvent
{
    private AutoFlip autoFlip;

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
        AddButtonEvent("Album/AlbumOff", () =>
        {
            if (!autoFlip.isFlipping)
                SetTargetView(LobbyManager.Instance.ObjectDictionary["Album"], false);
        });
        //AddButtonEvent("Setting/SettingOffButton", () => SetTargetView(LobbyManager.Instance.ObjectDictionary["Setting"], false));
    }


    #endregion

    #region Event


    #endregion
}
