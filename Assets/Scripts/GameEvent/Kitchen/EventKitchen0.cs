using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventKitchen0 : GameEvent
{
    Transform eventPosition;
    GameObject player;

    override protected void InitEvent()
    {   
        eventPosition = transform.Find("EventPosition");
        player = MainObject.Instance.player;
    }

    override public bool Condition()
    {
        return true;
    }
    /// <summary>
    /// 시작과 동시에 방 안으로 들어온다
    /// </summary>
    /// <returns></returns>
    override public IEnumerator EventAction()
    {
        
        var movePlayer = player.GetComponent<MovePlayer>();
        movePlayer.enabled = false;

        StartCoroutine(PlayerMoveAnim());
        yield return new WaitForSeconds(2.0f);
        DialogueManager.Instance.Begin(1,2);
        yield return new WaitForSeconds(1.0f);
        movePlayer.enabled = true;
        this.enabled = false;
        owner.StartStageEvent(1);
        yield return null;
    }

    public IEnumerator PlayerMoveAnim()
    {
        float rate = 0;
        var spritePlayer = player.transform.Find("Sprite");
        while(rate <= 1)
        {
            rate += Time.deltaTime/2;
            spritePlayer.position = Vector3.Lerp(eventPosition.position, player.transform.position, rate);
            

            yield return null;
        }
    }
}
