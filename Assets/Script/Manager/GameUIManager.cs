using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUIManager : LobbyManager
{
    public override void Init()
    {
        AddUIDictionary(UIList.MainUI, "MainUI", true, "InGameButtonController");
        AddUIDictionary(UIList.OnOffUI, "OnOffMainUI", false, "OnOffMainUI");
    }


    public void PlayBackGoundSound()
    {
        SoundManager.Instance.PlayBackGroundSound(Stage.Kitchen);
    }
}
