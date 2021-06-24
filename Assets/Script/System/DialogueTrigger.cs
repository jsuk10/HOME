using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public void Trigger()
    {
        Debug.Log("trigger");
        DialogueManager.Instance.Begin(1,5);
    }
}
