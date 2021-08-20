using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InGameButtonController : AddUIButtonEvent
{
    private List<GameObject> ButtonList = new List<GameObject>();
    public override void Init()
    {
        // SetName();
        FindGameObject();
        Set();
        SetByttonHoverSound();
    }

    private void FindGameObject()
    {
        ButtonList.Add(LobbyManager.Instance.ObjectDictionary["SettingOnButton"]);
        ButtonList.Add(LobbyManager.Instance.ObjectDictionary["AlbumOnButton"]);
    }

    public override void Set()
    {
        AddButtonEvent("AlbumOnButton", () => SetTargetView(LobbyManager.Instance.ObjectDictionary["Album"], true));
        AddButtonEvent("SettingOnButton", () => SetTargetView(LobbyManager.Instance.ObjectDictionary["Setting"], true));
    }

    private void SetByttonHoverSound()
    {
        foreach (var button in ButtonList)
        {
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
}

