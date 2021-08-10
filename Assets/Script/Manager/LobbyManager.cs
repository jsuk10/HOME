using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LobbyManager : Singleton<LobbyManager>
{
    #region field
    public Dictionary<UIList, AddUIButtonEvent> UIListDirctionary = new Dictionary<UIList, AddUIButtonEvent>();
    public Dictionary<string, GameObject> ObjectDirctory = new Dictionary<string, GameObject>();
    #endregion

    #region InheritanceFunction
    public override void Init()
    {
        AddUIDictionary(UIList.LobbyUI, "LobbyUI", "LobbyButtonController");
        AddUIDictionary(UIList.OnOffMenuUI, "OnOffMenuUI", "OnOffUiController", false);
        //AddDictionary(UIList.OptionUI, "OptionUI", "LobbyOptionUI");
        //AddDictionary(UIList.CollectionUI, "CollectionUI", "LobbyCollectionUI");
    }
    #endregion

    #region Function
    private void Start()
    {
        //각 객체에 있는 Init을 실행시켜 하위 오브젝트에 해당하는 이벤트를 추가시켜줌
        foreach (var data in UIListDirctionary)
        {
            if (data.Value)
                data.Value.Init();
        }
        SoundManager.Instance.SFXPlayer("Intro");
    }

    /// <summary>
    /// 딕셔너리에 추가하는 메소드
    /// UIList에 해당하는 객체에 AddUIButtonEvent를 추가해서 하위 오브젝트에 이벤트를 추가해
    /// </summary>
    /// <param name="path">transform에서 있을 위치</param>
    /// <param name="script">넣어줘야 하는 스크립트, AddUIButtonEvent를 상속하여야함.</param>
    /// <param name="state">setState 상태</param>
    public void AddUIDictionary(UIList UiName, string path, string script = "", bool state = true)
    {
        AddUIButtonEvent ButtonEvent = new AddUIButtonEvent();
        GameObject uiGameObject = transform.Find(path).gameObject;

        //이미 컴포넌트가 있는 경우를 고려하여 try catch사용하여 컴포넌트를 추가해줌
        try
        {
            if (!string.IsNullOrEmpty(script))
            {
                ButtonEvent = uiGameObject.AddComponent(System.Type.GetType(script)) as AddUIButtonEvent;
            }
            else
            {
                ButtonEvent = uiGameObject.AddComponent<AddUIButtonEvent>();
            }
        }
        catch (UnityException e)
        {
            Debug.Log(e);
            ButtonEvent = uiGameObject.GetComponent<AddUIButtonEvent>();
        }

        finally
        {
            UIListDirctionary.Add(UiName, ButtonEvent);

        }

        //하위 오브젝트를 추가하기 위한 방법
        uiGameObject.AddComponent<AddDictionary>();

        foreach (Transform child in transform.Find(path))
        {
            child.gameObject.SetActive(state);
        }
    }

    /// <summary>
    /// 오브젝트를 딕셔너리에 추가하는 메소드
    /// 게임 오브젝트를 직접 추가할 경우 쓰는 오브젝트
    /// </summary>
    /// <param name="ObjectName"></param>
    /// <param name="transform"></param>
    public void AddObjectDictionary(string ObjectName, Transform transform)
    {
        ObjectDirctory.Add(ObjectName, transform.gameObject);
    }

    #endregion
}
