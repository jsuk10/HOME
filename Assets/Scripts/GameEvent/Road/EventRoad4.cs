using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventRoad4 : GameEvent
{
    override protected void InitEvent()
    {   
        
    }

    override public bool Condition()
    {
        //다음스테이지 이동
        return true;
    }

    override public IEnumerator EventAction()
    {
        yield return null;
    }
}