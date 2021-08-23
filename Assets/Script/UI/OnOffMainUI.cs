using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnOffMainUI : AddUIButtonEvent
{
    [SerializeField] AutoFlip autoFlip;
    [SerializeField] Book book;
    [SerializeField] Sprite[] empty = new Sprite[2];
    [SerializeField] Sprite[] fillImage = new Sprite[8];

    int maxBookSize = 8;
    #region InheritanceFunction

    public override void Init()
    {
        transform.Find("Album/AutoFlip/Book").TryGetComponent<AutoFlip>(out autoFlip);
        transform.Find("Album/AutoFlip/Book").TryGetComponent<Book>(out book);
        SettingBookImage();
        Set();
    }

    private void SettingBookImage()
    {
        
        empty[0] = Resources.Load<Sprite>("Image/Album/emptyLeft");
        empty[1] = Resources.Load<Sprite>("Image/Album/emptyRight");
        book.bookPages = new Sprite[maxBookSize];
        fillImage = new Sprite[maxBookSize];
        //fillImage = Resources.LoadAll<Sprite>("Image/Album/fillImage");
        for (int i = 0; i < maxBookSize; i++)
        {
            //만일 채워져 있을 경우 해당 페이지 채우기
            //1이나 2넣어주
            Debug.Log(book.bookPages[i]);
            book.bookPages[i] = empty[i % 2];


        }
    }

    #endregion

    #region Function
    /// <summary>
    /// 이벤트 할당을 위해 Init 에서 실행하는 함수
    /// </summary>
    public override void Set()
    {
        AddButtonEvent("Album/AlbumOff", () => {
            if(!autoFlip.isFlipping)
                SetTargetView(LobbyManager.Instance.ObjectDictionary["Album"], false);
            });
        //AddButtonEvent("Setting/SettingOffButton", () => SetTargetView(LobbyManager.Instance.ObjectDictionary["Setting"], false));
    }


    #endregion

    #region Event


    #endregion
}
