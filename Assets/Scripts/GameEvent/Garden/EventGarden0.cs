using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventGarden0 : GameEvent
{
    [SerializeField]
    MovePlayer movePlayer;
    override public bool Condition()
    {
        return true;
    }

    /// <summary>
    /// 잠시 기다림
    /// </summary>
    /// <returns></returns>
    override public IEnumerator EventAction()
    {
        Debug.Log("EventGarden 0");
        movePlayer.enabled = false;
        yield return new WaitForSeconds(2.0f);
    
        this.enabled = false;
        owner.StartStageEvent(1);
        owner.StartStageEvent(2);
        movePlayer.enabled = true;
        yield return null;
    }
}
