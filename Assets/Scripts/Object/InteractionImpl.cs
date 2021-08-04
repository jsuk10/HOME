using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IInterAction
{
    void interaction();
}
public class InteractionDropPicture : MonoBehaviour, IInterAction
{
    [SerializeField]
    GameObject Player;
    
    float interactionRange = 1f;

    private void Update() 
    {
        if(Vector3.Distance(this.transform.position, Player.transform.position) <= interactionRange)
        {
            if(Input.GetAxis("Fire1") == 1)
                interaction();
        }
    }

    public void interaction()
    {

        
    }
}