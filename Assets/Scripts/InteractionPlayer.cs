using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionPlayer : Singleton<InteractionPlayer>
{
    List<ObjectInteractable> listObject;

    public override void Init()
    {
        listObject = new List<ObjectInteractable>();
    } 

    
    void Start()
    {
        StartCoroutine("InputProcess");
    }

    /// <summary>
    /// 입력 처리, 상호작용 키를 누르면 큐에서 오브젝트를 반환하여 상호작용 함수 호출
    /// </summary>
    public IEnumerator InputProcess()
    {
        while(true)
        {
            if(Input.GetKey(KeyCode.E))
            {
                Debug.Log($"{listObject.Count}");
                if(listObject.Count >= 0)
                {
                    var popedObject = PopObject(listObject[0]);
                    popedObject.Interaction();
                    popedObject.IsEnqueued = false;
                }
            }
            yield return new WaitForSeconds(0.3f);
        }
    }

    /// <summary>
    /// 외부에서 Enqueue할때 쓰는 함수. 충돌 상태일때 오브젝트가 스스로를 삽입 요청
    /// </summary>
    /// <param name="objectInteractable"></param>
    public void AddObject(ObjectInteractable objectInteractable)
    {
        listObject.Add(objectInteractable);
    }

    /// <summary>
    /// 외부에서 Dequeue할때 쓰는 함수. 일정 범위를 벗어낫을때 오브젝트가 스스로를 반환 요청
    /// </summary>
    /// <returns></returns>
    public ObjectInteractable PopObject(ObjectInteractable objectInteractable)
    {
        int tempObjectIndex = listObject.FindIndex(x => x == objectInteractable);
        var tempObject = listObject[tempObjectIndex];
        listObject.RemoveAt(tempObjectIndex);

        return tempObject;
    }
}