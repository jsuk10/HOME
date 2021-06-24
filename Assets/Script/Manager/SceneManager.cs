using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : Singleton<SceneManager>
{
    public override void Init()
    {
        DontDestroyOnLoad(gameObject);
    }

    /// <summary>
    /// 신 옮겨주는 함
    /// </summary>
    /// <param name="sceneName">신의 이름을 넣는곳, 잘못할 가능성 생각해서 enum으로 관리함</param>
    public void LoadScene(SceneName sceneName)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName.ToString());
    }
}