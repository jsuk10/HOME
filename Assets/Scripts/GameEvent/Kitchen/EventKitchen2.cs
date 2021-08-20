using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventKitchen2 : GameEvent
{

    // Start is called before the first frame update
    override public bool Condition()
    {
        Debug.Log(caller == null);
        if(caller != null)
        {
            if(caller.gameObject.name == "Cup")
            {
                return true;
            }
        }
        return false;
    }

    /// <summary>
    /// 컵 상호작용 시 사라짐
    /// </summary>
    /// <returns></returns>
    override public IEnumerator EventAction()
    {

        var cupGameObject = ObjectDictionary.Instance.FindObject("Cup");
        
        cupGameObject.gameObject.SetActive(false);

        var potObject = ObjectDictionary.Instance.FindObject("Pot");
        var potSprite = potObject.transform.Find("Sprite");

        potSprite.Find("Highlight").gameObject.SetActive(true);
        potSprite.Find("Normal").gameObject.SetActive(false);

        this.enabled = false;
        owner.StartStageEvent(3);
        yield return null;
    }
}
