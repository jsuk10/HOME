using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : Singleton<UIManager>
{
    #region field
    public UIMenuClass uiMenu;
    private PlayerNameClass playerName;
    #endregion

    #region InheritanceFunction
    /// <summary>
    /// 초기화시 유아이 할당해줘야함
    /// </summary>
    public override void Init()
    {
        //딕셔너리에 버튼마다 설정한 타입을 넣어둠.
    }
    #endregion

    #region UnityCycle
    /// <summary>
    /// 플레이어 이름들을 가지고 오는 클래스
    /// </summary>
    private void Start()
    {
        //플레이어 네임을 가지고옴.
        playerName = PlayerData.Instance.PlayerName;
        SetName();
        OffMenu();
    }
    #endregion

    #region Function
    /// <summary>
    /// 데이터를 불러와서 세팅해놓는 함수
    /// </summary>
    private void SetName()
    {
        for (int i = 0; i < playerName.playerData.Length; i++)
        {
            if (playerName.playerData[i] == null)
            {
                uiMenu.playerNameText[i].text = "새 데이터 만들기";
            }
            else
            {
                uiMenu.playerNameText[i].text = playerName.playerData[i].name;
            }
        }
    }
    #endregion


    #region UIOnOff
    /// <summary>
    /// 메뉴를 끄는 함수
    /// </summary>
    private void OffMenu()
    {
        uiMenu.loadOption.SetActive(false);
        uiMenu.settingOption.SetActive(false);
        uiMenu.creadit.SetActive(false);
    }

    /// <summary>
    /// 로드 버튼을 비활성화 시킨다.
    /// </summary>
    public void LoadOnOff()
    {
        uiMenu.loadOption.SetActive(!uiMenu.loadOption.activeSelf);
    }

    /// <summary>
    /// 세팅 버튼을 비활성화 시킨다.
    /// </summary>
    public void SettingOnOff()
    {
        uiMenu.settingOption.SetActive(!uiMenu.settingOption.activeSelf);
    }

    /// <summary>
    /// 크레딧을 온오프 시킨
    /// </summary>
    public void CreditOnOff()
    {
        uiMenu.creadit.SetActive(!uiMenu.creadit.activeSelf);
    }

    /// <summary>
    /// 게임 종료 버튼
    /// </summary>
    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();// 어플리케이션 종료
#endif
    }
    #endregion

}