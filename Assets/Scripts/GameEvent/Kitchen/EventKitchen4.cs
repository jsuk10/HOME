using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventKitchen4 : GameEvent
{
    // Start is called before the first frame update
    override public bool Condition()
    {
        if(caller != null)
        {            
            return true;
        }
        return false;
    }

    override public IEnumerator EventAction()
    {
        Debug.Log("강아지 출현");

        yield return new WaitForSeconds(2.0f);

        this.enabled = false;
        owner.StartStageEvent(5);
        yield return null;
    }
}
