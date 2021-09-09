using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using GameData;

public class DialogueManager : Singleton<DialogueManager>
{
    #region Field
    [SerializeField] private Text target;
    [SerializeField] private float typingTerm=0.1f;
    private bool isTyping = false;

    MovePlayer movePlayer;

    [SerializeField] private GameObject dialogWindow;

    private IEnumerator typing;

    private DialogueData.DialogueDataClass dialogue;
    private Queue<DialogueData.DialogueDataClass> dialogueQueue = new Queue<DialogueData.DialogueDataClass>();
    #endregion

    #region InheritanceFunction
    public override void Init(){
        if (dialogWindow == null)
            dialogWindow = GameObject.Find("Window");
        dialogWindow.SetActive(false);

        movePlayer = MainObject.Instance.player.GetComponent<MovePlayer>();
    }
    #endregion

    #region Function

    public void AttachDialog(string name)
    {
        //사전으로 딕셔버리에 텍스트 컴포넌트, null 값에 차후 대체
        Text target = null;

        if (target == null)
            Debug.Log($"{name}은 없는 객체 입니다.");
        else {
            this.target = target;
        }

        
    }


    /// <summary>
    /// 다이어 로그 이벤트를 발생시키는 스크립트
    /// 오브젝트와 상호작용등 특정 상황에 작동 시켜야
    /// </summary>
    /// <param name="key">EventDialog를 참조하여 맞는 이벤트 호춡</param>
    public void StartDialogEvent(int key) {
        EventDialogData.EventDialogClass a = EventDialogData.Instance.GetTableData(key);
        Begin(a.startIndex,a.endIndex);

    }

    /// <summary>
    /// 스크립트를 시작 시켜주는 함수
    /// </summary>
    public void Begin(int start,int end)
    {
        movePlayer.SetMoveLock(true);

        dialogWindow.SetActive(true);
        dialogue = new DialogueData.DialogueDataClass();
        dialogueQueue.Clear();
        for (int i = start; i <= end; i++) {
            dialogueQueue.Enqueue(DialogueData.Instance.GetTableData(i));
        }
        Next();
    }

    /// <summary>
    /// 다음 텍스트를 보여주는 스크립트
    /// 현재 버튼의 이벤트로 실행중이지만, 나중에는 어플리케이션 온 클릭에서 실행하도록 바꾸게 해야함.
    /// -> 클릭시? 마우스로 말풍선? 
    /// </summary>
    public void Next()
    {
        if (isTyping == true)
        {
            StopCoroutine(typing);
            target.text = dialogue.dialogue;
            isTyping = false;
            return;
        }

        if (dialogueQueue.Count == 0)
        {
            End();
            return;
        }

        if (isTyping == false)
        {
            dialogue = dialogueQueue.Dequeue();
            AttachDialog(dialogue.name);
            if(!string.IsNullOrEmpty(dialogue.sfxSound))
                SoundManager.Instance.SFXPlayer(dialogue.sfxSound);
            target.text = string.Empty;
            typing = TypeSentance();
            StartCoroutine(typing);
        }
        
    }
    

    /// <summary>
    /// 끝났음을 알려주는 스크립트
    /// </summary>
    public void End() {
        movePlayer.SetMoveLock(false);

        dialogWindow.SetActive(false);
        //끝남 처리

    }

    /// <summary>
    /// 하나씩 출력해주는 함수
    /// </summary>
    IEnumerator TypeSentance() {
        isTyping = true;
        foreach (var letter in dialogue.dialogue) {
            target.text += letter;
            yield return new WaitForSeconds(typingTerm);
        }

        isTyping = false;
    }
    #endregion
}
