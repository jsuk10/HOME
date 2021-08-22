using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventKitchen0 : GameEvent
{
    override public bool Condition()
    {
        return true;
    }

    override public IEnumerator EventAction()
    {
        yield return new WaitForSeconds(2.0f);

        this.enabled = false;
        owner.StartStageEvent(1);
        yield return null;
    }
}
