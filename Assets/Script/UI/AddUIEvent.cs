using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class AddUIEvent : MonoBehaviour
{
    /// <summary>
    /// 초기화 해주는 함수
    /// 여기서 이벤트 할당 및 활성화 여부 지정해줌
    /// </summary>
    public virtual void Init() { }
    public virtual void Set() { }

    # region event
    /// <summary>
    /// state값에 맞춰서 게임 오브젝트를 꺼준다.
    /// </summary>
    public void SetView(bool state)
    {
        gameObject.SetActive(state);
    }

    /// <summary>
    /// 활성화를 토글해준다
    /// </summary>
    protected void SetActiveTogle(GameObject target)
    {
        target.SetActive(!gameObject.activeSelf);
    }

    /// <summary>
    /// 텍스트를 바꿔줄 경우
    /// </summary>
    protected void SetText(Text target, string content)
    {
        target.text = content;
    }

    /// <summary>
    /// 버튼을 통해 이벤트를 줄 경우
    /// </summary>
    protected void AddButtonEvent(Button target, UnityAction function)
    {
        target.onClick.AddListener(() => function());
    }
    /// <summary>
    /// 게임 종료
    /// </summary>
    protected void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();// 어플리케이션 종료
#endif
    }
    protected void LoadScene(SceneName sceneName)
    {
        SceneManager.Instance.LoadScene(sceneName);
    }
    #endregion

    #region overrload
    protected void SetView(GameObject target, bool state)
    {
        target.SetActive(state);
    }
    protected void SetText(GameObject target, string content)
    {
        SetText(target.GetComponent<Text>(), content);
    }
    /// <summary>
    /// Tansform을 통해 이벤트를 줄 경우
    /// </summary>
    protected void AddButtonEvent(Transform target, UnityAction function)
    {
        AddButtonEvent(target.GetComponent<Button>(), function);
    }
    protected void AddButtonEvent(GameObject target, UnityAction function)
    {
        AddButtonEvent(target.GetComponent<Button>(), function);
    }

    /// <summary>
    /// 자신에게 이벤트를 줄 경우
    /// </summary>
    protected void AddButtonEvent(UnityAction function)
    {
        AddButtonEvent(transform.GetComponent<Button>(), function);
    }

    /// <summary>
    /// 하위 오브젝트에 이벤트를 줄 경우
    /// </summary>
    protected void AddButtonEvent(string path, UnityAction function)
    {
        AddButtonEvent(transform.Find(path), function);
    }
    #endregion
}
