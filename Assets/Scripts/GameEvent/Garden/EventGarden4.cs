using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventGarden4 : GameEvent
{
    GameObject player;
    GameObject dog;
    GameObject eventPosition;

    override protected void InitEvent()
    {
        player = MainObject.Instance.player;
        dog = MainObject.Instance.dog;
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
        this.enabled = false;
        yield return new WaitForSeconds(2.0f);
        dog.SetActive(false);
        owner.StartStageEvent(5);
            
        yield return null;
    }
}
