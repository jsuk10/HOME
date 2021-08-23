using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventKitchen1 : GameEvent
{
    private GameObject player;

    private GameObject position;

    override public bool Condition()
    {
        if(player.transform.position.x > position.transform.position.x)
        {   
            return true;
        }
        return false;
    }

    override protected void InitEvent()
    {
        player = MainObject.Instance.player;
        position = transform.Find("EventPosition").gameObject;
    } 

    /// <summary>
    /// 움직임이 멈추고 메시지, 컵 테두리 오버레이
    /// </summary>
    /// <returns></returns>
    override public IEnumerator EventAction()
    {
        var movePlayer = player.GetComponent<MovePlayer>();
        movePlayer.enabled = false;

        var cupGameObject = ObjectDictionary.Instance.FindObject("Cup").gameObject;
        var cupSprite = cupGameObject.transform.Find("Sprite");
        

        yield return new WaitForSeconds(2.0f);
        cupSprite.Find("Highlight").gameObject.SetActive(true);
        cupSprite.Find("Normal").gameObject.SetActive(false);

        this.enabled = false;
        owner.StartStageEvent(2);
        movePlayer.enabled = true;
        yield return null;
    }
}
