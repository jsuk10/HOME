using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using GameData;

public class DialogueManager : Singleton<DialogueManager>
{
    #region Field
    [SerializeField] private Text chatText;
    [SerializeField] private float typingTerm=0.1f;
    private bool isTyping = false;

    string curChatBoxName;
    MovePlayer movePlayer;

    private GameObject chatBox;
    private GameObject playerChatBox;
    private GameObject systemChatBox;
    private GameObject driverChatBox;

    private IEnumerator typing;

    private DialogueData.DialogueDataClass dialogue;
    private Queue<DialogueData.DialogueDataClass> dialogueQueue = new Queue<DialogueData.DialogueDataClass>();
    #endregion

    #region InheritanceFunction

    // ChatBox들 찾아서 연결, 비활성화
    public override void Init(){
        if (playerChatBox == null)
            playerChatBox = GameObject.Find("PlayerChatBox");
        playerChatBox.SetActive(false);
        if (systemChatBox == null)
            systemChatBox = GameObject.Find("SystemChatBox");
        systemChatBox.SetActive(false);
        if (driverChatBox == null)
            driverChatBox = GameObject.Find("DriverChatBox");
        driverChatBox.SetActive(false);

        movePlayer = MainObject.Instance.player.GetComponent<MovePlayer>();

        
    }
    #endregion

    #region Function




    public void AttachDialog(string name)
    {
        //사전으로 딕셔버리에 텍스트 컴포넌트, null 값에 차후 대체
        Text chatText = null;

        if (chatText == null)
            Debug.Log($"{name}은 없는 객체 입니다.");
        else {
            this.chatText = chatText;
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
        Camera cam = GameObject.Find("MainCamera").GetComponent<Camera>();
        var chatPointPosition = MainObject.Instance.player.transform.Find("ChatPoint").position;
        var chatPointPositionUI = cam.WorldToViewportPoint(chatPointPosition);

        //chatBox.transform.position = cam.ViewportToWorldPoint(chatPointPositionUI);



        movePlayer.SetMoveLock(true);

        
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
            
            chatText.text = dialogue.dialogue;
            isTyping = false;
            return;
        }

        // 잘 안되는 부분 dialogue가 끝났을때 실행되야함
        if (dialogueQueue.Count == 0)
        {
            chatBox.SetActive(false);
            chatBox = null;
            curChatBoxName = null;
            Debug.Log("ChatEnd");
            End();
            return;
        }

        if (isTyping == false)
        {
            dialogue = dialogueQueue.Dequeue();
            AttachDialog(dialogue.name);


            // 새로 chatBox가 나와야 할 때 화자의 타입에 따라 다른 chatBox를 호출해야함 dialogue.name을 조회하여 확인
            if(curChatBoxName != dialogue.name)
            {
                Debug.Log(curChatBoxName + "changed to" + dialogue.name);
                if(chatBox != null)
                    chatBox.SetActive(false);
                SetChatBox(dialogue.name);
                chatBox.SetActive(true);
            }
            
            if(!string.IsNullOrEmpty(dialogue.sfxSound))
                SoundManager.Instance.SFXPlayer(dialogue.sfxSound);
            chatText.text = string.Empty;
            typing = TypeSentance();
            StartCoroutine(typing);
        }
        
    }
    

    /// <summary>
    /// 끝났음을 알려주는 스크립트
    /// </summary>
    public void End() 
    {
        movePlayer.SetMoveLock(false);
        //끝남 처리
    }

    /// <summary>
    /// 하나씩 출력해주는 함수
    /// </summary>
    IEnumerator TypeSentance() 
    {
        isTyping = true;
        foreach (var letter in dialogue.dialogue) {
            chatText.text += letter;
            Debug.Log(chatText.text);
            yield return new WaitForSeconds(typingTerm);
        }

        isTyping = false;
    }

    //dialogue.name을 받아 chatBox설정
    private void SetChatBox(string chatterName)
    {
        if(chatterName == "System")
            chatBox = systemChatBox;
        else if(chatterName == "Player")
            chatBox = playerChatBox;
        else if(chatterName == "Driver")
            chatBox = systemChatBox;
        else
            chatBox = systemChatBox;
        curChatBoxName = chatterName;
        chatText = chatBox.transform.Find("ChatText").gameObject.GetComponent<Text>();
    }
    #endregion
}
