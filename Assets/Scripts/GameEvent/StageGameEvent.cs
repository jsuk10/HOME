using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// 각 스테이지가 가진 GameEvent를 스테이지별로 관리하는 스크립트
/// </summary>
public class StageGameEvent : MonoBehaviour
{
    /// <summary>
    /// 현재 실행중인 GameEvent들의 index를 가지고 있음
    /// </summary>
    List<int> listCurrentEventIndex;

    /// <summary>
    /// 현재 실행중인 GameEvent를 가지고 있음
    /// </summary>
    List<GameEvent> listGameEvent;    

    /// <summary>
    /// 리스트들을 초기화 한 후
    /// 현재 스테이지가 가진 GameEvent들을 리스트에 삽입한다
    /// </summary>
    private void Awake() 
    {
        listCurrentEventIndex = new List<int>();
        listGameEvent = new List<GameEvent>();
        var stageName = transform.parent.gameObject.name;

        for(int i = 0; i < transform.childCount; i++)
        {
            var gameEventInScene = transform.GetChild(i).gameObject;
            AddGameEvent(gameEventInScene, stageName, i);
            var tempGameEvent = gameEventInScene.GetComponent<GameEvent>();
            tempGameEvent.owner = this;
            listGameEvent.Add(tempGameEvent);
            //Debug.Log("stage eventNum " + listGameEvent.Count);
        }
    }

    /// <summary>
    /// StageName에 따라 eventIndex에 맞는 GameEvent를 gameEventInScene에 부착
    /// </summary>
    /// <param name="gameEventInScene"></param>
    /// <param name="stageName"></param>
    /// <param name="eventIndex"></param>
    void AddGameEvent(GameObject gameEventInScene, string stageName, int eventIndex)
    {
        if(stageName == "Kitchen")
            AddKitchenGameEvent(gameEventInScene, eventIndex);
        else if(stageName == "Garden")
            AddGardenGameEvent(gameEventInScene, eventIndex);
        else if(stageName == "Road")
            AddRoadGameEvent(gameEventInScene, eventIndex);
    }

    /// <summary>
    /// gameEventInScene에 eventIndex에 맞는 GameEvent를 부착
    /// </summary>
    /// <param name="gameEventInScene"></param>
    /// <param name="eventIndex"></param>
    void AddKitchenGameEvent(GameObject gameEventInScene, int eventIndex)
    {
        switch (eventIndex)
        {
            case 0:
            gameEventInScene.AddComponent<EventKitchen0>();
            break;
            case 1:
            gameEventInScene.AddComponent<EventKitchen1>();
            break;
            case 2:
            gameEventInScene.AddComponent<EventKitchen2>();
            break;
            case 3:
            gameEventInScene.AddComponent<EventKitchen3>();
            break;
            case 4:
            gameEventInScene.AddComponent<EventKitchen4>();
            break;
            case 5:
            gameEventInScene.AddComponent<EventKitchen5>();
            break;
            case 6:
            gameEventInScene.AddComponent<EventKitchen6>();
            break;
            case 7:
            gameEventInScene.AddComponent<EventKitchen7>();
            break;
            default:
            break;
        }
    }

    /// <summary>
    /// gameEventInScene에 eventIndex에 맞는 GameEvent를 부착
    /// </summary>
    /// <param name="gameEventInScene"></param>
    /// <param name="eventIndex"></param>
    void AddGardenGameEvent(GameObject gameEventInScene, int eventIndex)
    {
        switch (eventIndex)
        {
            case 0:
            gameEventInScene.AddComponent<EventGarden0>();
            break;
            case 1:
            gameEventInScene.AddComponent<EventGarden1>();
            break;
            case 2:
            gameEventInScene.AddComponent<EventGarden2>();
            break;
            case 3:
            gameEventInScene.AddComponent<EventGarden3>();
            break;
            case 4:
            gameEventInScene.AddComponent<EventGarden4>();
            break;
            case 5:
            gameEventInScene.AddComponent<EventGarden5>();
            break;
            case 6:
            gameEventInScene.AddComponent<EventGarden6>();
            break;
            case 7:
            gameEventInScene.AddComponent<EventGarden7>();
            break;
            case 8:
            gameEventInScene.AddComponent<EventGarden8>();
            break;
            case 9:
            gameEventInScene.AddComponent<EventGarden9>();
            break;
            default:
            break;
        }
    }

    /// <summary>
    /// gameEventInScene에 eventIndex에 맞는 GameEvent를 부착
    /// </summary>
    /// <param name="gameEventInScene"></param>
    /// <param name="eventIndex"></param>
    void AddRoadGameEvent(GameObject gameEventInScene, int eventIndex)
    {
        switch (eventIndex)
        {
            case 0:
            gameEventInScene.AddComponent<EventRoad0>();
            break;

            case 1:
            gameEventInScene.AddComponent<EventRoad1>();
            break;

            case 2:
            gameEventInScene.AddComponent<EventRoad2>();
            break;

            case 3:
            gameEventInScene.AddComponent<EventRoad3>();
            break;

            case 4:
            gameEventInScene.AddComponent<EventRoad4>();
            break;
           
            default:
            break;
        }
    }

    /// <summary>
    /// index에 해당하는 이벤트를 활성화한다
    /// </summary>
    /// <param name="index"></param>
    public void StartStageEvent(int index)
    {
        listCurrentEventIndex.Add(index);
        listGameEvent[index].enabled = true;
    }

    /// <summary>
    /// 현재 실행중인 GameEvent들의 caller를 호출한 objectInteractable로 수정
    /// </summary>
    /// <param name="objectInteractable"></param>
    public void SendObject(ObjectInteractable objectInteractable)
    {
        foreach(int currentEventIndex in listCurrentEventIndex)
        {
            listGameEvent[currentEventIndex].ReceiveObject(objectInteractable);
        }
    }

    /// <summary>
    /// 삭제해야할 currentEvent의 index를 listGameEvent에서 찾아 listCurrentEventindex에서 삭제 
    /// </summary>
    /// <param name="currentEvent"></param>
    public void RemoveCurrentEvent(GameEvent currentEvent)
    {
        listCurrentEventIndex.Remove(listGameEvent.FindIndex(x => x == currentEvent));
    }
}