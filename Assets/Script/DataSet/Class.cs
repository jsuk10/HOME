using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collection
{
    //차후 언록 초기화 해주는거 작성, 수집요소 얼마나 있는지 부터 정하기
    public bool[] unlock;
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