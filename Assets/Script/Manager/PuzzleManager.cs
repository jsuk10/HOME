using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


public class PuzzleManager : Singleton<PuzzleManager>
{
    private ST_PuzzleDisplay puzzle;
    [SerializeField]
    private Texture[] puzzleImages;

    public override void Init()
    {
        if(puzzle==null)
            GameObject.Find("SlidingTile_4by4").TryGetComponent<ST_PuzzleDisplay>(out puzzle);
        puzzle.gameObject.SetActive(false);
        puzzleImages = Resources.LoadAll<Texture>("Image/puzzle");
        Debug.Log(this.gameObject.name);
        Debug.Log(puzzleImages);
    }

    [ContextMenu("test")]
    public void Test()
    {
        StartPuzzle(0, 0);
    }

    /// <summary>
    /// 퍼즐 시작해주는 함수.
    /// </summary>
    public void StartPuzzle(int stage,int index = -1) {
        //내부 함수 실행
        puzzle.StartPuzzle(puzzleImages[stage],index);
    }
}