using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    void Start() 
    {
        StageManager.Instance.SetStage(0);
    }
    void Update()
    {
        InputProcess();
    }

    void InputProcess()
    {
        if(Input.GetKeyDown(KeyCode.Alpha0))
        {
            StageManager.Instance.SetStage(0);
            Debug.Log(0);
        }
        else if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            StageManager.Instance.SetStage(1);
             Debug.Log(1);
        }
        else if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            StageManager.Instance.SetStage(2);
             Debug.Log(1);
        }
    }
}
