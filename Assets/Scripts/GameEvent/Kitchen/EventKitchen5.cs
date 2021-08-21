using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventKitchen5 : GameEvent
{
    // Start is called before the first frame update
    override public bool Condition()
    {
        if(caller != null)
        {
            if(caller.gameObject.name == "Phone")
            {
                return true;
            }
        }
        return false;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    override public IEnumerator EventAction()
    {
        var phoneObject = ObjectDictionary.Instance.FindObject("Phone");
        phoneObject.gameObject.SetActive(false);
        Debug.Log("Door Unlock");
        //Door is Open;
        this.enabled = false;
        owner.StartStageEvent(6);
        yield return null;
    }
}
