using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using GameData;

public class DialogueManager : Singleton<DialogueManager>
{
    [SerializeField] private Text nameUI;
    [SerializeField] private Text sentenceUI;
    [SerializeField] private float typingTerm=0.1f;
    private bool isTyping = false;
    IEnumerator typing;

    private DialogueData.DialogueDataClass dialogue;
    private Queue<DialogueData.DialogueDataClass> dialogueQueue = new Queue<DialogueData.DialogueDataClass>();

    private Queue<string> sentencesQueue = new Queue<string>();

    public override void Init(){
        if (nameUI == null) nameUI = GameObject.Find("Name").GetComponent<Text>();
        if (nameUI == null) sentenceUI = GameObject.Find("Sentance").GetComponent<Text>();
    }


    /// <summary>
    /// 스크립트를 시작 시켜주는 함수
    /// </summary>
    public void Begin(int start,int end)
    {
        dialogue = new DialogueData.DialogueDataClass();
        dialogueQueue.Clear();
        for (int i = start; i < end; i++) {
            dialogueQueue.Enqueue(DialogueData.Instance.GetTableData(i));
            Debug.Log($"{i} : {DialogueData.Instance.GetTableData(i).dialogue}");
        }
        dialogue = dialogueQueue.Dequeue();

        Next();
    }

    /// <summary>
    /// 다음 텍스트를 보여주는 스크립트
    /// </summary>
    public void Next()
    {
        Debug.Log("next");
        
        if (isTyping == true)
        {
            //StopAllCoroutines();
            StopCoroutine(typing);
            sentenceUI.text = dialogue.dialogue;
            isTyping = false;
            if(dialogueQueue.Count != 0)
            dialogue = dialogueQueue.Dequeue();
        }
        else
        {
            nameUI.text = dialogue.name;
            sentenceUI.text = string.Empty;
            typing = TypeSentance();
            StartCoroutine(typing);
        }
        if (dialogueQueue.Count == 0)
        {
            End();
            return;
        }
    }


    /// <summary>
    /// 끝났음을 알려주는 스크립트
    /// </summary>
    public void End() {
        //끝남 처리
        Debug.Log("끝");
    }

    /// <summary>
    /// 하나씩 출력해주는 함수
    /// </summary>
    IEnumerator TypeSentance() {
        //타다닥 소리 넣어주면 좋을듯
        isTyping = true;
        foreach (var letter in dialogue.dialogue) {
            sentenceUI.text += letter;
            yield return new WaitForSeconds(typingTerm);
        }
        isTyping = false;
        dialogue = dialogueQueue.Dequeue();
    }

}
