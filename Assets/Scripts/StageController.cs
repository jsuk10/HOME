using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Stage와 관련된 이벤트들을 처리하는 스크립트, Awake에서 Stage의 정보를 담은 
/// </summary>
public class StageController : MonoBehaviour
{
    public GameObject player;
    public static StageController instance;
    List<StageInfo> listStage;
    void Awake()
    {
        instance = this;
        
        listStage = new List<StageInfo>();

        foreach(Transform child in transform)
        {
            GameObject childGO = child.gameObject;
            listStage.Add(
                new StageInfo(
                    childGO.transform.Find("VCam").gameObject, 
                    childGO.transform.Find("Background").Find("Door").gameObject,
                    childGO.transform.Find("Position").gameObject));
        }
            
    }

    /// <summary>
    /// 현재 스테이지를 n번째 스테이지로 설정한다
    /// </summary>
    public void SetStage(int currentStageNum)
    {
        StageInfo curStage = listStage[currentStageNum];

        foreach(var stage in listStage)
            stage.VCam.SetActive(false);
        player.transform.position = curStage.Position.transform.Find("Player").position;

        curStage.VCam.SetActive(true);
    }
}
