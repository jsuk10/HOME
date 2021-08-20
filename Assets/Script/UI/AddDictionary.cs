using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 리스트에 넣어야 하는 것들 상위 오브젝트에 넣어줘야함.
/// 하위 오브젝트를 찾아서 Lobby의 딕셔너리에 추가하는 함수
/// </summary>
public class AddDictionary : MonoBehaviour
{
    

    protected void Awake()
    {
        AddDictionaryChild(transform);
    }


    public void AddDictionaryChild(Transform tr)
    {
        foreach (Transform child in tr)
        {
            LobbyManager.Instance.AddObjectDictionary(child.gameObject.name, child);
        }
    }
}