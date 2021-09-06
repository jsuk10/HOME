using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventKitchen2 : GameEvent
{

    /// <summary>
    /// 컵과 상호작용 했을 시
    /// </summary>
    /// <returns></returns>
    override public bool Condition()
    {
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
    /// 오브젝트가 사라지고 
    /// </summary>
    /// <returns></returns>
    override public IEnumerator EventAction()
    {
        DialogueManager.Instance.Begin(4,5);
        var cupGameObject = ObjectDictionary.Instance.FindObject("Cup");
        
        cupGameObject.gameObject.SetActive(false);

        var potObject = ObjectDictionary.Instance.FindObject("Pot");
        var potSprite = potObject.transform.Find("Sprite");
        //Debug.Log(potSprite.gameObject.name);
        potSprite.Find("Highlight").gameObject.SetActive(true);
        potSprite.Find("Normal").gameObject.SetActive(false);

        this.enabled = false;
        owner.StartStageEvent(3);
        yield return null;
    }
}
