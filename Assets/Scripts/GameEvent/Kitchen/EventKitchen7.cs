using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventKitchen7 : GameEvent
{
    // Start is called before the first frame update
    override public bool Condition()
    {
        if(caller != null)
        {
            if(caller.gameObject.name == "DoorKitchen")
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
        
        this.enabled = false;
        StageManager.Instance.SetStage(1);
        yield return null;
    }
}
