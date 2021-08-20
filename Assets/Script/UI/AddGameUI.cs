using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddGameUI : MonoBehaviour
{
    public void Add()
    {
        foreach (GameObject child in transform)
        {
            GameUIManager.Instance.ObjectDictionary.Add(child.name, child);
            Debug.Log(child);
        }
    }
    
}
