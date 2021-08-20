using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageGameEvent : MonoBehaviour
{
    List<int> listCurrentEventIndex;
    List<GameEvent> listGameEvent;
    private void Awake() 
    {
        listCurrentEventIndex = new List<int>();
        listGameEvent = new List<GameEvent>();

        foreach(Transform child in transform)
        {
            var tempGameEvent = child.gameObject.GetComponent<GameEvent>();
            tempGameEvent.owner = this;
            listGameEvent.Add(tempGameEvent);
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
            listGameEvent[currentEventIndex].ReceiveObject(objectInteractable);
        }
    }

    public void RemoveCurrentEvent(GameEvent currentEvent)
    {
        listCurrentEventIndex.Remove(listGameEvent.FindIndex(x => x == currentEvent));
    }
}