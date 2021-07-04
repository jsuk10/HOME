using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GameData
{
    /// <summary>
    /// 이벤트 단위로 사전을 관리하는 클래스
    /// </summary>
    public class EventDialogData : Data<EventDialogData, EventDialogData.EventDialogClass>
    {

        /// <summary>
        /// 이름 설정 및 테이블 제작
        /// </summary>
        public override void Init()
        {
            //상위 오브젝트의 Init실행 즉 테이블 읽음
            fileName = ParsingDataSet.EventDialog;
            base.Init();
        }

        /// <summary>
        /// 딕셔너리에 들어갈 클래스
        /// key는 무조건 int값
        /// </summary>
        public class EventDialogClass : DataClass
        {
            /// <summary> 이벤트의 이름 </summary> 
            public string eventName;
            /// <summary> 시작 번호 </summary>
            public int startIndex;
            /// <summary> 끝나는 번호 </summary>
            public int endIndex;
            /// <summary> 기타 사항 </summary>
            public string ect;
        }
    }
}