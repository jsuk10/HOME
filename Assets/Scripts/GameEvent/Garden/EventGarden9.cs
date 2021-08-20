using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventGarden9 : GameEvent
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
        Debug.Log("다음 스테이지로");

        this.enabled = false;
        yield return null;
    }
}
