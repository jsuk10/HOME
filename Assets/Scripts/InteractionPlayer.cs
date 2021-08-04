using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionPlayer : Singleton<InteractionPlayer>
{
    Queue<ObjectInteractable> queueObject;

    public override void init()
    {
        queueObject = new Queue<ObjectInteractable>();
    } 

    
    void Update()
    {
        InputProcess();
    }

    /// <summary>
    /// 입력 처리, 상호작용 키를 누르면 큐에서 오브젝트를 반환하여 상호작용 함수 호출
    /// </summary>
    void InputProcess()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            var dequeuedObject = queueObject.Dequeue();
            if(dequeuedObject != null)
            {
                dequeuedObject.IsEnqueued = false;
                dequeuedObject.Interaction();
            }
        
        }
    }

    /// <summary>
    /// 외부에서 Enqueue할때 쓰는 함수. 충돌 상태일때 오브젝트가 스스로를 삽입 요청
    /// </summary>
    /// <param name="objectInteractable"></param>
    public void EnqueueObject(ObjectInteractable objectInteractable)
    {
        queueObject.Enqueue(objectInteractable);
    }

    /// <summary>
    /// 외부에서 Dequeue할때 쓰는 함수. 일정 범위를 벗어낫을때 오브젝트가 스스로를 반환 요청
    /// </summary>
    /// <returns></returns>
    public ObjectInteractable DequeueObject()
    {
        return queueObject.Dequeue();
    }
}