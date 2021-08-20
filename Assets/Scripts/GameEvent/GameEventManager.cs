using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEventManager : Singleton<GameEventManager>
{
    int currentStage;
    public int CurrentStage {get => currentStage; set => currentStage = value;}
    GameEvent currentEvent;

    List<StageGameEvent> listStageGameEvent;

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
