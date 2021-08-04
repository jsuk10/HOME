using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collection
{
    //차후 언록 초기화 해주는거 작성, 수집요소 얼마나 있는지 부터 정하기
    public bool[] unlock;
}

[System.Serializable]
public class Dialogue
{
    public string name;
    public List<string> sentence;
}

[System.Serializable]
public class DialogueEvent
{
    public string eventName;
    public Vector2 line;
    public List<Dialogue> dialogues;
}

[System.Serializable]
public class PlayerDataClass
{
    public string name;
    public int stage;
    public PlayerDataClass()
    {
        name = "";
        stage = 0;
    }
    public PlayerDataClass(string name)
    {
        this.name = name;
        stage = 0;
    }
}

[System.Serializable]
public class PlayerNameClass
{
    public PlayerDataClass[] playerData = new PlayerDataClass[3];
    public PlayerNameClass()
    {
        for (int i = 0; i < 3; i++)
        {
            playerData[i] = new PlayerDataClass();
        }
    }
}

[System.Serializable]
public class UIMenuClass
{
    public GameObject loadOption;
    public GameObject settingOption;
    public GameObject creadit;
    public Text[] playerNameText = new Text[3];
}

/// <summary>
/// 스테이지의 주요정보를 담고 있는 클래스 
/// VCam = 시네머신 가상 카메라
/// Door = 스테이지의 문
/// </summary>
[System.Serializable]
public class Stage
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
