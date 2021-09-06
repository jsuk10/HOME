using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventGarden5 : GameEvent
{
    GameObject player;
    GameObject eventPosition;

    override protected void InitEvent()
    {
        player = MainObject.Instance.player;
        eventPosition = transform.Find("EventPosition").gameObject;
    }

    override public bool Condition()
    {
        if(eventPosition.transform.position.x < player.transform.position.x)
            return true;
        return false;
    }

    /// <summary>
    /// 잠시 기다림
    /// </summary>
    /// <returns></returns>
    override public IEnumerator EventAction()
    {
        var spriteDoor = ObjectDictionary.Instance.FindObject("DoorGarden").transform.Find("Sprite");
        spriteDoor.transform.Find("DoorOpened").gameObject.SetActive(false);
        spriteDoor.transform.Find("DoorClosed").gameObject.SetActive(true);

        var movePlayer = player.GetComponent<MovePlayer>();

        movePlayer.enabled = false;
        DialogueManager.Instance.Begin(23,23);
        yield return new WaitForSeconds(2.0f);
        movePlayer.enabled = true;

        this.enabled = false;
        owner.StartStageEvent(6);
            
        yield return null;
    }
}
