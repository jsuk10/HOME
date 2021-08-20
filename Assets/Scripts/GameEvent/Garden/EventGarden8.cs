using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventGarden8 : GameEvent
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
        var spriteDoor = ObjectDictionary.Instance.FindObject("DoorGarden").transform.Find("Sprite");
        spriteDoor.transform.Find("DoorOpened").gameObject.SetActive(true);
        spriteDoor.transform.Find("DoorClosed").gameObject.SetActive(false);

        this.enabled = false;
        owner.StartStageEvent(9);
            
        yield return null;
    }
}
