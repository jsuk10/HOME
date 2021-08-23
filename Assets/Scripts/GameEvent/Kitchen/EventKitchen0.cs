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
        var movePlayer = MainObject.Instance.player.GetComponent<MovePlayer>();
        movePlayer.enabled = false;
        yield return new WaitForSeconds(2.0f);
        movePlayer.enabled = true;
        this.enabled = false;
        owner.StartStageEvent(1);
        yield return null;
    }
}
