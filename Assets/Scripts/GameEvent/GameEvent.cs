using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// GameEvent 부모 객체, 모든 게임 이벤트는 GameEvent class를 상속하여 만들어진다
/// 이벤트가 시작되기 전 초기화하는 InitEvent() (비워놓을 시 바로 OnEnable 실행)
/// 매 프레임마다 이벤트 완료 조건을 검색하는 CheckCondition()
/// 이벤트 완료 조건의 내용이 담긴 Condition()
/// 이벤트 완료 시 실행될 EventAction으로 이루어져 있다
/// 사용자가 변경해야하는 부분은 InitEvent, Condition, EventAction 
/// </summary>
public class GameEvent : MonoBehaviour
{
    /// <summary>
    /// GameEvent가 어떤 스테이지에 소속되어 있는가에 대한 정보
    /// </summary>
    public StageGameEvent owner;

    /// <summary>
    /// 가장 최근에 이벤트를 호출한 오브젝트
    /// </summary>
    public ObjectInteractable caller;

    /// <summary>
    /// 이벤트를 초기화하고 비활성화
    /// </summary>
    private void Awake() 
    {
        InitEvent();
        //Debug.Log("Script Off");
        this.enabled = false;
    }

    /// <summary>
    /// 초기화에 필요한 내용
    /// </summary>
    virtual protected void InitEvent()
    {

    }

    /// <summary>
    /// 활성화되었을때 CheckCondition 호출
    /// </summary>
    private void OnEnable() 
    {
        //Debug.Log("Script ON");
        StartCoroutine(nameof(CheckCondition));   
    }
    

    /// <summary>
    /// 매 프레임마다 Condition을 검사해 참일 때 EventAction 실행
    /// </summary>
    /// <returns></returns>
    public IEnumerator CheckCondition()
    {
        yield return new WaitUntil(() => Condition());
        StartCoroutine(EventAction());
    }

    virtual public bool Condition()
    {
        Debug.Log("Parent Condition");
        return true;
    }

    /// <summary>
    /// Event의 세부 내용
    /// </summary>
    /// <returns></returns>
    virtual public IEnumerator EventAction()
    {
        yield return new WaitForSeconds(1.0f);
        this.enabled = false;
        owner.StartStageEvent(1);
    }

    /// <summary>
    /// GameEvent가 호출되었을때 호출한 오브젝트를 caller에 저장
    /// </summary>
    /// <param name="objectInteractable"></param>
    public void ReceiveObject(ObjectInteractable objectInteractable)
    {
        caller = objectInteractable;
        //Debug.Log("caller Changed, caller's name is " + caller.gameObject.name);
    }
}
