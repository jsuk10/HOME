using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Stage와 관련된 이벤트들을 처리하는 스크립트, Awake에서 Stage의 정보를 담은 
/// </summary>
public class StageManager : Singleton<StageManager>
{
    public GameObject player;
    List<StageInfo> listStageInfo;
    public override void Init()
    {
        listStageInfo = new List<StageInfo>();
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
                    child.Find("Background").Find("Door").gameObject,
                    child.Find(nameof(StageInfo.Position)).gameObject));
        }
    }

    /// <summary>
    /// 현재 스테이지를 n번째 스테이지로 설정한다
    /// </summary>
    public void SetStage(int currentStageNum)
    {
        StageInfo curStage = listStageInfo[currentStageNum];

        foreach(var stage in listStageInfo)
            stage.VCam.SetActive(false);
        player.transform.position = curStage.Position.transform.Find("Player").position;

        curStage.VCam.SetActive(true);
    }
}
