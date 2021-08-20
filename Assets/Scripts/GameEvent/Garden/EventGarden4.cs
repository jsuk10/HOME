using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventGarden4 : GameEvent
{
    [SerializeField]
    GameObject player;
    [SerializeField]
    GameObject dog;

    [SerializeField]
    GameObject eventPosition;
    override public bool Condition()
    {
        if(Vector3.Distance(eventPosition.transform.position, player.transform.position) < 1)
            return true;
        return false;
    }

    /// <summary>
    /// 잠시 기다림
    /// </summary>
    /// <returns></returns>
    override public IEnumerator EventAction()
    {
        this.enabled = false;
        yield return new WaitForSeconds(2.0f);
        dog.SetActive(false);
        owner.StartStageEvent(5);
            
        yield return null;
    }
}
