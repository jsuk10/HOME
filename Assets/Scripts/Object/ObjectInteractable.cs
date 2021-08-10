using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 플레이어와 상호작용 할 수 있는 오브젝트
/// </summary>
public class ObjectInteractable : MonoBehaviour
{
    bool isEnqueued = false;
    public bool IsEnqueued
    {
        get
        {
            return isEnqueued;
        }

        set
        {
            isEnqueued = value;
        }
    }
    
    public delegate void DelInteraction();
    public DelInteraction Interaction;

    private void Start()
    {
        ObjectDictionary.Instance.AddObject(this);
    }

    /// <summary>
    /// 오브젝트와 플레이어가 충돌 상태일때 삽입 여부가 거짓이라면
    /// 삽입 여부를 참으로 전환하고 상호작용 큐에 삽입
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerStay(Collider other) 
    {
        if(other.tag == "Player")
        {
            if(isEnqueued == false)
            {
                isEnqueued = true;
                InteractionPlayer.Instance.AddObject(this);
            }
        }
    }

    /// <summary>
    /// 오브젝트와 플레이가 충돌 상태를 벗어났을 때 삽입되어있는 오브젝트를 반환하고 
    /// 삽입 여부를 거짓으로 전환
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerExit(Collider other) 
    {
        Debug.Log(gameObject.name + " Exit");
        if(other.tag == "Player")
        {
            InteractionPlayer.Instance.PopObject(this);
            isEnqueued = false;
        }
    }
}