using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    ButtonInfo[] UImenu;
    Dictionary<ButtonType, GameObject> uiDictionary = new Dictionary<ButtonType, GameObject>();

    private void Awake()
    {
        init();
    }
    public void init()
    {
        for (int i = 0; i < UImenu.Length; i++)
        {
            uiDictionary.Add(UImenu[i].CurrentType, UImenu[i].gameObject);
        }
    }
    public void GameStart()
    {
        SceneManager.LoadScene("Start");
    }
    public void Load()
    {
        Debug.Log("Load");
    }
    public void SettingOnOff()
    {
        uiDictionary[ButtonType.SettingOn].SetActive(!uiDictionary[ButtonType.SettingOn].activeSelf);
        uiDictionary[ButtonType.SettingOFF].SetActive(!uiDictionary[ButtonType.SettingOn].activeSelf);
    }
    public void OptionOnOff()
    {
        uiDictionary[ButtonType.OptionOn].SetActive(!uiDictionary[ButtonType.OptionOn].activeSelf);
        uiDictionary[ButtonType.OptionOff].SetActive(!uiDictionary[ButtonType.OptionOn].activeSelf);
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();// 어플리케이션 종료
#endif
    }
}