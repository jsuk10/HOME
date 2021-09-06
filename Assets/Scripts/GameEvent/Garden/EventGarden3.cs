using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventGarden3 : GameEvent
{
    override public bool Condition()
    {
        if(caller != null)
        {
            if(caller.gameObject.name == "Pit")
                return true;
        }
        return false;
    }

    /// <summary>
    /// 잠시 기다림
    /// </summary>
    /// <returns></returns>
    override public IEnumerator EventAction()
    {
        DialogueManager.Instance.Begin(22,22);
        this.enabled = false;
        
        Debug.Log("앨범 시스템 획득");
        owner.StartStageEvent(4);
            
        yield return null;
    }
}
