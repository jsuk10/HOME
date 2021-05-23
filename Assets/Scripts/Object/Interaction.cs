using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    [SerializeField]
    GameObject Player;

    float interactionRange = 1.0f;

    private void Update() 
    {
        if(Vector3.Distance(this.transform.position, Player.transform.position) <= interactionRange)
        {
            Debug.Log("InterAction Available");
            if(Input.GetAxis("Fire1") == 1)
                DisplayDialog();
        }
    }

    private void DisplayDialog()
    {
        Debug.Log("Dialog");
    }
}