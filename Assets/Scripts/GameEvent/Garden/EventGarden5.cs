using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventGarden5 : GameEvent
{
    [SerializeField]
    GameObject player;

    [SerializeField]
    GameObject eventPosition;
    override public bool Condition()
    {
        if(Vector3.Distance(eventPosition.transform.position, player.transform.position) < 1)
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
        this.enabled = false;
        owner.StartStageEvent(6);
            
        yield return null;
    }
}
