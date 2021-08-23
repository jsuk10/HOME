using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class StageGameEvent : MonoBehaviour
{
    List<int> listCurrentEventIndex;
    List<GameEvent> listGameEvent;    

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
        }
    }

    void AddGameEvent(GameObject gameEventInScene, string stageName, int eventIndex)
    {
        if(stageName == "Kitchen")
            AddKitchenGameEvent(gameEventInScene, eventIndex);
        if(stageName == "Garden")
            AddGardenGameEvent(gameEventInScene, eventIndex);
    }

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

    public void StartStageEvent(int index)
    {
        listCurrentEventIndex.Add(index);
        listGameEvent[index].enabled = true;
    }

    public void SendObject(ObjectInteractable objectInteractable)
    {
        foreach(int currentEventIndex in listCurrentEventIndex)
        {
            //Debug.Log("Current Event Index is " + currentEventIndex);
            listGameEvent[currentEventIndex].ReceiveObject(objectInteractable);
        }
    }

    public void RemoveCurrentEvent(GameEvent currentEvent)
    {
        listCurrentEventIndex.Remove(listGameEvent.FindIndex(x => x == currentEvent));
    }
}