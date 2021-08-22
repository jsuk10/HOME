using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvent : MonoBehaviour
{
    public StageGameEvent owner;
    public ObjectInteractable caller;
    private void Awake() 
    {
        InitEvent();
        //Debug.Log("Script Off");
        this.enabled = false;
    }

    virtual protected void InitEvent()
    {

    }

    private void OnEnable() 
    {
        //Debug.Log("Script ON");
        StartCoroutine(nameof(CheckCondition));   
    }
    // Start is called before the first frame update

    public IEnumerator CheckCondition()
    {
        yield return new WaitUntil(() => Condition());
        StartCoroutine(EventAction());
    }

    virtual public bool Condition()
    {
        Debug.Log("Parent Condition");
        return true;
    }

    virtual public IEnumerator EventAction()
    {
        Debug.Log("Parent Event Start");
        yield return new WaitForSeconds(1.0f);
        this.enabled = false;
        owner.StartStageEvent(1);
    }

    public void ReceiveObject(ObjectInteractable objectInteractable)
    {
        caller = objectInteractable;
        //Debug.Log("caller Changed, caller's name is " + caller.gameObject.name);
    }
}
