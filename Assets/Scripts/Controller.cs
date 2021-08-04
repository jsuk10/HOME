﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    void Start() 
    {
        StageController.instance.SetStage(0);
    }
    void Update()
    {
        InputProcess();
    }

    void InputProcess()
    {
        if(Input.GetKeyDown(KeyCode.Alpha0))
        {
            StageController.instance.SetStage(0);
            Debug.Log(0);
        }
        else if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            StageController.instance.SetStage(1);
             Debug.Log(1);
        }
    }
}