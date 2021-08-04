using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : Singleton<SceneManager>
{
    #region InheritanceFunction
    public override void Init()
    {
        DontDestroyOnLoad(gameObject);
    }
    #endregion

    #region Function
    /// <summary>
    /// 신 옮겨주는 함
    /// </summary>
    /// <param name="sceneName">신의 이름을 넣는곳, 잘못할 가능성 생각해서 enum으로 관리함</param>
    public void LoadScene(Stage sceneName)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName.ToString());
    }
    #endregion
}