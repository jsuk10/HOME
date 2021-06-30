using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameData;

public class DialogueDictionary : Data<DialogueDictionary, DialogueDictionary.DialogueDataClass>
{
    /// <summary>
    /// 딕셔너리에 들어갈 클래스
    /// </summary>
    public class DialogueDataClass : DataClass
    {
        /// <summary>스크립트 넘버 ex) 2-2</summary>
        public string dialogue;
        /// <summary>나올 그림 번호</summary>
        public int pictureNumber;
        /// <summary>말하는 사람이 있는 위치(좌 0, 우 1)</summary>
        public int positon;
    }
}
