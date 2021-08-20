using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class AddUIButtonEvent : MonoBehaviour
{
    protected List<GameObject> ButtonList = new List<GameObject>();

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
    /// <param name="target">해당 게임 오브젝트</param>
    /// <param name="state">상태</param>
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
    /// 버튼에 통해 이벤트를 줄 경우
    /// </summary>
    protected void AddClickButtonEvent(Button target, UnityAction function)
    {
        target.onClick.AddListener(() => function());
    }

    /// <summary>
    /// 트리거에 이벤트를 추가하는 함수
    /// </summary>
    /// <param name="trigger">해당 대상이 달고 있는 트리거 밑의 구현함수로 뽑아와야함</param>
    /// <param name="type">이벤트 타입 ex)EventTriggerType.PointerEnter </param>
    /// <param name="function">추가할 함수</param>
    protected void AddButtonTriggerEvent(EventTrigger trigger, EventTriggerType type, UnityAction function)
    {
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = type;
        //entry.callback.AddListener((data) => { OnPointerDownDelegate((PointerEventData)data); });
        entry.callback.AddListener((data) => { function(); });
        trigger.triggers.Add(entry);
    }

    /// <summary>
    /// 이벤트 트리거를 추가하고 받아오는 함수
    /// </summary>
    /// <param name="target"> 이벤트 추가할 대상</param>
    /// <returns> 반환값 </returns>
    protected EventTrigger AddEventTrigger(GameObject target)
    {
        EventTrigger eventTrigger;
        try
        {
            eventTrigger = target.AddComponent<EventTrigger>();
        }
        catch (UnityException e)
        {
            Debug.Log(e);
            target.TryGetComponent<EventTrigger>(out eventTrigger);
        }
        return eventTrigger;
    }

    /// <summary>
    /// 애니메이터를 추가하고 반환받는 함수
    /// 있을 경우 해당 애니메이터를 반환ㅎ
    /// </summary>
    /// <param name="target">추가할 대상</param>
    /// <returns></returns>
    protected Animator GetAnimator(GameObject target)
    {
        Animator animator;
        if (!target.TryGetComponent<Animator>(out animator))
            animator = target.AddComponent<Animator>();
        animator.runtimeAnimatorController = (RuntimeAnimatorController)Resources.Load($"Animation/Controller/{target.name}");
        return animator;
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
    /// 특정 대상에게 이벤트를 줄 경우
    /// </summary>
    /// <param name="target">게임오브젝트 대상</param>
    /// <param name="function">이벤트</param>
    protected void AddButtonEvent(GameObject target, UnityAction function)
    {
        AddClickButtonEvent(target.GetComponent<Button>(), function);
    }

    /// <summary>
    /// transform을 통해 이벤트를 등록 할 경영우
    /// </summary>
    /// <param name="target">대상</param>
    /// <param name="function">이벤트</param>
    protected void AddButtonEvent(Transform target, UnityAction function)
    {
        Button button;
        if (target.TryGetComponent<Button>(out button))
            AddClickButtonEvent(target.GetComponent<Button>(), function);
        else
        {
            Debug.Log($"{target}is not have Button");
            //AddClickButtonEvent(target.gameObject.AddComponent<Button>(), function);

        }
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

    /// <summary>
    /// 모든 버튼에 소리 추가하는 함
    /// </summary>
    protected void SetButtonHoverSound()
    {
        foreach (var button in ButtonList)
        {
            var eventTrigger = AddEventTrigger(button);
            var animator = GetAnimator(button);
            AddButtonTriggerEvent(eventTrigger, EventTriggerType.PointerEnter, () =>
            {
                //animator.Play("hover");
                SoundManager.Instance.SFXPlayer("MenuButtonHover");
            });
            AddButtonTriggerEvent(eventTrigger, EventTriggerType.PointerExit, () =>
            {
                //animator.Play("default");
            });
        }
    }

    /// <summary>
    /// 하나만 추가
    /// </summary>
    protected void SetButtonHoverSound(GameObject target)
    {
        var eventTrigger = AddEventTrigger(target);
        var animator = GetAnimator(target);
        AddButtonTriggerEvent(eventTrigger, EventTriggerType.PointerEnter, () =>
        {
                //animator.Play("hover");
                SoundManager.Instance.SFXPlayer("MenuButtonHover");
        });
        AddButtonTriggerEvent(eventTrigger, EventTriggerType.PointerExit, () =>
        {
                //animator.Play("default");
        });
    }

    /// <summary>
    /// 리스트에 해당하는 버튼 사운드 주기
    /// </summary>
    protected void SetButtonHoverSound(Dictionary<string,GameObject> ButtonList)
    {
        foreach (var button in ButtonList.Values)
        {
            var eventTrigger = AddEventTrigger(button);
            var animator = GetAnimator(button);
            AddButtonTriggerEvent(eventTrigger, EventTriggerType.PointerEnter, () =>
            {
                //animator.Play("hover");
                SoundManager.Instance.SFXPlayer("MenuButtonHover");
            });
            AddButtonTriggerEvent(eventTrigger, EventTriggerType.PointerExit, () =>
            {
                //animator.Play("default");
            });
        }
    }

    #endregion
}
