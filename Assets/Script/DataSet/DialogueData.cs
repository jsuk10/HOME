using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameData
{
    public class DialogueData : Data<DialogueData, DialogueData.DialogueDataClass>
    {
        //이름 설정 및 테이블 제작
        public override void Init()
        {
            //상위 오브젝트의 Init실행 즉 테이블 읽음
            fileName = ParsingDataSet.Dialogue;
            base.Init();
        }
        /// <summary>
        /// 딕셔너리에 들어갈 클래스
        /// </summary>
        public class DialogueDataClass : DataClass
        {
            public string dialogue;
            /// <summary>말하는 주체 </summary> 
            public string name;
            /// <summary> 말 </summary>
        }
    }
}