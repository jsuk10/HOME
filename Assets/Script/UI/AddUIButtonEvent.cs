using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class AddUIButtonEvent : MonoBehaviour
{
    /// <summary>
    /// 초기화 해주는 함수
    /// 여기서 이벤트 할당 및 활성화 여부 지정해줌
    /// </summary>
    public virtual void Init() { }
    public virtual void Set() { }

    #region UIevent
    /// <summary>
    /// state값에 맞춰서 게임 오브젝트를 꺼준다.
    /// </summary>
    /// <param name="state">대상의 상태</param>
    public void SetView(bool state)
    {
        gameObject.SetActive(state);
    }
    /// <summary>
    /// Stat에 맞춰서 타겟을 키고 꺼준다.
    /// </summary>
    /// <param name="target"></param>
    /// <param name="state"></param>
    public void SetTargetView(GameObject target, bool state)
    {
        target.SetActive(state);
    }

    /// <summary>
    /// 다른 오브젝트의 활성화를 토글해준다
    /// </summary>
    /// <param name="target">토글 할 대상, 없을 경우 기입 안하</param>
    /// <param name="state">자신의 상태/param>
    public void SetActiveTogle(GameObject target)
    {
        target.SetActive(!gameObject.activeSelf);
    }

    /// <summary>
    /// 대상의 텍스트를 바꿔줄 경우
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
    /// <summary>
    /// 씬을 불러올 경우
    /// </summary>
    /// <param name="sceneName">씬의 이름 단. Enum의 SceneName에 등록된것으로 한정되</param>
    protected void LoadScene(Stage sceneName)
    {
        SceneManager.Instance.LoadScene(sceneName);
    }
    #endregion

    #region overrload
    /// <summary>
    /// 텍스트가 없어서 텍스트를 찾아줘야 할 경우
    /// </summary>
    /// <param name="target">텍스트를 가진 대상</param>
    /// <param name="content">내용</param>
    protected void SetText(GameObject target, string content)
    {
        SetText(target.GetComponent<Text>(), content);
    }

    /// <summary>
    /// 자신에게 이벤트를 줄 경우
    /// </summary>
    protected void AddButtonEvent(UnityAction function)
    {
        AddButtonEvent(transform.GetComponent<Button>(), function);
    }

    /// <summary>
    /// 특정 대상에게 이벤트를 줄 경우
    /// </summary>
    /// <param name="target">게임오브젝트 대상</param>
    /// <param name="function">이벤트</param>
    protected void AddButtonEvent(GameObject target, UnityAction function)
    {
        AddButtonEvent(target.GetComponent<Button>(), function);
    }

    /// <summary>
    /// transform을 통해 이벤트를 등록 할 경영우
    /// </summary>
    /// <param name="target">대상</param>
    /// <param name="function">이벤트</param>
    protected void AddButtonEvent(Transform target, UnityAction function)
    {
        AddButtonEvent(target.GetComponent<Button>(), function);
    }

    /// <summary>
    /// 경로를 통해 이벤트를 줄 경우
    /// </summary>
    /// <param name="path">대상</param>
    /// <param name="function">이벤트</param>
    protected void AddButtonEvent(string path, UnityAction function)
    {
        AddButtonEvent(transform.Find(path), function);
    }
    #endregion
}
