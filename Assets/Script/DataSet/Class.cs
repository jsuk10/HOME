using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[System.Serializable]
public class PlayerDataClass
{
    public string name;
    public int stage;
    public string[] page;

}

[System.Serializable]
public class PlayerNameClass
{
    public string[] playerNames = new string[3];
}

[System.Serializable]
public class UIMenuClass
{
    public GameObject loadOption;
    public GameObject settingOption;
    public GameObject creadit;
    public Text[] playerNameText = new Text[3];
}