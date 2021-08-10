using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionCommand : MonoBehaviour
{
    private ObjectInteractable owner;
    private void Interaction()
    {
        Debug.Log(gameObject.name + " Interaction");
    }
    public void Start()
    {
        owner = transform.GetComponent<ObjectInteractable>();
        Debug.Log("Allocate Interaction");
        owner.Interaction = Interaction;    
    }
}
