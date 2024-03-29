﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Stage와 관련된 이벤트들을 처리하는 스크립트, Awake에서 Stage의 정보를 담은 
/// </summary>
public class StageManager : Singleton<StageManager>
{
    private GameObject player;
    private GameObject dog;
    List<StageInfo> listStageInfo;

    int currentStageNum;

    public override void Init()
    {
        player = MainObject.Instance.player;
        dog = MainObject.Instance.dog;
        listStageInfo = new List<StageInfo>();
/*
        foreach(Transform child in transform)
        {
            var objectInStage = child.Find("ObjectInteractable");
        }*/
    }

    void Start()
    {
        InitStageInfo();
    }

    /// <summary>
    /// StageInfo 클래스를 생성, 리스트에 삽입
    /// </summary>
    private void InitStageInfo()
    {
        for(int i = 0; i < transform.childCount; i++)
        {
            var child = transform.GetChild(i);
            listStageInfo.Add(
                new StageInfo(
                    child.Find(nameof(StageInfo.VCam)).gameObject,
                    child.Find(nameof(StageInfo.Position)).gameObject,
                    child.Find(nameof(StageInfo.GameEvent)).GetComponent<StageGameEvent>()));
            Debug.Log("StageInfo" + i + "Initialize");
        }
    }

    /// <summary>
    /// 현재 스테이지를 n번째 스테이지로 설정한다
    /// </summary>
    public void SetStage(int CurrentStageNum)
    {
        
        currentStageNum = CurrentStageNum;

        StageInfo curStage = listStageInfo[currentStageNum];
        
        player.transform.position = curStage.Position.transform.Find("Player").position;
        
        var dogPosition = curStage.Position.transform.Find("Dog");

        if(dogPosition != null)
        {
            dog.transform.position = dogPosition.position;
            dog.SetActive(true);
        }
        else
        {
            dog.SetActive(false);
        }
        GameEventManager.Instance.CurrentStage = currentStageNum;
        
        curStage.GameEvent.StartStageEvent(0);

        

        foreach(var stage in listStageInfo)
        {
            stage.VCam.SetActive(false);
        }
        GameObject curStageFollowTarget =  curStage.VCam.transform.parent.Find("FollowTarget").Find("FollowTarget").gameObject;
        CameraFollow.Instance.ChangeFollowTarget(curStageFollowTarget);
        curStage.VCam.SetActive(true);
    }
}
