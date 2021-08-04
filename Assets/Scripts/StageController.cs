using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 스테이지의 주요정보를 담고 있는 클래스 
/// VCam = 시네머신 가상 카메라
/// Door = 스테이지의 문
/// </summary>
class Stage
{
    public Stage(GameObject VCam, GameObject Door, GameObject Position)
    {
        vCam = VCam;
        door = Door;
        position = Position;
    }
    GameObject vCam;
    public GameObject VCam
    {
        get
        {
            return vCam;
        }
    }

    GameObject door;

    public GameObject Door
    {
        get
        {
            return door;
        }
    }

    GameObject position;
    
    public GameObject Position
    {
        get
        {
            return position;
        }
    }
}

/// <summary>
/// Stage와 관련된 이벤트들을 처리하는 스크립트, Awake에서 Stage의 정보를 담은 
/// </summary>
public class StageController : MonoBehaviour
{
    public GameObject player;
    public static StageController instance;
    List<Stage> listStage;
    void Awake()
    {
        instance = this;
        
        listStage = new List<Stage>();

        foreach(Transform child in transform)
        {
            GameObject childGO = child.gameObject;
            listStage.Add(
                new Stage(
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
        Stage curStage = listStage[currentStageNum];

        foreach(Stage stage in listStage)
            stage.VCam.SetActive(false);
        player.transform.position = curStage.Position.transform.Find("Player").position;

        curStage.VCam.SetActive(true);
    }
}
