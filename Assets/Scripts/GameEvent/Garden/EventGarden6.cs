using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventGarden6 : GameEvent
{
    // Start is called before the first frame update
    override public bool Condition()
    {
        if(caller != null)
        {
            if(caller.gameObject.name == "DoorGarden")
            {
                return true;
            }
        }
        return false;
    }

    /// <summary>
    /// 잠시 기다림
    /// </summary>
    /// <returns></returns>
    override public IEnumerator EventAction()
    {
        Debug.Log("문이 잠겨있다, 열쇠를 찾자");
        this.enabled = false;
        owner.StartStageEvent(7);
            
        yield return null;
    }
}
