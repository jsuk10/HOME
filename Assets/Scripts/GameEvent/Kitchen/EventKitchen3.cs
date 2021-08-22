using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventKitchen3 : GameEvent
{
    // Start is called before the first frame update
    override public bool Condition()
    {
        if(caller != null)
        {
            if(caller.gameObject.name == "Pot")
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
        var potObject = ObjectDictionary.Instance.FindObject("Pot");
        var potSprite = potObject.transform.Find("Sprite");

        potSprite.Find("Half").gameObject.SetActive(true);
        potSprite.Find("Highlight").gameObject.SetActive(false);

        this.enabled = false;
        owner.StartStageEvent(4);
        yield return null;
    }
}
