using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEventManager : Singleton<GameEventManager>
{
    /// <summary>
    /// 현재 스테이지의 번호 (추후 열거형으로 수정)
    /// </summary>
    int currentStage;
    public int CurrentStage {get => currentStage; set => currentStage = value;}

    /// <summary>
    /// 현재 실행중인 GameEvent
    /// </summary>
    GameEvent currentEvent;

    /// <summary>
    /// 각 스테이지가 가진 StageGameEvent를 저장
    /// </summary>
    List<StageGameEvent> listStageGameEvent;

    /// <summary>
    /// 스테이지 게임오브젝트를 순회하면서 StageGameEvent 클래스를 listStageGameEvent에 저장
    /// </summary>
    override public void Init()
    {
        listStageGameEvent = new List<StageGameEvent>();

        foreach(Transform stage in transform)
        {
            listStageGameEvent.Add(stage.Find("GameEvent").gameObject.GetComponent<StageGameEvent>());
        }
    }

    public void ReceiveInteraction(ObjectInteractable objectInteractable)
    {
        SendObject(objectInteractable);
    }

    void SendObject(ObjectInteractable objectInteractable)
    {
        listStageGameEvent[currentStage].SendObject(objectInteractable);
    }
}
