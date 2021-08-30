using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventKitchen6 : GameEvent
{
    // Start is called before the first frame update
    override public bool Condition()
    {
        /*
        if(caller != null)
        {
            if(caller.gameObject.name == "DoorKitchen")
            {
                return true;
            }
        }
        return false;*/
        return true;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    override public IEnumerator EventAction()
    {/*
        var doorSprite = caller.transform.Find("Sprite");
        doorSprite.Find("DoorClosed").gameObject.SetActive(false);
        doorSprite.Find("DoorOpened").gameObject.SetActive(true);
        DialogueManager.Instance.Begin(16,16);
        Debug.Log("Door Open");
        //Door is Open;*/
        this.enabled = false;
        owner.StartStageEvent(7);
        yield return null;
    }
}
