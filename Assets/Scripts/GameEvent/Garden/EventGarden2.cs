using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventGarden2 : GameEvent
{
    [SerializeField]
    GameObject player;

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
        var movePlayer = player.GetComponent<MovePlayer>();

        movePlayer.enabled = false;
        Debug.Log("구덩이에 뭔가가 보인다");
        yield return new WaitForSeconds(2.0f);
        this.enabled = false;

        owner.StartStageEvent(3);

        movePlayer.enabled = true;
            
        yield return null;
    }
}
