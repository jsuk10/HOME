using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionPlayer : Singleton<InteractionPlayer>
{
    List<ObjectInteractable> listObject;
    public Queue<Command> queueCommand;

    public override void Init()
    {
        listObject = new List<ObjectInteractable>();
        queueCommand = new Queue<Command>();
    } 

    void Start()
    {
        StartCoroutine(nameof(InputProcess));
        StartCoroutine(nameof(ExecuteCommandQueue));
    }

    /// <summary>
    /// 입력 처리, 상호작용 키를 누르면 상호작용 커맨드를 큐에 삽입하고 딜레이를 준다
    /// </summary>
    public IEnumerator InputProcess()
    {
        while(true)
        {
            yield return new WaitUntil(() => Input.GetKey(KeyCode.E));
            queueCommand.Enqueue(new Command(this, null, nameof(Command.Interaction)));
            yield return new WaitForSeconds(0.3f);
        }
    }

    /// <summary>
    /// 매 프레임마다 큐를 체크해 명령이 들어왔다면 명령을 실행한다
    /// </summary>
    /// <returns></returns>
    public IEnumerator ExecuteCommandQueue()
    {
        while(true)
        {
            //Debug.Log(queueCommand.Count);
            yield return new WaitUntil(() => 0 < queueCommand.Count);
            queueCommand.Dequeue().Execute();
        }
    }

    /// <summary>
    /// 리스트를 변경하는 동작에 대한 정보를 가지고 있는 클래스
    /// 외부 클래스인 Outer, 오브젝트인 Other, 실행할 명령인 CommandName을 인자로 받는다
    /// </summary>
    public class Command
    {
        ObjectInteractable other;
        InteractionPlayer outer;
        delegate void DelCommand();
        DelCommand delCommand;

        /// <summary>
        /// 생성자에서 실행할 명령을 문자열로 받아 SetCommand를 통해 동작 결정
        /// </summary>
        /// <param name="Outer"></param>
        /// <param name="Other"></param>
        /// <param name="CommandName"></param>
        public Command(InteractionPlayer Outer, ObjectInteractable Other, string CommandName)
        {
            outer = Outer;
            other = Other;
            SetCommand(CommandName);
        }
        
        /// <summary>
        /// 입력된 문자열에 따른 동작을 결정한다
        /// </summary>
        /// <param name="commandName"></param>
        void SetCommand(string commandName)
        {
            if(commandName == nameof(Interaction))
                delCommand = Interaction;
            else if(commandName == nameof(AddObject))
                delCommand = AddObject;
            else if(commandName == nameof(RemoveObject))
                delCommand = RemoveObject;
        }

        /// <summary>
        /// 상호작용 시 호출되는 함수, 리스트의 첫 번째 원소를 뽑아서 제거하고 상호작용을 실행
        /// </summary>
        public void Interaction()
        {
            if(0 < outer.listObject.Count)
            {
                var popedObject = outer.listObject[0];
                outer.listObject.RemoveAt(0);
                popedObject.Interaction();
            }
        }

        /// <summary>
        /// 리스트에 오브젝트를 추가하는 함수
        /// </summary>
        /// <param name="objectInteractable"></param>
        public void AddObject()
        {
            outer.listObject.Add(other);
        }

        /// <summary>
        /// 리스트에 오브젝트를 제거하는 함수
        /// </summary>
        public void RemoveObject()
        {
            outer.listObject.Remove(other);
        }

        /// <summary>
        /// 위의 동작이 실제로 수행되는 함수
        /// delCommand
        /// </summary>
        public void Execute()
        {
            delCommand();
        }
    }

    /// <summary>
    /// Queue에 AddObject 명령을 삽입
    /// </summary>
    /// <param name="other"></param>
    public void AddObject(ObjectInteractable other)
    {
        queueCommand.Enqueue(new Command(this, other, nameof(Command.AddObject)));
    }

    /// <summary>
    /// Queue에 RemoveObject 명령을 삽입
    /// </summary>
    /// <param name="other"></param>
    public void RemoveObject(ObjectInteractable other)
    {
        queueCommand.Enqueue(new Command(this, other, nameof(Command.RemoveObject)));
    }
}