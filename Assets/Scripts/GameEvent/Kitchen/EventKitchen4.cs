using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventKitchen4 : GameEvent
{
    Transform eventPosition0;
    Transform eventPosition1;
    GameObject dog;

    override protected void InitEvent()
    {
        eventPosition0 = transform.Find("EventPosition0");
        eventPosition1 = transform.Find("EventPosition1");
        dog = transform.Find("Dog").gameObject;
    }
    // Start is called before the first frame update
    override public bool Condition()
    {
        if(caller != null)
        {            
            return true;
        }
        return false;
    }

    override public IEnumerator EventAction()
    {
        StartCoroutine(DogEvent());
        yield return new WaitForSeconds(2.0f);
        Debug.Log("강아지 출현");
        DialogueManager.Instance.Begin(7,11);
        

        this.enabled = false;
        owner.StartStageEvent(5);
        yield return null;
    }

    public IEnumerator DogEvent()
    {
        dog.SetActive(true);
        float rate = 0;

        dog.transform.localScale = new Vector3 (-1, 1, 1);
        while(rate <= 1)
        {
            rate += Time.deltaTime;
            dog.transform.position = Vector3.Lerp(eventPosition0.transform.position, eventPosition1.transform.position, rate);
            yield return null;
        }

        yield return new WaitForSeconds(4.0f);
        rate = 0;
        dog.transform.localScale = new Vector3 (1, 1, 1);
        while(rate <= 1)
        {
            rate += Time.deltaTime;
            dog.transform.position = Vector3.Lerp(eventPosition1.transform.position, eventPosition0.transform.position, rate);
            yield return null;
        }

        dog.SetActive(false);
    }

}
