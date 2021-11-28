using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventRoad1 : GameEvent
{
    override protected void InitEvent()
    {   
        
    }

    override public bool Condition()
    {
        if(caller != null)
        {
            if(caller.gameObject.name == "Driver")
            {
                return true;
            }
        }
        return false;
    }

    override public IEnumerator EventAction()
    {
        //DialogueManager.Instance.Begin(38,42);
        owner.StartStageEvent(2);
        yield return null;
    }
}