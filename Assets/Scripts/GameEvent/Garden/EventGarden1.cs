using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventGarden1 : GameEvent
{
    override public bool Condition()
    {
        if(caller != null)
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
        if(caller.gameObject.name != "Pit")
        {
            Debug.Log(caller.gameObject.name + "is caller");
            caller = null;
            owner.StartStageEvent(1);
        }
            
        yield return null;
    }
}
