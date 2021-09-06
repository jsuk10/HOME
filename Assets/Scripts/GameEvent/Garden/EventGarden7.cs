using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventGarden7 : GameEvent
{
    // Start is called before the first frame update
    override public bool Condition()
    {
        if(caller != null)
        {
            if(caller.gameObject.name == "DogGum")
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
        DialogueManager.Instance.Begin(33,34);
        Debug.Log("열쇠를 찾았다");

        this.enabled = false;
        owner.StartStageEvent(8);
            
        yield return null;
    }
}
