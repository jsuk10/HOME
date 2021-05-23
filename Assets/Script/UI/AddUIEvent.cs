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
    public virtual void init() { }

    /// <summary>
    /// state값에 맞춰서 게임 오브젝트를 꺼준다.
    /// </summary>
    public void SetView(bool state)
    {
        gameObject.SetActive(state);
    }
    public void SetView(GameObject target, bool state)
    {
        target.SetActive(state);
    }
    /// <summary>
    /// 활성화를 토글해준다
    /// </summary>
    public void SetActiveTogle(GameObject target)
    {
        target.SetActive(!gameObject.activeSelf);
    }

    /// <summary>
    /// 텍스트를 바꿔줄 경우
    /// </summary>
    public void SetText(Text target, string content)
    {
        target.text = content;
    }
    public void SetText(GameObject target, string content)
    {
        SetText(target.GetComponent<Text>(), content);
    }

    /// <summary>
    /// 버튼을 통해 이벤트를 줄 경우
    /// </summary>
    public void AddButtonEvent(Button target, UnityAction function)
    {
        target.onClick.AddListener(() => function());
    }

    /// <summary>
    /// Tansform을 통해 이벤트를 줄 경우
    /// </summary>
    public void AddButtonEvent(Transform target, UnityAction function)
    {
        AddButtonEvent(target.GetComponent<Button>(), function);
    }

    /// <summary>
    /// 자신에게 이벤트를 줄 경우
    /// </summary>
    public void AddButtonEvent(UnityAction function)
    {
        AddButtonEvent(transform.GetComponent<Button>(), function);
    }
    /// <summary>
    /// 하위 오브젝트에 이벤트를 줄 경우
    /// </summary>
    public void AddButtonEvent(string path, UnityAction function)
    {
        AddButtonEvent(transform.Find(path), function);
    }
}
