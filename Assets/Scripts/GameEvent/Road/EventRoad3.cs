using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventRoad3 : GameEvent
{
    override protected void InitEvent()
    {   
        
    }

    override public bool Condition()
    {
        if(caller != null)
        {
            if(caller.gameObject.name == "DeadDog")
            {
                return true;
            }
        }
        return false;
    }

    override public IEnumerator EventAction()
    {
        //신고 , 대화문 출력
        // 개짖는소리가 난다
        // 대화
        yield return null;
    }
}