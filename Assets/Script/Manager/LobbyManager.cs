using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LobbyManager : Singleton<LobbyManager>
{
    public Dictionary<UIList, AddUIEvent> UIListDirctionary = new Dictionary<UIList, AddUIEvent>();
    public Dictionary<string, GameObject> ObjectDirctory = new Dictionary<string, GameObject>();
    public override void Init()
    {
        AddDictionary(UIList.LobbyUI, "LobbyUI", "LobbyController");
        AddDictionary(UIList.OnOffMenuUI, "OnOffMenuUI", "UIOnOffController", false);
        //AddDictionary(UIList.OptionUI, "OptionUI", "LobbyOptionUI");
        //AddDictionary(UIList.CollectionUI, "CollectionUI", "LobbyCollectionUI");
    }
    private void Start()
    {
        foreach (var data in UIListDirctionary)
        {
            if (data.Value)
                data.Value.Init();
        }
    }

    /// <summary>
    /// 딕셔너리에 추가하는 메소드
    /// </summary>
    /// <param name="path">transform에서 있을 위치</param>
    /// <param name="script">다운캐스팅시 넣어야할 스크립트(없으면 디폴트)</param>
    public void AddDictionary(UIList UiName, string path, string script = "", bool state = true)
    {
        if (!string.IsNullOrEmpty(script))
        {
            UIListDirctionary.Add(UiName, transform.Find(path).gameObject.AddComponent(System.Type.GetType(script)) as AddUIEvent);
        }
        else
        {
            UIListDirctionary.Add(UiName, transform.Find(path).GetComponent<AddUIEvent>());
        }
        transform.Find(path).gameObject.AddComponent<AddDictionary>();
        foreach (Transform child in transform.Find(path))
        {
            child.gameObject.SetActive(state);
        }
    }
    public void AddDictionary(string ObjectName, Transform transform)
    {
        ObjectDirctory.Add(ObjectName, transform.gameObject);
    }
    public void SetUI(UIList state, bool active)
    {
        if (UIListDirctionary.ContainsKey(state))
        {
            UIListDirctionary[state].SetView(active);
        }
    }
    public void SetUI(string GameObjectName, bool active)
    {
        if (ObjectDirctory.ContainsKey(GameObjectName))
        {
            ObjectDirctory[GameObjectName].SetActive(active);
        }
    }
}
