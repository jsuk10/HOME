using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[System.Serializable]
public class UIMenu
{
    public GameObject loadOption;
    public GameObject settingOption;
    public GameObject creadit;
    public Text[] playerNameText = new Text[3];
}

public class UIManager : Singleton<UIManager>
{
    public UIMenu uiMenu;
    private PlayerName playerName;

    //초기화 (awake)
    public override void init()
    {
        //딕셔너리에 버튼마다 설정한 타입을 넣어둠.
    }

    private void Start()
    {
        //플레이어 네임을 가지고옴.
        playerName = PlayerNameController.Instance.PlayerName;
        SetName();
        OffMenu();
    }

    private void OffMenu()
    {
        uiMenu.loadOption.SetActive(false);
        uiMenu.settingOption.SetActive(false);
        uiMenu.creadit.SetActive(false);

    }
    private void SetName()
    {
        for (int i = 0; i < playerName.playerNames.Length; i++)
        {
            if (playerName.playerNames[i] == null)
            {
                uiMenu.playerNameText[i].text = "새 데이터 만들기";
            }
            else
            {
                uiMenu.playerNameText[i].text = playerName.playerNames[i];
            }
        }
    }



    public void LoadOnOff()
    {
        uiMenu.loadOption.SetActive(!uiMenu.loadOption.activeSelf);
    }

    //세팅을 껏다 킬때 사용함
    public void SettingOnOff()
    {
        //토글형식으로 생각하면 될듯
        uiMenu.settingOption.SetActive(!uiMenu.settingOption.activeSelf);
    }
    //옵션을 껐다 킬때 사용함
    public void CreditOnOff()
    {
        //마찬가지로 토글
        uiMenu.creadit.SetActive(!uiMenu.creadit.activeSelf);
    }

    //게임 나갈 경우
    //플렛폼별로 써놓음
    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();// 어플리케이션 종료
#endif
    }
}