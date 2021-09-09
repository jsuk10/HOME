using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

/// <summary>
/// Dog와 Player의 Animation을 다뤄주는 이벤트
/// </summary>
public class AnimationManager : Singleton<AnimationManager>
{
    [SerializeField] private Animator PlayerAnimator;
    [SerializeField] private Animator DogAnimator;


    public override void Init() { }

    /// <summary>
    /// MainObject에 의존성이 있어서 찾는걸 확실히 되는 Start로 옮김
    /// </summary>
    private void Start()
    {
        if (PlayerAnimator == null)
            if (!MainObject.Instance.player.TryGetComponent<Animator>(out PlayerAnimator))
                PlayerAnimator = MainObject.Instance.player.AddComponent<Animator>();
        if (DogAnimator == null)
            if (!MainObject.Instance.dog.TryGetComponent<Animator>(out PlayerAnimator))
                DogAnimator = MainObject.Instance.dog.AddComponent<Animator>();

        if (PlayerAnimator.runtimeAnimatorController == null)
            PlayerAnimator.runtimeAnimatorController = Resources.Load("PlayerAnimationController") as RuntimeAnimatorController;
        if (DogAnimator.runtimeAnimatorController == null)
            DogAnimator.runtimeAnimatorController = Resources.Load("DogAnimationController") as RuntimeAnimatorController;

    }

    /// <summary>
    /// 사람 애니메이션 실행해주는 함수
    /// </summary>
    /// <param name="animationName">애니메이션 이름</param>
    /// <returns>애니메이션의 길이 리턴</returns>
    public float PlayPlayerAni(string animationName)
    {
        try
        {
            this.PlayerAnimator.Play(animationName);
            Debug.Log(PlayerAnimator.GetCurrentAnimatorClipInfo(0)[0].clip.length);
            //foreach(var a in playerClips) {
            //    Debug.Log($"{a.name} : {a.length}") ;
            //}
        }
        catch (Exception e)
        {
            Debug.Log($"{animationName} 은 Player에 없는 애니메이션 입니다.");
            Debug.Log(e);
        }
        return PlayerAnimator.GetCurrentAnimatorClipInfo(0)[0].clip.length;
    }
    /// <summary>
    /// 현재 움직일 수 있는 상태(디폴트,무브 상태일 경우)
    /// </summary>
    /// <param name="stateName"></param>
    /// <returns></returns>
    public bool PlayerIsMove()
    {
        return PlayerAnimator.GetCurrentAnimatorStateInfo(0).IsName("Move")
            || PlayerAnimator.GetCurrentAnimatorStateInfo(0).IsName("Run");
    }


    /// <summary>
    /// 강아지 애니매이션 실행해주는 스크립트
    /// </summary>
    /// <param name="animationName">애니메이션에 들어가 있는 이름 </param>
    public void PlayDogAni(string animationName)
    {
        try
        {
            DogAnimator.Play(animationName);
        }
        catch (Exception e)
        {
            Debug.Log($"{animationName} 은 Dog에 없는 애니메이션 입니다.");
            Debug.Log(e);
        }
    }
}
