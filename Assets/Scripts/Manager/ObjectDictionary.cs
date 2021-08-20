using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 상호작용 가능한 오브젝트를 저장하는 딕셔너리
/// </summary>
public class ObjectDictionary : Singleton<ObjectDictionary>
{
    Dictionary<string , ObjectInteractable> objectDictionary;

    public int Count {get {return objectDictionary.Count;}}
    public override void Init()
    {
        objectDictionary = new Dictionary<string, ObjectInteractable>();
    }

    /// <summary>
    /// Object를 딕셔너리에 추가
    /// </summary>
    /// <param name="objectInteractable"></param>
    public void AddObject(ObjectInteractable objectInteractable)
    {
        Debug.Log(objectInteractable.gameObject.name);
        objectDictionary.Add(objectInteractable.gameObject.name, objectInteractable);
    }

    /// <summary>
    /// name으로 검색해서 반환
    /// </summary>
    /// <param name="objectName"></param>
    /// <returns></returns>
    public ObjectInteractable FindObject(string objectName)
    {
        return objectDictionary[objectName];
    }

}
