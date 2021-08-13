using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 상호작용 시 실행되는 함수의 원형이 되는 클래스
/// 상호작용 내용은 해당 클래스를 상속한 서브클래스에서 구현된다
/// </summary>
public class InteractionCommand : MonoBehaviour
{
    private ObjectInteractable owner;
    protected void Interaction()
    {
        Debug.Log(gameObject.name + " Interaction");
    }
    public void Start()
    {
        owner = transform.GetComponent<ObjectInteractable>();
        Debug.Log("Allocate Interaction");
        owner.delInteraction = Interaction;    
    }
}
