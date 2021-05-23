using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 리스트에 넣어야 하는 것들 상위 오브젝트에 넣어줘야함.
/// </summary>
public class AddDictionary : MonoBehaviour
{
    protected void Awake()
    {
        foreach (Transform child in transform)
        {
            LobbyManager.Instance.AddDictionary(child.gameObject.name, child);
        }
    }
}
