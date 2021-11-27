using UnityEngine;
using System.Collections;

public class BookManager : Singleton<BookManager>
{
    private Book book;
    private Sprite[] empty = new Sprite[2];
    // 완성된 이미지들
    private Sprite[] fillImage = new Sprite[8];
    // 이미지가 있는지 여부를 체크하는 함수.
    private bool[] IsfillImage = new bool[8];
    private int maxBookSize = 8;


    public override void Init()
    {

        Transform albumTransform = LobbyManager.Instance.ObjectDictionary["Album"].transform;
        albumTransform.Find("AutoFlip/Book").TryGetComponent<Book>(out book);
        Debug.Log("hi");
        Setting();
        SettingBookImage();
    }

    /// <summary>
    /// 기본 세팅
    /// </summary>
    private void Setting() {
        fillImage = new Sprite[maxBookSize];
        empty[0] = Resources.Load<Sprite>("Image/Album/emptyLeft");
        empty[1] = Resources.Load<Sprite>("Image/Album/emptyRight");
        // 책에 들어갈 완성된 이미지 넣기.
        fillImage = Resources.LoadAll<Sprite>("Image/Album/fillImages");
        book.bookPages = new Sprite[maxBookSize];
    }

    #region custom
    /// <summary>
    /// 북 이미지 넣기
    /// </summary>
    private void SettingBookImage()
    {
        for (int i = 0; i < maxBookSize; i++)
        {
            book.bookPages[i] = (IsfillImage[i] != false) ? fillImage[i] : empty[i % 2];
        }
    }

    /// <summary>
    /// 북에 맞는 이미지 넣어주는 함수
    /// </summary>
    /// <param name="index">이미지의 위치</param>
    /// <param name="sprite">이미지 Sprite</param>
    public void SetBookImage(int index ) {
        if (index >= fillImage.Length())
            return;
        IsfillImage[index] = true;
        book.bookPages[index] = fillImage[index];
    }
    #endregion
}
