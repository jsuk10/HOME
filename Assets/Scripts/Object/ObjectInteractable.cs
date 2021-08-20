using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 플레이어와 상호작용 할 수 있는 오브젝트를 나타내는 클래스
/// 리스트 삽입 여부와 상호작용 내용을 가지고 있음
/// </summary>
public class ObjectInteractable : MonoBehaviour
{
    bool isEnqueued = false;
    public delegate void DelInteraction();
    public DelInteraction delInteraction;
    
    private void Start()
    {
        ObjectDictionary.Instance.AddObject(this);
    }

    /// <summary>
    /// 오브젝트와 플레이어가 충돌 상태일때 삽입 여부가 거짓이라면
    /// 삽입 여부를 참으로 전환하고 자신을 상호작용 가능 오브젝트 리스트에 넣는다 
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerStay(Collider other) 
    {
        if(isEnqueued == false)
        {
            if(other.tag == "Player")
            {
                isEnqueued = true;
                InteractionPlayer.Instance.AddObject(this);
            }   
        }
        
    }

    /// <summary>
    /// 오브젝트와 플레이가 충돌 상태를 벗어났을 때 
    /// 자신을 상호작용 가능 리스트에서 제거하고
    /// 삽입 여부를 거짓으로 전환
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerExit(Collider other) 
    {
        if(other.tag == "Player")
        {
            InteractionPlayer.Instance.RemoveObject(this);
            isEnqueued = false;
        }
    }

    /// <summary>
    /// 상호작용 시 실행되는 함수
    /// InteractionCommand를 상속한 스크립트의 Interaction을 참조하는 delInteraction을 실행하고 삽입 여부를 거짓으로 전환
    /// </summary>
    public void Interaction()
    {
        GameEventManager.Instance.ReceiveInteraction(this);
        isEnqueued = false;
    }
}