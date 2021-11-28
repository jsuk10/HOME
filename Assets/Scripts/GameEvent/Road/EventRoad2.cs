using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventRoad2 : GameEvent
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
        //운전자 대화 출력
        //검은 화면 
        //차와 사람 사라짐, 소리 출력
        //

        //미니게임 팝업
        owner.StartStageEvent(3);
        yield return null;
    }
}